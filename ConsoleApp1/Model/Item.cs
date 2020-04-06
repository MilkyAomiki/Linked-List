using System;

namespace LinkedList.Model
{
    /// <summary>
    /// Item that is storing in list
    /// </summary>
    /// <typeparam name="T">Type of item</typeparam>
    class Item<T>
    {
        private T data = default(T);

        /// <summary>
        /// Data that is storing in item
        /// </summary>
        public T Data
        {
            get => data;
            set => data = value == null ? throw new ArgumentNullException(nameof(value)) : value;
        }

        /// <summary>
        /// Next item
        /// </summary>
        public Item<T> Next { get; set; }
            
        public Item(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
