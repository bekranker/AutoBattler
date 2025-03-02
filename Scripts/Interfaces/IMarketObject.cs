public interface IMarketObject
{
    ItemSCB ItemData { get; set; }
    void Init();
    void BuyMe();
    void SellMe();
}