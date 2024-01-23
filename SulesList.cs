using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_London_Underground_Ticketing_System
{
    internal class SulesList<T>
    {
        // Private fields
        private T[] data; // The internal array that stores the data
        private int count; // The number of elements in the list
        private int capacity; // The maximum size of the internal array

        // Public properties
        public int Count // The number of elements in the list
        {
            get { return count; }
        }

        public int Capacity // The maximum size of the internal array
        {
            get { return capacity; }
        }

        // Indexer
        public T this[int index] // Allows accessing the list elements by index
        {
            get
            {
                // Check if the index is valid
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException();
                }
                // Return the element at the given index
                return data[index];
            }
            set
            {
                // Check if the index is valid
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException();
                }
                // Set the element at the given index
                data[index] = value;
            }
        }

        // Constructor
        public SulesList(int initialCapacity = 4) // Creates a new list with an optional initial capacity
        {
            // Check if the initial capacity is positive
            if (initialCapacity <= 0)
            {
                throw new ArgumentException("Capacity must be positive");
            }
            // Initialize the fields
            data = new T[initialCapacity];
            count = 0;
            capacity = initialCapacity;
        }

        // Methods
        public void Add(T item) // Adds a new item to the end of the list
        {
            // Check if the list is full
            if (count == capacity)
            {
                // Double the capacity of the internal array
                capacity *= 2;
                // Create a new array with the new capacity
                T[] newData = new T[capacity];
                // Copy the existing elements to the new array
                for (int i = 0; i < count; i++)
                {
                    newData[i] = data[i];
                }
                // Replace the old array with the new array
                data = newData;
            }
            // Add the item to the end of the list
            data[count] = item;
            // Increment the count
            count++;
        }

        public void RemoveAt(int index) // Removes the item at the given index from the list
        {
            // Check if the index is valid
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }
            // Shift the elements after the index to the left by one position
            for (int i = index; i < count - 1; i++)
            {
                data[i] = data[i + 1];
            }
            // Decrement the count
            count--;
        }

        public void Clear() // Removes all the items from the list
        {
            // Reset the count
            count = 0;
        }

        public bool Contains(T item) // Returns true if the list contains the given item, false otherwise
        {
            // Loop through the list elements
            for (int i = 0; i < count; i++)
            {
                // Check if the current element is equal to the item
                if (data[i].Equals(item))
                {
                    // Return true
                    return true;
                }
            }
            // Return false
            return false;
        }

        public int IndexOf(T item) // Returns the index of the first occurrence of the given item in the list, or -1 if not found
        {
            // Loop through the list elements
            for (int i = 0; i < count; i++)
            {
                // Check if the current element is equal to the item
                if (data[i].Equals(item))
                {
                    // Return the index
                    return i;
                }
            }
            // Return -1
            return -1;
        }

        public void Insert(int index, T item) // Inserts a new item at the given index in the list
        {
            // Check if the index is valid
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException();
            }
            // Check if the list is full
            if (count == capacity)
            {
                // Double the capacity of the internal array
                capacity *= 2;
                // Create a new array with the new capacity
                T[] newData = new T[capacity];
                // Copy the existing elements to the new array
                for (int i = 0; i < count; i++)
                {
                    newData[i] = data[i];
                }
                // Replace the old array with the new array
                data = newData;
            }
            // Shift the elements after the index to the right by one position
            for (int i = count; i > index; i--)
            {
                data[i] = data[i - 1];
            }
            // Insert the item at the given index
            data[index] = item;
            // Increment the count
            count++;
        }

        public void Remove(T item) // Removes the first occurrence of the given item from the list
        {
            // Find the index of the item
            int index = IndexOf(item);
            // Check if the item was found
            if (index != -1)
            {
                // Remove the item at the index
                RemoveAt(index);
            }
        }

        public T[] ToArray() // Returns a new array containing the elements of the list
        {
            // Create a new array with the same size as the count
            T[] array = new T[count];
            // Copy the list elements to the new array
            for (int i = 0; i < count; i++)
            {
                array[i] = data[i];
            }
            // Return the new array
            return array;
        }
    }
}
