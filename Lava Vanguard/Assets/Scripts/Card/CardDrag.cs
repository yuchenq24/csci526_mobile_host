using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CardView))]
public class CardDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private CardView cardView;
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 originalPosition;
    private bool draggable = true;
    private Transform originalParent;
    private Transform draggingParent;
    private void Awake()
    {
        
    }
    private void Start()
    {
        cardView = GetComponent<CardView>();
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        draggingParent = GameManager.Instance.draggingTransform;
        //originalParent = transform.parent;
    }
    public void Init(bool draggable)
    {
        this.draggable = draggable;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!draggable)
            return;
        originalParent = transform.parent;
        originalPosition = rectTransform.anchoredPosition;
        transform.SetParent(draggingParent);
        //1. Remove from original parent.
        if (cardView.slot == null)
        {
            //cardView.inventoryView.RemoveCardView(cardView);
            //cardView.inventoryView = null;
            InventoryManager.Instance.inventoryView.RemoveCardView(cardView);
        }
        else
        {
            //cardView.sequenceView.RemoveCardView(cardView);
            cardView.slot.sequenceView.RemoveCardView(cardView);
            //cardView.sequenceView = null;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!draggable)
            return;
        if (canvas == null) return;

        Vector2 delta = eventData.delta / canvas.scaleFactor;
        rectTransform.anchoredPosition += delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!draggable)
            return;
        // 1. Drag to inventory.
        if (GameDataManager.InventoryConfig.CheckInside(rectTransform.anchoredPosition))
        {
            InventoryManager.Instance.inventoryView.AddCardView(cardView);
            return;
        }
        // 2. Drag to another empty slot.
        foreach(var sequence in SequenceManager.Instance.sequenceViews)
        {
            foreach(var slot in sequence.slots)
            {
                if (slot.CheckInside(rectTransform.position))
                {
                    if (slot.content == null)
                    {
                        sequence.AddCardView(cardView, slot);

                        return;
                    }
                }
            }
        }
        // 3. Drag to another slot. Swap.
        // 4. Drag to self.
        // 5. Drag to somewhere else.
        transform.SetParent(originalParent);
        rectTransform.anchoredPosition = originalPosition;
    }
}
