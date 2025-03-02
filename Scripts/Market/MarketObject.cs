using DG.Tweening;
using TMPro;
using UnityEngine;

public abstract class MarketObject : MonoBehaviour, IMarketObject, IDraggable
{
    [SerializeField] private float _cost;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private TMP_Text _costText;

    private Vector3 _initialPosition;
    public ItemSCB ItemData { get; set; }

    public void BuyMe()
    {
    }

    public void Init()
    {
        _initialPosition = transform.position;
        DOTween.Kill(transform);
        transform.DOPunchScale(DoTweenProps.Instance.PunchScale, DoTweenProps.Instance.PunchDuration);
        _costText.text = ItemData.Cost.ToString();
        _spriteRenderer.sprite = ItemData.ItemSprite;
    }

    public void SellMe()
    {
    }
    public void OnDrag(Vector3 newPos)
    {
        transform.position = Vector3.Lerp(transform.position, newPos, DoTweenProps.Instance.ItemAimMovementSpeed * Time.deltaTime);
    }

    public void OnDragEnd(Cell cell)
    {
        if (cell == null)
        {
            DOTween.Kill(transform);
            transform.DOMove(_initialPosition, DoTweenProps.Instance.MoveSpeed).SetEase(Ease.Linear);
            return;
        }
        transform.DOMove(cell.CellT.position, DoTweenProps.Instance.MoveSpeed).SetEase(Ease.Linear);
    }

    public void OnDragStart()
    {
        print("Dragging Item is Started");
    }
}