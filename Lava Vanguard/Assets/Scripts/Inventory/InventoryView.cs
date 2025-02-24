using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    //Thinking: no card views?
    public InventoryData inventoryData;
    public RectTransform inventoryRectTransform;
    public GridLayoutGroup gridLayoutGroup;

    public Transform cardContainer;
    public GameObject cardPrefab;
    public void Init()
    {
        //Init position and size
        inventoryRectTransform.anchoredPosition = GameDataManager.InventoryConfig.Center;
        inventoryRectTransform.sizeDelta = GameDataManager.InventoryConfig.Size;

        gridLayoutGroup.cellSize = Vector2.one * GameDataManager.CardConfig.CardSize;

        inventoryData = GameDataManager.InventoryData;
        for (int i = 0; i < inventoryData.CardDatas.Count; i++)
        {
            var data = inventoryData.CardDatas[i];
            if (data.CardID != "Card_Empty")
            {
                var cardView = Instantiate(cardPrefab, cardContainer).GetComponent<CardView>();
                cardView.Init(null, GameDataManager.CardData[data.CardID], data, null, this);
                cardView.GetComponent<CardDrag>().Init(GameDataManager.CardData[data.CardID].Draggable);
            }
        }
    }
    public void RemoveCardView(CardView cardView)
    {
        inventoryData.CardDatas.RemoveAll(a => a.ID == cardView.cardRankData.ID);
    }
    public void AddCardView(CardView cardView)
    {
        cardView.transform.SetParent(inventoryRectTransform);
        //cardView.inventoryView = this;
        inventoryData.CardDatas.Add(cardView.cardRankData);
    }
}
