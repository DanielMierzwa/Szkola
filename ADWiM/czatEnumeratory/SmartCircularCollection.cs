using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionsChat.Shared.Collections.Interfaces;

namespace CollectionsChat.Shared.Collections
{
    public class SmartCircularCollection<T> : ISmartCircularCollection<T>
    {

        private readonly T[] _items; // tablica na elementy
        private int _count;          // ile elementów jest aktualnie w kolekcji
        private int _startIndex;     // indeks najstarszego elementu w tablicy

        public int Capacity {get;}
        public int Count => _count;

        public T this[int index] 
        {
            get
            {
                if (index < 0 || index >= _count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Indeks poza zakresem kolekcji.");
                }

                var physicalIndex = (_startIndex + index) % Capacity;
                return _items[physicalIndex];
            }
            set
            {
                if (index < 0 || index >= _count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Indeks poza zakresem kolekcji.");
                }

                var physicalIndex = (_startIndex + index) % Capacity;
                _items[physicalIndex] = value;
            }
        }

        public SmartCircularCollection(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Pojemność musi być dodatnia.");
            }

            Capacity = capacity;
            _items = new T[capacity];
            _count = 0;
            _startIndex = 0;
        }

        public void Add(T item)
        {
            if (_count < Capacity)
            {
                var index = (_startIndex + _count) % Capacity;
                _items[index] = item;
                _count++;
            }

            else
            {
                var overwritten = _items[_startIndex];
                _items[_startIndex] = item;
                _startIndex = (_startIndex + 1) % Capacity;
            }
        }

        public void Clear()
        {
            for(int i = 0; i < _count; i++)
            {
                _items[i] = default!;
            }
            _count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                var physicalIndex = (_startIndex + i) % Capacity;
                yield return _items[physicalIndex];
            }
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                var physicalIndex = (_startIndex + i) % Capacity;
                if (Equals(_items[physicalIndex], item))
                {
                    // przesuwamy elementy aby zachować kolejność w buforze
                    for (int j = i; j < _count - 1; j++)
                    {
                        var fromIndex = (_startIndex + j + 1) % Capacity;
                        var toIndex = (_startIndex + j) % Capacity;
                        _items[toIndex] = _items[fromIndex];
                    }

                    var removeIndex = (_startIndex + _count - 1) % Capacity;
                    _items[removeIndex] = default!;
                    _count--;
                    return true;
                }
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
