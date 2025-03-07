using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Async
{
    public struct CardSpriteData
    {
        public string ID { get; set; }
        public string Background { get; set; }
        public string Outline { get; set; }
        public string Content { get; set; }
        public bool Draggable { get; set; }
    }
    public struct CardRankData
    {
        public string ID { get; set; }
        public string CardID { get; set; }
        public int Level { get; set; }
        public string LinkedSequenceID { get; set; }
        public CardRankData(string ID, string CardID, int Level) : this()
        {
            this.ID = ID;
            this.CardID = CardID;
            this.Level = Level;
        }
        public static CardRankData AsyncHead
        {
            get =>
                new CardRankData(ID: "0", CardID: "Card_Async", Level: 1);
        }
        public static CardRankData Bullet01
        {
            get =>
                new CardRankData(ID: "0", CardID: "Bullet_01", Level: 1);
        }
        public static CardRankData Bullet02
        {
            get =>
                new CardRankData(ID: "0", CardID: "Bullet_02", Level: 1);
        }
        public static CardRankData Bullet03
        {
            get =>
                new CardRankData(ID: "0", CardID: "Bullet_03", Level: 1);
        }
        public static CardRankData Empty
        {
            get =>
                new CardRankData(ID: "0", CardID: "Card_Empty", Level: 1);
        }
    }
    public struct SequenceData
    {
        public string ID { get; set; }
        public List<CardRankData> CardDatas { get; set; }
    }
    public struct InventoryData
    {
        public List<CardRankData> CardDatas { get; set; }
    }

}
