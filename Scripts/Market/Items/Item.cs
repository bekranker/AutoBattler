using UnityEngine;

public class Item : MonoBehaviour, IDraggable
{
    public ItemSCB ItemData;

    public void OnDrag(Vector3 newPos)
    {
        transform.position = Vector3.Lerp(transform.position, newPos, DoTweenProps.Instance.ItemAimMovementSpeed * Time.deltaTime);
    }

    public void OnDragEnd()
    {
    }

    public void OnDragStart()
    {
        print("Dragging Item is Started");
    }
}