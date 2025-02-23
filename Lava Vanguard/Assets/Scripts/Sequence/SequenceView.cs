using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceView : MonoBehaviour
{
    public SequenceModel sequenceModel;
    public RectTransform rectTransform;
    public Transform cardContainer;
    public GameObject cardPrefab;

    public void Init(Vector2 localAnchorPosition, SequenceModel sequenceModel)
    {
        rectTransform = GetComponent<RectTransform>();
        this.sequenceModel = sequenceModel;

        //Init position
        rectTransform.anchoredPosition = localAnchorPosition;
        for (int i=0;i<sequenceModel.CardDatas.Count;i++) 
        {
            var cardModel = sequenceModel.CardDatas[i];
            var cardView = Instantiate(cardPrefab, cardContainer).GetComponent<CardView>();
            cardView.Init(GameDataManager.CardData[cardModel.ID]);
            if (cardModel.LinkedSequenceID != null)
            {
                //TODO: Not hardcode
                localAnchorPosition.x += i * 120;
                localAnchorPosition.y -= 160;
                GameManager.Instance.GenerateSequence(localAnchorPosition, cardModel.LinkedSequenceID);
            }
        }
    }
}
