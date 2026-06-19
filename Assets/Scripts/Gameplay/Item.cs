using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color selectedColor = Color.red;

    private bool isInDock;
    public ItemData ItemData => itemData;
    public bool IsInDock => isInDock;

    private void Awake()
    {
        if (meshRenderer == null)
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }
        SetSelected(false);
    }

    public void SetSelected(bool isSelected)
    {
        if (meshRenderer == null)
        {
            return;
        }
        meshRenderer.material.color = isSelected ? selectedColor : normalColor;
    }

    public void SetInDock(bool value)
    {
        isInDock = value;
    }
}
