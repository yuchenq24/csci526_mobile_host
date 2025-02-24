using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceManager : MonoBehaviour
{
    public static SequenceManager Instance { get; private set; }
    public Transform sequenceContainer;
    public GameObject sequencePrefab;
    public List<SequenceView> sequenceViews = new List<SequenceView>();
    public SequenceView MainSequence { get => sequenceViews[0]; }
    private void Awake()
    {
        Instance = this;
    }
    public void Init()
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
