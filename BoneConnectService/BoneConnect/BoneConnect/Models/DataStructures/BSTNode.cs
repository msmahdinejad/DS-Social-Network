namespace BoneConnect.Models.DataStructures;

public class BSTNode<K, V> where K : IComparable<K>
{
    public K Key { get; set; }
    public V Value { get; set; }
    public BSTNode<K, V> Left { get; set; }
    public BSTNode<K, V> Right { get; set; }
    public int Height { get; set; }

    public BSTNode(K key, V value)
    {
        Key = key ?? throw new ArgumentNullException(nameof(key));
        Value = value;
        Height = 1;
    }
}
