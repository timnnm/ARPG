using System;
using System.Collections;
using System.Collections.Generic;

//传递比较方法的代理
public delegate int ArrayCompareHandler<T>(T obj1,T obj2);

//传递比较属性的代理
public delegate RT SeclectHandler<T, RT>(T obj1);

//条件委托
public delegate bool FindHandler<T>(T obj1);
  

public static class ArrayHelper
{
    static public void OrderBy<T>(T[] array)where T:IComparable<T>
    {
        for (int i = 0; i < array.Length - 1; i++) {
            for (int j = 0; j < array.Length - i - 1; j++) {
                if (array[j].CompareTo(array[j + 1]) > 0) {
                    T item = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = item;
                }
            }
        }
    }

    static public void OrderBy<Tc>(Tc[] array, ArrayCompareHandler<Tc> compare) where Tc : IComparable<Tc>
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (compare(array[j],array[j+1]) > 0)
                {
                    Tc item = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = item;
                }
            }
        }
    }

    static public void OrderBy<T, RT>(T[] array, SeclectHandler<T, RT> shandler) where RT : IComparable<RT>
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (shandler(array[j]).CompareTo(shandler(array[j+1]))>0)
                {
                    T item = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = item;
                }
            }
        }
    }

    static public void OrderByDescending<T, RT>(T[] array, SeclectHandler<T, RT> shandler) where RT : IComparable<RT>
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (shandler(array[j]).CompareTo(shandler(array[j + 1])) < 0)
                {
                    T item = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = item;
                }
            }
        }
    }

    static public T Max<T, RT>(T[] array, SeclectHandler<T, RT> shandler) where RT : IComparable<RT>
    {
        if (array.Length > 0)
        {
            T max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (shandler(array[i]).CompareTo(shandler(max)) > 0) {
                    max = array[i];
                }
            }
            return max;
        }
        else {
            return default(T);
        }
        
    }

    static public T Min<T, RT>(T[] array, SeclectHandler<T, RT> shandler) where RT : IComparable<RT>
    {
        if (array.Length > 0)
        {
            T min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (shandler(array[i]).CompareTo(shandler(min)) < 0)
                {
                    min = array[i];
                }
            }
            return min;
        }
        else
        {
            return default(T);
        }

    }

    static public T Find<T>(T[] array, FindHandler<T> findHandler) 
    {
      
        for (int i = 0; i < array.Length; i++)
        {
            if (findHandler(array[i]))
            {
                return array[i];
            }
        }
        return default(T);
        
        
    }

    static public T[] FindAll<T>(T[] array, FindHandler<T> findHandler)
    {

        List<T> result = new List<T>();
        for (int i = 0; i < array.Length; i++)
        {
            if (findHandler(array[i]))
            {
                result.Add(array[i]);
            }
        }
        return result.ToArray();
    }

    static public RT[] Select<T, RT>(T[] array, SeclectHandler<T, RT> shandler) {

        RT[] result = new RT[array.Length];
        for (int i = 0; i < array.Length; i++) {
            result[i] = shandler(array[i]);
        }
        return result;
    }


}

