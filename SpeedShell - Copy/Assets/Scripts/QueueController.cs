using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueues
{
    public class QueueLinked<T> where T : IComparable                                   //DO NOT TOUCH THIS
    {
        
        private Node<T> front;
        private Node<T> back;

        private int size = 0;
        public QueueLinked()
        {

            Empty();
        }

        public bool IsEmpty { get { return size == 0; } }
        public int Size { get { return size; } }
        public void Enqueue(T value)
        {
            Node<T> a = back.prev;
            Node<T> c = back;

            Node<T> b = new Node<T>(value, a, c);

            a.next = b;
            c.prev = b;
            size++;

        }
        public T Dequeue()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Array Is Empty");
            }

            T value = front.value;
            front = front.next;
            size--;

            return value;
        }

        public void Empty()
        {
            front = new Node<T>(default, null, null);
            back = new Node<T>(default, null, null);

            front.next = back;
            back.prev = front;

            size = 0;
        }
        private class Node<X>
        {
            public X value;

            public Node<X> prev;
            public Node<X> next;


            public Node(X value, Node<X> prev, Node<X> next)
            {
                this.value = value;
                this.next = next;
                this.prev = prev;

            }

        }
        public override string ToString()
        {
            string s = "";

            Node<T> nodes = front;

            for (int i = 0;i < size;i++)
            {
                nodes = nodes.next;

                s += nodes.value;

                if (i < size-1)
                {
                    s += ", ";

                }
            }
            return s;
        }
    }
}