using BoneConnect.DataStructures.List;
using BoneConnect.Models.DataStructures;

namespace BoneConnect.DataStructures.Hash;

public class HashTable<K, V>
{
    private readonly object _lock = new object();
    private List<KeyValue<K, V>>[] _table;
    private int _size;
    private int _capacity;
    private readonly double _loadFactor;
    private ArrayList<K> _keysList;

    public int Size => _size;

    public HashTable(int initialCapacity = 8, double loadFactor = 0.66)
    {
        if (initialCapacity <= 0)
            throw new ArgumentOutOfRangeException(nameof(initialCapacity), "Capacity must be greater than zero.");

        if (loadFactor <= 0 || loadFactor > 1)
            throw new ArgumentOutOfRangeException(nameof(loadFactor), "Load factor must be between 0 and 1.");

        _capacity = initialCapacity;
        _size = 0;
        _loadFactor = loadFactor;
        _table = new List<KeyValue<K, V>>[_capacity];
        _keysList = new ArrayList<K>();

        for (int i = 0; i < _capacity; i++)
        {
            _table[i] = new List<KeyValue<K, V>>();
        }
    }

    private int Hash(K key)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));

        int hashValue = key.GetHashCode() & 0x7FFFFFFF;
        return hashValue % _capacity;
    }

    private void Resize()
    {
        lock (_lock)
        {
            int newCapacity = _capacity * 2;
            var newTable = new List<KeyValue<K, V>>[newCapacity];

            for (int i = 0; i < newCapacity; i++)
            {
                newTable[i] = new List<KeyValue<K, V>>();
            }

            foreach (var bucket in _table)
            {
                foreach (var entry in bucket)
                {
                    if (entry.IsActive)
                    {
                        int index = Hash(entry.Key) % newCapacity;
                        newTable[index].Add(entry);
                    }
                }
            }

            _capacity = newCapacity;
            _table = newTable;
        }
    }

    public bool Exists(K key)
    {
        lock (_lock)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            int index = Hash(key);
            foreach (var entry in _table[index])
            {
                if (entry.Key.Equals(key) && entry.IsActive)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public V Get(K key)
    {
        lock (_lock)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            int index = Hash(key);
            foreach (var entry in _table[index])
            {
                if (entry.Key.Equals(key) && entry.IsActive)
                {
                    return entry.Value;
                }
            }

            return default(V);
        }
    }

    public KeyValue<K, V> Insert(K key, V value)
    {
        lock (_lock)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if ((double)_size / _capacity > _loadFactor)
            {
                Resize();
            }

            int index = Hash(key);
            foreach (var entry in _table[index])
            {
                if (entry.Key.Equals(key) && entry.IsActive)
                {
                    entry.Value = value;
                    return entry;
                }
            }

            var newEntry = new KeyValue<K, V>(key, value);
            _table[index].Add(newEntry);
            _keysList.Add(key);
            _size++;
            return newEntry;
        }
    }

    public KeyValue<K, V> Remove(K key)
    {
        lock (_lock)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            int index = Hash(key);
            foreach (var entry in _table[index])
            {
                if (entry.Key.Equals(key) && entry.IsActive)
                {
                    entry.Deactivate();
                    _keysList.Remove(key); // حذف کلید از لیست کلیدها
                    _size--;
                    return entry;
                }
            }

            throw new KeyNotFoundException($"Key not found: {key}");
        }
    }

    public ArrayList<KeyValue<K, V>> GetAll()
    {
        lock (_lock)
        {
            var result = new ArrayList<KeyValue<K, V>>();
            foreach (var key in _keysList)
            {
                if (Exists(key))
                {
                    result.Add(new KeyValue<K, V>(key, Get(key)));
                }
            }

            return result;
        }
    }

    public ArrayList<V> GetAllValues()
    {
        lock (_lock)
        {
            var result = new ArrayList<V>();
            foreach (var key in _keysList)
            {
                if (Exists(key))
                {
                    result.Add(Get(key));
                }
            }

            return result;
        }
    }

    public ArrayList<K> GetAllKeys()
    {
        lock (_lock)
        {
            var result = new ArrayList<K>();
            foreach (var key in _keysList)
            {
                if (Exists(key))
                {
                    result.Add(key);
                }
            }

            return result;
        }
    }

    public KeyValue<K, V> Edit(K key, V newValue)
    {
        lock (_lock)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            int index = Hash(key);
            foreach (var entry in _table[index])
            {
                if (entry.Key.Equals(key) && entry.IsActive)
                {
                    entry.Value = newValue;
                    return entry;
                }
            }

            throw new KeyNotFoundException($"Key not found: {key}");
        }
    }

    public V this[K key]
    {
        get => Get(key);
        set
        {
            lock (_lock)
            {
                if (Exists(key))
                {
                    Edit(key, value);
                }
                else
                {
                    Insert(key, value);
                }
            }
        }
    }

    public async Task<bool> ExistsAsync(K key)
    {
        return await Task.Run(() => Exists(key));
    }

    public async Task<V> GetAsync(K key)
    {
        return await Task.Run(() => Get(key));
    }

    public async Task<KeyValue<K, V>> InsertAsync(K key, V value)
    {
        return await Task.Run(() => Insert(key, value));
    }

    public async Task<KeyValue<K, V>> RemoveAsync(K key)
    {
        return await Task.Run(() => Remove(key));
    }

    public async Task<ArrayList<KeyValue<K, V>>> GetAllAsync()
    {
        return await Task.Run(() => GetAll());
    }

    public async Task<ArrayList<V>> GetAllValuesAsync()
    {
        return await Task.Run(() => GetAllValues());
    }

    public async Task<ArrayList<K>> GetAllKeysAsync()
    {
        return await Task.Run(() => GetAllKeys());
    }

    public async Task<KeyValue<K, V>> EditAsync(K key, V newValue)
    {
        return await Task.Run(() => Edit(key, newValue));
    }
}