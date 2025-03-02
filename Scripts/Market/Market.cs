using UnityEngine;

public class Market : MonoBehaviour
{
    [Header("----Components")]
    [SerializeField] private MoneyHandler _moneyHandler;
    [Header("----Raycast Props")]
    [SerializeField] private LayerMask _raycastLayerItems;
    [SerializeField] private LayerMask _raycastLayerCollectables;

    private IDraggable _currentDraggable;
    private RaycastHit2D _hit2D, _hit2DCollectable;

    void Update()
    {
        Collectable();
        if (_currentDraggable != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            _currentDraggable.OnDrag(mousePos);
        }
        ItemDrag();
    }

    private void ItemDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, 100, _raycastLayerItems);
            if (_hit2D.collider != null)
            {
                if (_hit2D.collider.TryGetComponent<IDraggable>(out IDraggable draggable))
                {
                    _currentDraggable = draggable;
                    _currentDraggable.OnDragStart();
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (_currentDraggable != null)
            {
                _currentDraggable.OnDragEnd();
                _currentDraggable = null;
            }
        }
    }
    private void Collectable()
    {
        _hit2DCollectable = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, 100, _raycastLayerCollectables);
        if (_hit2DCollectable.collider != null)
        {
            if (_hit2DCollectable.collider.TryGetComponent<ICollectable>(out ICollectable collectable))
            {
                collectable.CollectMe();
            }
        }
    }
}