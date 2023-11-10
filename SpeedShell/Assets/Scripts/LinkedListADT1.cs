using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedListadt1<T> 
{
    private int size = 0;
    private Node<T> head;
    private Node<T> tail;

    public LinkedListadt1()
    {
        Empty();
    }

    public T this[int i]
        {
            get
            {
                return FindAt(i);
            }
            set
            {
                SetAt(value, i);
            }
        }

        public int Size
        {
            get { return size; }
        }

        public void Empty()
        {
            head = new Node<T>(default, null, null);
            tail = new Node<T>(default, null, null);
            head.next = tail;
            tail.prev = head;

            size = 0;


        }
        private void InsertNodeBefore(Node<T> node, T value)
        {
            Node<T> a = node.prev;
            Node<T> c = node;
            Node<T> b = new Node<T>(value, a, c);
            a.next = b;
            c.prev = b;

            size++;
        }

        private T RemoveNode(Node<T> node)
        {

            Node<T> b = node;
            Node<T> a = b.prev;
            Node<T> c = b.next;


            a.next = c;
            c.prev = a;

            size--;
            return b.value;
        }

        public T FindAt(int index)
        {
            return FindNode(index).value;
        }

        public void InsertAt(T value, int index)
        {
            InsertNodeBefore(FindNode(index), value);
        }

        public T RemoveAt(int index)
        {
            return RemoveNode(FindNode(index));
        }
        private Node<T> FindNode(int index)
        {

            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException();
            }

            /*
        Node<T> current = head;
        for (int i = 0;i < size; i++) 
        {
            if (i == index) 
            {
                return current;
            }
            current = current.next;
        }

        return default;
        */

            Node<T> node;
            if (index < size / 2)
            {
                node = head;
                for (int i = 0; i <= index; i++)
                {
                    node = node.next;
                }
            }
            else
            {
                node = tail;
                for (int i = size - 1; i >= index; i--)
                {
                    node = node.prev;
                }

            }
            return node;
        }
        public void SetAt(T value, int index)
        {
            FindNode(index).value = value;
        }

        public void Insert(T value)
        {
            InsertNodeBefore(tail, value);
        }

        public T Remove(T value)
        {
            Node<T> node = head;
            for(int i = 0; i < size; i++)
            {
                node = node.next;
                if(node.value.Equals(value))
                {
                    return RemoveNode(node);
                }
            }
            return default;
        }

        public override string ToString()
        {
            string s = "";
            Node<T> node = head;
            for (int i = 0; i < size; i++)
            {
                node = node.next;
                s += node.value;
                if (i < size - 1)
                {
                    s += ", ";
                }
            }
            return s;
        }

        private class Node<X>
        {
            public X value;
            public Node<X> prev;
            public Node<X> next;

            public Node(X value,Node<X> prev, Node<X> next)
            {
                this.value = value;
                this.next = next;
                this.prev = prev;
            
            }
        }
}
 