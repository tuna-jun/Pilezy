using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Pilezy/Item Data")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string itemId;
    [SerializeField] private string displayName;

    public string ItemId => itemId;
    public string DisplayName => displayName;
}
