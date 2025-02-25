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
            BackToInventory(cardView);
            SequenceManager.Instance.Reorder();
            return;
        }
        // 2. Drag to another empty slot.
        foreach(var sequence in SequenceManager.Instance.sequenceViews)
        {
            foreach(var slot in sequence.Value.slots)
            {
                if (slot.CheckInside(rectTransform.position))
                {
                    if (slot.content == null)
                    {
                        if (cardView.cardRankData.LinkedSequenceID != null)
                        {
                            var link = cardView.cardRankData.LinkedSequenceID;
                            if (SequenceManager.Instance.sequenceViews.ContainsKey(link))
                            {
                                find = false;
                                CheckRemoveAsync(cardView, slot);
                                if (find)
                                {
                                    BackToInventory(cardView);
                                    SequenceManager.Instance.Reorder();
                                }
                                else
                                {
                                    sequence.Value.AddCardView(cardView, slot);
                                }
                            }
                            else
                            {
                                var newLink = SequenceManager.Instance.GetNextLinkedSequenceID();
                                cardView.cardRankData.LinkedSequenceID = newLink;
                                SequenceManager.Instance.GenerateAsyncSequence(slot.rectTransform.anchoredPosition, newLink, cardView.cardRankData.Level);
                                sequence.Value.AddCardView(cardView, slot);
                            }
                        }
                        else
                        {
                            sequence.Value.AddCardView(cardView, slot);
                        }
                        

                        SequenceManager.Instance.Reorder();
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
    private bool find = false;
    public void CheckRemoveAsync(CardView cardView, SlotView slotView)
    {
        if (cardView.cardRankData.LinkedSequenceID != null)
        {
            foreach(var s in SequenceManager.Instance.sequenceViews[cardView.cardRankData.LinkedSequenceID].slots)
            {
                if (s == slotView) find = true;
                if (s.content != null && s.content.cardRankData.LinkedSequenceID != null)
                    CheckRemoveAsync(s.content, slotView);
            }
        }
    }
    public void BackToInventory(CardView cardView)
    {
        InventoryManager.Instance.inventoryView.AddCardView(cardView);
        if (cardView.slot != null) 
            cardView.slot.content = null;
        cardView.slot = null;
        if (cardView.cardRankData.LinkedSequenceID != null)
        {
            
            var sequenceView = SequenceManager.Instance.sequenceViews[cardView.cardRankData.LinkedSequenceID];
            cardView.cardRankData.LinkedSequenceID = "Not_Ready";
            for (int i = 1; i < sequenceView.slots.Count; i++)
            {
                if (sequenceView.slots[i].content != null)
                {
                    BackToInventory(sequenceView.slots[i].content);
                }
            }
        }
    }
}
