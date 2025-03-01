using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance {  get; private set; }
    public GameObject groundPrefab;
    public Transform groundContainer;
    public List<GameObject> grounds = new List<GameObject>();


    private static readonly int[] XStartPos = new int[2] { -8, -12 };
    private static readonly int XInterval = 8;

    public float cameraDistance = 5.0f;
    public float yGap = 1.5f;
    private float lastY;
    private int groundType = 0;
    private int typeCount = 2;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        GameObject initalGround = Instantiate(groundPrefab, new Vector3(0, -5, 0), Quaternion.identity);
        initalGround.transform.localScale = new Vector3(23f, 5f, 1f);
        lastY = -2.5f;
    }

    void Update()
    {
        if (Camera.main.transform.position.y + cameraDistance > lastY)
        {
            GenerateGround();
        }
    }

    void GenerateGround()
    {
        lastY += yGap;
        for (int i = 0; i < 3; i++)
        {
            var ground = Instantiate(groundPrefab, new Vector3(XStartPos[groundType] + i * XInterval, lastY, 0f), Quaternion.identity, groundContainer);
            grounds.Add(ground);
        }
        groundType = (groundType + 1) % typeCount;
    }

    /*void CreatePlatformWithEnemyOrNot(Vector3 position)
    {
        // generate platform
        GameObject platform = Instantiate(groundPrefab, position, Quaternion.identity);

        // 50% 
        if (Random.value < enemyRate)
        {

            float platformTopY = position.y + (platform.GetComponent<Collider2D>()?.bounds.extents.y ?? 0.5f);

            float enemyBottomOffset = enemyPrefab.GetComponent<Collider2D>()?.bounds.extents.y ?? 0.5f;

            Vector3 enemyPosition = new Vector3(position.x, platformTopY + enemyBottomOffset, position.z);

            Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
        }
    }*/
}
