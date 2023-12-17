using System;
using System.Collections;
using System.Collections.Generic;

public class MyList<T> : IEnumerable<T>
{
    private T[] items;
    private int count;



    public MyList()
    {
        items = new T[0];
        count = 0;
    }

    public MyList(params T[] initialValues)
    {
        items = new T[initialValues.Length];
        Array.Copy(initialValues, items, initialValues.Length);
        count = initialValues.Length;
    }

    public MyList(IEnumerable<T> collection)
    {
        items = new T[0];
        foreach (var item in collection)
        {
            Add(item);
        }
    }

    public void Add(T item)
    {
        if (count == items.Length)
        {
            int newCapacity = count == 0 ? 4 : count * 2;
            T[] newItems = new T[newCapacity];
            Array.Copy(items, newItems, count);
            items = newItems;
        }

        items[count] = item;
        count++;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            return items[index];
        }
    }

    public int Count
    {
        get { return items.Length; }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < count; i++)
        {
            yield return items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class lab_05_2
{
    static void Main()
    {
        MyList<int> myList = new MyList<int> { 1, 2, 3, 4, 5 };


        Console.WriteLine($"\nОбщее количество элементов: {myList.Count}");

        int Capasity = 0;


        for (int i = 0; i < 100; i++)
        {
            myList.Add(i);
            if (myList.Count != Capasity)
            {
                Console.WriteLine($"\nОбщее количество элементов: {myList.Count}");
                Capasity = myList.Count;
            }


        }

        Console.WriteLine($"Ваш элемент i - 1:\n");
        foreach (var item in myList)
        {
            Console.WriteLine($"Элемент: {item}");
        }

        //foreach (var item in myList)
        //{
        //    for (int i = 0; i < 1000000; ++i)
        //    {
        //        myList.Add(i);
        //    }
        //    if (myList.Count == 5)
        //    {
        //        Console.WriteLine("Количетсво элементов не изменилось");
        //    }
        //    else Console.WriteLine("Количетсво элементов  изменилось");

        Console.WriteLine($"\nОбщее количество элементов: {myList.Count}");
    }
}
