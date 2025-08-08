using BoneConnect.DataStructures.List;
using BoneConnect.Models.DataStructures;

namespace BoneConnect.DataStructures.Tree;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AVLTree<K, V> where K : IComparable<K>
{
    private BSTNode<K, V> _root;
    private readonly object _lock = new object();
    public int Size { get; private set; }

    public AVLTree()
    {
        _root = null;
        Size = 0;
    }

    public void Insert(K key, V value)
    {
        ValidateKey(key);
        lock (_lock)
        {
            _root = InsertInternal(_root, key, value);
        }
    }

    public void Remove(K key)
    {
        ValidateKey(key);
        lock (_lock)
        {
            _root = RemoveInternal(_root, key);
        }
    }

    public V Get(K key)
    {
        ValidateKey(key);
        lock (_lock)
        {
            return GetInternal(_root, key);
        }
    }

    public bool Exists(K key)
    {
        ValidateKey(key);
        lock (_lock)
        {
            return GetInternal(_root, key) != null;
        }
    }

    public ArrayList<K> GetAllKeys()
    {
        lock (_lock)
        {
            var keys = new ArrayList<K>();
            TraverseKeys(_root, keys);
            return keys;
        }
    }

    public ArrayList<V> GetAllValues()
    {
        lock (_lock)
        {
            var values = new ArrayList<V>();
            TraverseValues(_root, values);
            return values;
        }
    }

    public ArrayList<KeyValuePair<K, V>> GetAll()
    {
        lock (_lock)
        {
            var entries = new ArrayList<KeyValuePair<K, V>>();
            TraverseEntries(_root, entries);
            return entries;
        }
    }

    public async Task InsertAsync(K key, V value) => await Task.Run(() => Insert(key, value));
    public async Task RemoveAsync(K key) => await Task.Run(() => Remove(key));
    public async Task<V> GetAsync(K key) => await Task.Run(() => Get(key));
    public async Task<bool> ExistsAsync(K key) => await Task.Run(() => Exists(key));
    public async Task<ArrayList<K>> GetAllKeysAsync() => await Task.Run(() => GetAllKeys());
    public async Task<ArrayList<V>> GetAllValuesAsync() => await Task.Run(() => GetAllValues());
    public async Task<ArrayList<KeyValuePair<K, V>>> GetAllAsync() => await Task.Run(() => GetAll());

    private BSTNode<K, V> InsertInternal(BSTNode<K, V> node, K key, V value)
    {
        if (node == null)
        {
            Size++;
            return new BSTNode<K, V>(key, value);
        }

        int comparison = key.CompareTo(node.Key);
        if (comparison < 0) node.Left = InsertInternal(node.Left, key, value);
        else if (comparison > 0) node.Right = InsertInternal(node.Right, key, value);
        else node.Value = value;

        UpdateHeight(node);
        return Balance(node);
    }

    private BSTNode<K, V> RemoveInternal(BSTNode<K, V> node, K key)
    {
        if (node == null) return null;

        int comparison = key.CompareTo(node.Key);
        if (comparison < 0) node.Left = RemoveInternal(node.Left, key);
        else if (comparison > 0) node.Right = RemoveInternal(node.Right, key);
        else
        {
            if (node.Left == null || node.Right == null)
            {
                Size--;
                return node.Left ?? node.Right;
            }

            var minNode = GetMinNode(node.Right);
            node.Key = minNode.Key;
            node.Value = minNode.Value;
            node.Right = RemoveInternal(node.Right, minNode.Key);
        }

        UpdateHeight(node);
        return Balance(node);
    }

    private V GetInternal(BSTNode<K, V> node, K key)
    {
        while (node != null)
        {
            int comparison = key.CompareTo(node.Key);
            if (comparison < 0) node = node.Left;
            else if (comparison > 0) node = node.Right;
            else return node.Value;
        }

        return default(V);
    }

    private void TraverseKeys(BSTNode<K, V> node, ArrayList<K> keys)
    {
        if (node == null) return;
        TraverseKeys(node.Left, keys);
        keys.Add(node.Key);
        TraverseKeys(node.Right, keys);
    }

    private void TraverseValues(BSTNode<K, V> node, ArrayList<V> values)
    {
        if (node == null) return;
        TraverseValues(node.Left, values);
        values.Add(node.Value);
        TraverseValues(node.Right, values);
    }

    private void TraverseEntries(BSTNode<K, V> node, ArrayList<KeyValuePair<K, V>> entries)
    {
        if (node == null) return;
        TraverseEntries(node.Left, entries);
        entries.Add(new KeyValuePair<K, V>(node.Key, node.Value));
        TraverseEntries(node.Right, entries);
    }

    private void ValidateKey(K key)
    {
        if (key == null) throw new ArgumentNullException(nameof(key), "Key cannot be null.");
    }

    private void UpdateHeight(BSTNode<K, V> node)
    {
        node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
    }

    private int GetHeight(BSTNode<K, V> node) => node?.Height ?? 0;

    private int GetBalanceFactor(BSTNode<K, V> node) => GetHeight(node.Left) - GetHeight(node.Right);

    private BSTNode<K, V> GetMinNode(BSTNode<K, V> node) => node.Left == null ? node : GetMinNode(node.Left);

    private BSTNode<K, V> RotateRight(BSTNode<K, V> node)
    {
        var leftNode = node.Left;
        node.Left = leftNode.Right;
        leftNode.Right = node;
        UpdateHeight(node);
        UpdateHeight(leftNode);
        return leftNode;
    }

    private BSTNode<K, V> RotateLeft(BSTNode<K, V> node)
    {
        var rightNode = node.Right;
        node.Right = rightNode.Left;
        rightNode.Left = node;
        UpdateHeight(node);
        UpdateHeight(rightNode);
        return rightNode;
    }

    private BSTNode<K, V> Balance(BSTNode<K, V> node)
    {
        int balanceFactor = GetBalanceFactor(node);

        if (balanceFactor > 1 && GetBalanceFactor(node.Left) >= 0)
            return RotateRight(node);

        if (balanceFactor > 1 && GetBalanceFactor(node.Left) < 0)
        {
            node.Left = RotateLeft(node.Left);
            return RotateRight(node);
        }

        if (balanceFactor < -1 && GetBalanceFactor(node.Right) <= 0)
            return RotateLeft(node);

        if (balanceFactor < -1 && GetBalanceFactor(node.Right) > 0)
        {
            node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }

        return node;
    }
}
