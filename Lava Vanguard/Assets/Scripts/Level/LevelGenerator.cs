using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance {  get; private set; }
    public GameObject groundPrefab;
    public GameObject lavaPrefab;
    public GameObject wallPrefab;
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
        Instantiate(wallPrefab, new Vector3(-17f, 0f, 0f), Quaternion.identity);
        Instantiate(wallPrefab, new Vector3(17f, 0f, 0f), Quaternion.identity);
        GameObject upWall=Instantiate(wallPrefab, new Vector3(0f, 8f, 0f), Quaternion.identity);
        upWall.transform.localScale = new Vector3(32f, 4f, 1f);

        Instantiate(lavaPrefab, new Vector3(0f, -5f, 0f), Quaternion.identity);
        GameObject initalGround = Instantiate(groundPrefab, new Vector3(0, -5, 0), Quaternion.identity);
        initalGround.transform.localScale = new Vector3(30f, 5f, 1f);
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
        if(groundType==0){
            for (int i = 0; i < 3; i++)
            {
                var ground = Instantiate(groundPrefab, new Vector3(XStartPos[groundType] + i * XInterval, lastY, 0f), Quaternion.identity, groundContainer);
                grounds.Add(ground);
            }
        }
        else if(groundType==1){
            for (int i = 0; i < 4; i++)
            {
                var ground = Instantiate(groundPrefab, new Vector3(XStartPos[groundType] + i * XInterval, lastY, 0f), Quaternion.identity, groundContainer);
                grounds.Add(ground);
            }
        }

        groundType = (groundType + 1) % typeCount;
    }
}
