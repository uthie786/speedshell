using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public class HashMap<TKey, TValue>  where TKey : IComparable
{
    const int DEFAULT_INITIAL_SIZE = 10;
    const float LOAD_FACTOR = 0.8F;

    private int size = 0;

    List<KeyValuePair<TKey, TValue>>[] items;

    public TValue this[TKey key]
    {
        get { return Get(key); }
        set { Add(key, value); }
    }


    public HashMap()
    {
        items = new List<KeyValuePair<TKey, TValue>>[DEFAULT_INITIAL_SIZE];
    }

    public HashMap(int initialSize)
    {
        items = new List<KeyValuePair<TKey, TValue>>[initialSize];
    }

    public void Add(TKey key, TValue value)
    {
        int index = GetIndex(key);

        if (items[index] is null)
            items[index] = new List<KeyValuePair<TKey, TValue>>();

        items[index].Add(new KeyValuePair<TKey, TValue>(key, value));

        size++;
        ResizeIfNeeded();
    }


    public bool Remove(TKey key)
    {
        int index = GetIndex(key);

        if (items[index] is null)
            return false;

        for(int i = 0; i < items[index].Count; i++)
            if (key.CompareTo(items[index][i].Key) == 0)
            {
                items[index].RemoveAt(i);
                size--;
                return true;
            }

        return false;
                
    }


    public TValue Get(TKey key)
    {
        int index = GetIndex(key);


        if (items[index] is null)
            return default(TValue);

        for (int i = 0; i < items[index].Count; i++)
            if (key.CompareTo(items[index][i].Key) == 0)
            {
                return items[index][i].Value;
            }

        return default(TValue);
    }


    private int GetIndex(TKey key)
    {
        return Math.Abs(key.GetHashCode()) % items.Length;
    }

    public override string ToString()
    {
        string info = "";
        for (int i = 0; i < items.Length; i++)
        {
            info += i + ": ";

            if (items[i] != null)
            {
                foreach (KeyValuePair<TKey, TValue> pair in items[i])
                {
                    info += pair.Key.ToString() + ", ";
                }
            }
            info += "\n";
        }
        return info;
    }

    private void ResizeIfNeeded()
    {
        if (size < items.Length * LOAD_FACTOR)
            return;

        var oldItems = items;
        items = new List<KeyValuePair<TKey, TValue>>[oldItems.Length * 2];

        for(int i = 0; i < oldItems.Length; i++)
        {
            if (oldItems[i] is null)
                continue;

            var chain = oldItems[i];
            foreach(var pair in chain)
            {
                int index = GetIndex(pair.Key);

                if (items[index] is null)
                {
                    items[index] = new List<KeyValuePair<TKey, TValue>>();
                }

                items[index].Add(pair);
            }
        }
    }

    public bool Contains(TKey key)
    {
        int index = GetIndex(key);

        if (items[index] is null)
            return false;

        foreach (KeyValuePair<TKey, TValue> pair in items[index])
            if (key.CompareTo(pair.Key) == 0)
                return true;

        return false;
    }
}
