using UnityEngine;

public class InventoryManager : MonoBehaviour
{

}

[System.Serializable]
public class Cell
{
    public Transform CellT;
    public bool Busy;
    public IMarketObject CurrentHoldingObject;

    public void SetCell(IMarketObject marketObject)
    {
        CurrentHoldingObject = marketObject;
    }
}