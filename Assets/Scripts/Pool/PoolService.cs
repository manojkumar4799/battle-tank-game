using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//what is where
public class PoolService<T> : GenericSingleton<PoolService<T>> where T : class
{
    private List<PoolItem<T>> poolList = new List<PoolItem<T>>();
    //need to add enemytanks to list

    public virtual T GetItem()
    {
        if (poolList.Count > 0)
        {
            PoolItem<T> Item = poolList.Find(i => i.isUsed == false);
            if (Item != null)
            {
                Item.isUsed = true;
                return Item.item;
            }
        }

        return CreatePoolItem();

    }

    private T CreatePoolItem()
    {
        PoolItem<T> newPoolItem = new PoolItem<T>();
        newPoolItem.item = CreateNewItem();
        newPoolItem.isUsed = true;
        poolList.Add(newPoolItem);
        return newPoolItem.item;
    }

    public virtual void ReturnItemToPool(T item)
    {
        PoolItem<T> returnItem = poolList.Find(i => i.item.Equals(item));
        returnItem.isUsed = false;
    }

    protected virtual T CreateNewItem()
    {
        return null;
    }

    private class PoolItem<T>
    {
        public T item;
        public bool isUsed;
    }

}


