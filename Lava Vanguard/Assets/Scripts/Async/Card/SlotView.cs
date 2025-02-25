using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Async
{

    public class SlotView : MonoBehaviour
    {
        public SequenceView sequenceView;
        public CardView content;
        public RectTransform rectTransform;
        public void Init(SequenceView sequenceView, CardView content = null)
        {
            this.sequenceView = sequenceView;
            this.content = content;
            rectTransform = GetComponent<RectTransform>();
            rectTransform.sizeDelta = Vector2.one * GameDataManager.CardConfig.CardSize;
        }
        public bool CheckInside(Vector2 position)
        {
            Vector2 center = rectTransform.position;
            var size = rectTransform.sizeDelta;
            var leftBottom = center - size / 2;
            var rightTop = center + size / 2;
            if (position.x >= leftBottom.x && position.x <= rightTop.x &&
                position.y >= leftBottom.y && position.y <= rightTop.y)
                return true;
            else
                return false;
        }
    }
}