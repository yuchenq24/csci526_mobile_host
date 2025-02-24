using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Just for temp testing
public class GameManager : MonoBehaviour
{

    public Transform draggingTransform;
    
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this; 
    }
    private void Start()
    {
        SequenceManager.Instance.Init();
        InventoryManager.Instance.Init();
    }

}
