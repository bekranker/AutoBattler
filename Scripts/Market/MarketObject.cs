using UnityEngine;

public abstract class MarketObject : MonoBehaviour, IMarketObject
{
    [SerializeField] private float _cost;
    public void BuyMe()
    {
    }

    public void SellMe()
    {
    }
}