using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private Item currentSelectedItem;

    private void Update()
    {
        if (Pointer.current != null && Pointer.current.press.wasPressedThisFrame)
        {
            TrySelectItem(Pointer.current.position.ReadValue());
        }
    }

    private void TrySelectItem(Vector2 screenPosition)
    {

        Ray ray = mainCamera.ScreenPointToRay(screenPosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {

            Item item = hit.collider.GetComponent<Item>();

            if (item != null)
            {
                SelectItem(item);
            }
        }
    }
    private void SelectItem(Item item)
    {
        if(currentSelectedItem != null)
        {
            currentSelectedItem.SetSelected(false);
        }
        currentSelectedItem = item;
        currentSelectedItem.SetSelected(true);
    }
}