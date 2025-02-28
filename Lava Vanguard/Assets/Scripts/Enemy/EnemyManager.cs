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
        GameObject newEnemy = Instantiate(enemyPrefab, GetSpawnPosition(), Quaternion.identity, EnemyContainer);
        EnemyView enemyView = newEnemy.GetComponent<EnemyView>();
        enemyView.Init(enemyData);
    }

    private Vector3 GetSpawnPosition()
    {
        Camera cam = Camera.main;
        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        float buffer = 2f; // Extra distance off-screen
        int side = Random.Range(0, 4); // 0 = Left, 1 = Right, 2 = Top, 3 = Bottom

        switch (side)
        {
            case 0: // Left
                return new Vector3(-camWidth / 2 - buffer, Random.Range(-camHeight / 2, camHeight / 2), 0);
            case 1: // Right
                return new Vector3(camWidth / 2 + buffer, Random.Range(-camHeight / 2, camHeight / 2), 0);
            case 2: // Top
                return new Vector3(Random.Range(-camWidth / 2, camWidth / 2), camHeight / 2 + buffer, 0);
            case 3: // Bottom
                return new Vector3(Random.Range(-camWidth / 2, camWidth / 2), -camHeight / 2 - buffer, 0);
            default:
                return Vector3.zero;
        }
    }

    void Start()
    {
        for (int i = 0; i < 10; i++) {
            Instance.GenerateEnemy(new EnemyData {
                ID = "11",
                Name = "123",
                Health = 1,
                type = EnemyType.Flying
            });
        }
    }
}
