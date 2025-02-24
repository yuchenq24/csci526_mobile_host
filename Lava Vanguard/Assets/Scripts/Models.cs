using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
