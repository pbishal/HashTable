using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    /// <summary>
    /// MyMapNode class with key value
    /// And creating linked list which take key and value
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    class MyMapNode<K, V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];

        }

        /// <summary>
        /// Adding elements
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
            linkedList.AddLast(item);
        }

        /// <summary>
        /// Find frequency of word
        /// </summary>
        /// <param name="key"></param>
        public void frequencyOfWords(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    foundItem = item;
                    string str = foundItem.Value.ToString();
                    Console.WriteLine("Founded data are  =  " + str);
                    string[] arr = str.Split();
                    Dictionary<string, int> dict = new Dictionary<string, int>();
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (dict.ContainsKey(arr[i]))
                        {
                            dict[arr[i]] = dict[arr[i]] + 1;
                        }
                        else
                        {
                            dict.Add(arr[i], 1);
                        }
                    }
                    foreach (KeyValuePair<String, int> entry in dict)
                    {
                        Console.WriteLine(entry.Key + " - " +
                                          entry.Value);
                    }
                }
            }
        }

        /// <summary>
        /// Deletion using key
        /// </summary>
        /// <param name="key"></param>
        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }

        /// <summary>
        /// Get key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }


        protected int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }
    }

    public class KeyValue<k, v>
    {
        public k Key { get; set; }
        public v Value { get; set; }

    }
}

