using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    public CardModel cardModel;
    public Image background;
    public Image outline;
    public Image content;
    public void Init(CardModel cardModel)//Consider using inheritance and other data like atk.
    {
        this.cardModel = cardModel;
        background.sprite = GameDataManager.BackgroundSprite[cardModel.Background];
        outline.sprite = GameDataManager.OutlineSprite[cardModel.Outline];
        content.sprite = GameDataManager.ContentSprite[cardModel.Content];
    }
}
