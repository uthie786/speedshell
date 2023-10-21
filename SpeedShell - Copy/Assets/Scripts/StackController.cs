using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;



public class StackController<T>
{
    private const int DEFAULT_CAPACITY = 10;
    
    private T[] items;
    private int size;

    public bool IsEmpty
    {
        get { return size == 0; }
    }

    public int Size
    {
        get { return size; }
    }

    public StackController() => Empty();


    public void Empty()
    {
        items = new T[DEFAULT_CAPACITY];
        size = 0;
    }

    public T Pop()
    {
        if (size == 0)
            throw new InvalidOperationException("EMPTY");

        size--;
        return items[size];
    }

    public T Peek()
    {
        if (size == 0)
            throw new InvalidOperationException("EMPTY");

        return items[size - 1];
    }

    public void Push(T value)
    {
        if (size == items.Length)
            IncreaseCapacity();

        items[size] = value;

        size++;
    }
    
    public override string ToString()
    {
        string s = "";
        for (int i = 0; i < size; i++)
        {
            s += items[i];

            if (i < size - 1)
            {
                s += ", ";
            }
        }
        return s;
    }

    private void IncreaseCapacity()
    {
        T[] newArray = new T[items.Length * 2];
        int count = 0;

        foreach (T item in items)
        {
            newArray[count] = item;
            count++;
        }

        items = newArray;
    }
}