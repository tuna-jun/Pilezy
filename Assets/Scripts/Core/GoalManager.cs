
using System;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private LevelData levelData;
    [SerializeField] private UIManager uiManager;

    private readonly List<GoalEntry> goals = new List<GoalEntry>();

    private void Start()
    {
        LoadGoals();
        uiManager.UpdateGoals(goals);
    }
    public void AddClearedItems(ItemData itemData, int count)
    {
        GoalEntry goal = FindGoal(itemData);
        if (goal == null)
        {
            return;
        }

        goal.AddProgress(count);
        uiManager.UpdateGoals(goals);
        if (AreAllGoalsCompleted())
        {
            gameManager.WinGame();
        }
    }

    private void LoadGoals()
    {
        goals.Clear();

        for(int i = 0; i< levelData.Goals.Count; i++)
        {
            LevelGoalEntry entry = levelData.Goals[i];
            goals.Add(new GoalEntry(entry.ItemData, entry.RequiredCount));
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
    private ItemData itemData;
    private int requiredCount;
    private int currentCount;

    public ItemData ItemData => itemData;
    public int RequiredCount => requiredCount;
    public int CurrentCount => currentCount;
    public bool IsCompleted => currentCount >= requiredCount;

    public GoalEntry(ItemData itemData, int requiredCount)
    {
        this.itemData = itemData;
        this.requiredCount = requiredCount;
        currentCount = 0;
    }

    public void AddProgress(int count)
    {
        currentCount += count;
        if(currentCount > requiredCount)
        {
            currentCount = requiredCount;
        }
    }
}
