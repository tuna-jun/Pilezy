
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Pilezy/Level Data")]
public class LevelData : ScriptableObject
{
    [SerializeField] private List<LevelItemEntry> spawnItems = new List<LevelItemEntry>();
    [SerializeField] private List<LevelGoalEntry> goals = new List<LevelGoalEntry>();
    public List<LevelItemEntry> SpawnItems => spawnItems;
    public List<LevelGoalEntry> Goals => goals;
}

[Serializable]
public class LevelItemEntry
{
    [SerializeField] private Item itemPrefab;
    [SerializeField] private int count;
    public Item ItemPrefab => itemPrefab;
    public int Count => count;
}

[Serializable]
public class LevelGoalEntry
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private int requiredCount;
    public ItemData ItemData => itemData;
    public int RequiredCount => requiredCount;
}
