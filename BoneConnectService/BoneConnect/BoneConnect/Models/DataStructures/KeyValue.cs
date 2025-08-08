namespace BoneConnect.Models.DataStructures;

public class KeyValue<K, V>
{
    public K Key { get; }
    public V Value { get; set; }
    public bool IsActive { get; private set; }

    public KeyValue(K key, V value)
    {
        Key = key ?? throw new ArgumentNullException(nameof(key));
        Value = value;
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }
}
