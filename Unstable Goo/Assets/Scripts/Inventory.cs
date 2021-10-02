using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    const int MAX_COUNT = 2;

    List<GameObject> items;
    void Start()
    {
        items = new List<GameObject>();
    }

    public bool HasCapacity() 
    {
        return items.Count < MAX_COUNT;
    }

    public void Add(GameObject item) 
    {
        if (item == null) {
            print("NULL ITEM");
        }
        items.Add(item);
        print(items.Count);
    }

    public void Pop(int index) 
    {
        items.RemoveAt(index);
    }

    public GameObject this[int key]
    {
        get => items[key];
    }

    public int Count() 
    {
        return items.Count;
    }
}
