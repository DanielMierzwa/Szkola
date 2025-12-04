using CollectionsChat.Shared.Collections.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsChat.Shared.Collections
{
    public class SmartLinkedList<T> : ISmartLinkedList<T>
    {
        private Node? _head; // <-- pierwszy element listy
        private Node? _tail; // <-- ostatni element listy
        private int _count; // <-- liczba elementów w liście
        public int Count => _count;

        public void AddFirst(T item)
        {
            var node = new Node(item)
            {
                Next = _head
            };

            _head = node;
            _tail ??= node; // <-- uprzedzam pytanie, ten operator był omawiany na zajęciach
            _count++;
        }

        public void AddLast(T item)
        {
            var node = new Node(item);
            if (_tail is null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _tail.Next = node;
                _tail = node;
            }

            _count++;
        }

        public void Clear()
        {
            _head= null;
            _tail= null;
            _count= 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            Node? previous = null;
            var current = _head;
            while (current != null)
            {
                if (Equals(current.Value, item))
                {
                    if (previous == null)
                    {
                        _head = current.Next;
                    }

                    else
                    {
                        previous.Next = current.Next;
                    }

                    if (current == _tail)
                    {
                        _tail = previous;
                    }

                    _count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public T? RemoveFirst()
        {
            if(_tail is null)
            {
                _tail= null;
                _head= null;
                return default;
            }
            //else
            _head = _head.Next;
            return default;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class Node
        {
            public T Value;
            public Node? Next;

            public Node(T value) => Value = value;
        }
    }
}
