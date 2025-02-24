using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequenceView : MonoBehaviour
{
    //Thinking: No card views? Yes, we do.
    //public SequenceData sequenceData;
    public RectTransform selfRectTransform;
    public RectTransform backgroundRectTransform;
    public List<SlotView> slots;

    public Transform slotContainer;
    public GameObject cardPrefab;
    public GameObject slotPrefab;

    public void Init(Vector2 localAnchorPosition, SequenceData sequenceData)
    {
        //this.sequenceData = sequenceData;

        //Init position
        backgroundRectTransform.anchoredPosition = localAnchorPosition;

        //Init size
        selfRectTransform.sizeDelta = new Vector2(GameDataManager.CardConfig.MainLength, GameDataManager.CardConfig.MainHeight);
        backgroundRectTransform.sizeDelta = new Vector2(backgroundRectTransform.sizeDelta.x, GameDataManager.CardConfig.MainHeight);

        for (int i = 0; i < sequenceData.CardDatas.Count; i++) 
        {
            var slot = Instantiate(slotPrefab, slotContainer).GetComponent<SlotView>();
            slots.Add(slot);
            slot.Init(this);
            var data = sequenceData.CardDatas[i];
            if (data.CardID != "Card_Empty")
            {
                var cardView = Instantiate(cardPrefab, slot.transform).GetComponent<CardView>();
                cardView.Init(slot, GameDataManager.CardData[data.CardID], data, this, null);
                cardView.GetComponent<CardDrag>().Init(GameDataManager.CardData[data.CardID].Draggable);
                slot.Init(this, cardView);
            }
            
            if (data.LinkedSequenceID != null)
            {
                localAnchorPosition.x += i * GameDataManager.CardConfig.CardSize;
                SequenceManager.Instance.GenerateSequence(localAnchorPosition, data.LinkedSequenceID);
            }
        }
    }
    public void RemoveCardView(CardView cardView)
    {
        cardView.slot.content = null;
        cardView.slot = null;
    }

    public void AddCardView(CardView cardView, SlotView slotView)
    {
        cardView.slot = slotView;
        slotView.content = cardView;
        cardView.transform.SetParent(slotView.transform);
        cardView.rectTransform.anchoredPosition = Vector2.zero;
    }
}
