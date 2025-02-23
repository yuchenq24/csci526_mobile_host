using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Just for temp testing
public class GameManager : MonoBehaviour
{
    public Transform sequenceContainer;
    public GameObject sequencePrefab;
    public List<SequenceView> sequenceViews = new List<SequenceView>();
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this; 
    }
    private void Start()
    {
        GenerateSequence(Vector2.zero, "Sequence_Main");
    }
    public void GenerateSequence(Vector2 localAnchorPosition, string sequenceID)
    {
        var sequenceData = GameDataManager.SequenceData[sequenceID];
        var sequenceView = Instantiate(sequencePrefab, sequenceContainer).GetComponent<SequenceView>();
        sequenceView.Init(localAnchorPosition, sequenceData);
        sequenceViews.Add(sequenceView);
    }
}
