using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedItem = eventData.pointerDrag;
        if (droppedItem != null)
        {
            droppedItem.transform.SetParent(transform); 
            droppedItem.transform.position = transform.position; 
        }
    }
}
