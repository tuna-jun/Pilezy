using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DockManager : MonoBehaviour
{
    [SerializeField] private int maxSlots = 7;
    [SerializeField] private Transform[] dockSlots;

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
        item.SetInDock(true);

        RefreshDockPositions();
        CheckMatch(item);

        Debug.Log("Added to dock: " + item.ItemData.DisplayName);
        Debug.Log("Dock count: " + dockItems.Count);

        return true;
    }

    private void CheckMatch(Item addedItem)
    {
        List<Item> sameTypeItems = new List<Item>();

        for (int i = 0; i < dockItems.Count; i++)
        {
            if (dockItems[i].ItemData == addedItem.ItemData)
            {
                sameTypeItems.Add(dockItems[i]);
            }
        }
        if (sameTypeItems.Count >= 3)
        {
            RemoveMatchedItems(sameTypeItems);
        }
    }

    private void RemoveMatchedItems(List<Item> matchedItems)
    {
        for (int i = 0; i<3; i++)
        {
            Item item = matchedItems[i];

            dockItems.Remove(item);
            Destroy(item.gameObject);
        }

        RefreshDockPositions();

    }

    private void RefreshDockPositions()
    {
        for(int i = 0; i<dockItems.Count; i++)
        {
            if(i >= dockSlots.Length)
            {
                return;
            }
            MoveItemToDock(dockItems[i], i);
        }
    }

    private void MoveItemToDock(Item item, int slotIndex)
    {
        Transform targetSlot = dockSlots[slotIndex];
        item.transform.position = targetSlot.position;
        item.transform.rotation = targetSlot.rotation;
    }
}
