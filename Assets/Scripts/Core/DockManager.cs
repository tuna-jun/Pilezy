using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DockManager : MonoBehaviour
{
    [SerializeField] private int maxSlots = 7;
    [SerializeField] private Transform[] dockSlots;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GoalManager goalManager;
    [SerializeField] private UIManager uiManager;

    private readonly List<Item> dockItems = new List<Item>();

    public bool IsFull => dockItems.Count >= maxSlots;

    private void Start()
    {
        uiManager.UpdateDockCount(dockItems.Count, maxSlots);
    }
    public bool TryAddItem(Item item)
    {
        if(item == null)
        {
            return false;
        }

        if (IsFull)
        {
            return false;
        }
        if(dockItems.Contains(item))
        {
            return false;
        }

        dockItems.Add(item);
        item.SetInDock(true);

        RefreshDockPositions();
        uiManager.UpdateDockCount(dockItems.Count, maxSlots);

        bool hasMatch = CheckMatch(item);
        if(!hasMatch && IsFull)
        {
            gameManager.LoseGame();
        }

        Debug.Log("Added to dock: " + item.ItemData.DisplayName);
        Debug.Log("Dock count: " + dockItems.Count);

        return true;
    }

    private bool CheckMatch(Item addedItem)
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
            return true;
        }
        return false;
    }

    private void RemoveMatchedItems(List<Item> matchedItems)
    {
        ItemData matchedItemData = matchedItems[0].ItemData;

        for (int i = 0; i<3; i++)
        {
            Item item = matchedItems[i];

            dockItems.Remove(item);
            Destroy(item.gameObject);
        }

        goalManager.AddClearedItems(matchedItemData, 3);

        RefreshDockPositions();
        uiManager.UpdateDockCount(dockItems.Count, maxSlots);
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
