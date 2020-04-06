using System;
using System.Collections;

namespace LinkedList.Model
{
    /// <summary>
    /// Linked list
    /// </summary>
    /// <typeparam name="T">Type of items within list</typeparam>
    class LinkedList<T>: IEnumerable
    {
        /// <summary>
        /// First element of list
        /// </summary>
        public Item<T> Head { get; private set; }

        /// <summary>
        /// Last element of list
        /// </summary>
        public Item<T> Tail { get; private set; }

        /// <summary>
        /// Total list's count
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Create empty list
        /// </summary>
        public LinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0; 
        }

        /// <summary>
        /// Create list and initialize first element
        /// </summary>
        /// <param name="data">First element</param>
        public LinkedList(T data)
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }

        /// <summary>
        /// Add data to the end of the list
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            
            if (Tail != null)
            {
                var item = new Item<T>(data);
                Tail.Next = item;
                Tail = item;
                Count++;
            }
            else
            {
                SetHeadAndTail(data);
            }
        }

        /// <summary>
        /// Remove first occurence of given element
        /// </summary>
        public void Remove(T data)
        {
            if (Head != null)
            {
                if (Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    return;
                }

                var current = Head.Next;
                var previous = Head;

                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        Count--;
                        return;
                    }
                    previous = current;
                    current = current.Next;
                }

            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Insert item after target element 
        /// </summary>
        /// <param name="target">Target element</param>
        /// <param name="data">Item for insert</param>
        public void Insert(T target, T data)
        {
            if (Head != null)
            {
              
                var current = Head;
                while (current != null)
                {
                    if (current.Data.Equals(target))
                    {
                        var item = new Item<T>(data);
                        item.Next = current.Next;
                        current.Next = item;
                        Count--;
                        return;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }


            }
            else
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// Add item to the top of the list
        /// </summary>
        public void AppendHead(T data)
        {
            var item = new Item<T>(data)
            {Next = Head};
            Head = item;
            Count++;
        }

        /// <summary>
        /// Clear entire list
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        private void SetHeadAndTail(T data)
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }

        /// <summary>
        /// Iterate through the list
        /// </summary>
        /// <returns>Each element</returns>
        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
