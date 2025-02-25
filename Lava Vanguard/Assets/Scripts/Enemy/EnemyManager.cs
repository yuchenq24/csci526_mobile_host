using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform EnemyContainer;
    public GameObject enemyPrefab;
    public static EnemyManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public void GenerateEnemy(EnemyData enemyData)
    {

    }
    
}
