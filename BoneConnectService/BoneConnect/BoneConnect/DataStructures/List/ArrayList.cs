using System.Collections;

namespace BoneConnect.DataStructures.List;

public class ArrayList<T> : IEnumerable<T>
{
    private T[] _items;
    private int _size;
    private int _capacity;
    private const int DefaultCapacity = 4;

    public int Count => _size;

    public int Capacity
    {
        get => _capacity;
        set
        {
            if (value < _size)
                throw new ArgumentOutOfRangeException(nameof(value), "Capacity cannot be less than the current size.");

            if (value != _capacity)
            {
                if (value > 0)
                {
                    T[] newItems = new T[value];
                    if (_size > 0)
                    {
                        Array.Copy(_items, newItems, _size);
                    }

                    _items = newItems;
                }
                else
                {
                    _items = Array.Empty<T>();
                }

                _capacity = value;
            }
        }
    }

    public ArrayList()
    {
        _items = Array.Empty<T>();
        _capacity = 0;
        _size = 0;
    }

    public ArrayList(int capacity)
    {
        if (capacity < 0)
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity cannot be negative.");

        _items = capacity == 0 ? Array.Empty<T>() : new T[capacity];
        _capacity = capacity;
        _size = 0;
    }
    
    public ArrayList(List<T> list)
    {
        if (list == null)
            throw new ArgumentNullException(nameof(list));

        _size = list.Count;
        _capacity = _size;
        _items = new T[_capacity];

        list.CopyTo(_items);
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _size)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            return _items[index];
        }
        set
        {
            if (index < 0 || index >= _size)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            _items[index] = value;
        }
    }

    public void Add(T item)
    {
        if (_size == _capacity)
            EnsureCapacity(_size + 1);
        _items[_size++] = item;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > _size)
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

        if (_size == _capacity)
            EnsureCapacity(_size + 1);

        if (index < _size)
        {
            Array.Copy(_items, index, _items, index + 1, _size - index);
        }

        _items[index] = item;
        _size++;
    }

    public bool Remove(T item)
    {
        int index = IndexOf(item);
        if (index >= 0)
        {
            RemoveAt(index);
            return true;
        }

        return false;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _size)
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

        _size--;
        if (index < _size)
        {
            Array.Copy(_items, index + 1, _items, index, _size - index);
        }

        _items[_size] = default;
    }

    public void Clear()
    {
        if (_size > 0)
        {
            Array.Clear(_items, 0, _size);
            _size = 0;
        }
    }

    public bool Contains(T item)
    {
        return IndexOf(item) >= 0;
    }

    public int IndexOf(T item)
    {
        return Array.IndexOf(_items, item, 0, _size);
    }

    public T[] ToArray()
    {
        T[] array = new T[_size];
        Array.Copy(_items, array, _size);
        return array;
    }

    private void EnsureCapacity(int min)
    {
        if (_capacity < min)
        {
            int newCapacity = _capacity == 0 ? DefaultCapacity : _capacity * 2;
            if (newCapacity < min)
                newCapacity = min;
            Capacity = newCapacity;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _size; i++)
        {
            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}