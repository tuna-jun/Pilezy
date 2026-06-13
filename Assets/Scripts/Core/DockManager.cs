using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DockManager : MonoBehaviour
{
    [SerializeField] private int maxSlots = 7;

    private readonly List<Item> dockItems = new List<Item>();

    public bool IsFull => dockItems.Count >= maxSlots;

    public bool TryAddItem(Item item)
    {
        if(item == null)
        {
            return false;
        }

        if (IsFull)
        {
            Debug.Log("Dock full");
            return false;
        }
        if(dockItems.Contains(item))
        {
            Debug.Log("Item already");
            return false;
        }

        dockItems.Add(item);
        Debug.Log("Added to dock: " + item.ItemData.DisplayName);
        Debug.Log("Dock count: " + dockItems.Count);

        return true;
    }
}
