
using System;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private List<GoalEntry> goals = new List<GoalEntry>();

    public void AddClearedItems(ItemData itemData, int count)
    {
        GoalEntry goal = FindGoal(itemData);
        if (goal == null)
        {
            return;
        }

        goal.AddProgress(count);
        if (AreAllGoalsCompleted())
        {
            gameManager.WinGame();
        }
    }

    private GoalEntry FindGoal (ItemData itemData)
    {
        for(int i = 0; i < goals.Count; i++)
        {
            if (goals[i].ItemData == itemData)
            {
                return goals[i];
            }
        }
        return null;
    }

    private bool AreAllGoalsCompleted()
    {
        for(int i = 0; i < goals.Count; i++)
        {
            if (!goals[i].IsCompleted)
            {
                return false;
            }
        }
        return true;
    }
}
[Serializable]
public class GoalEntry
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private int requiredCount;
    [SerializeField] private int currentCount;

    public ItemData ItemData => itemData;
    public int RequiredCount => requiredCount;
    public int CurrentCount => currentCount;
    public bool IsCompleted => currentCount >= requiredCount;

    public void AddProgress(int count)
    {
        currentCount += count;
        if(currentCount > requiredCount)
        {
            currentCount = requiredCount;
        }
    }
}
