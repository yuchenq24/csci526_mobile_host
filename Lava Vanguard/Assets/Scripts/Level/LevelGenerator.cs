using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject playerPrefab;
    public float cameraDistance=5.0f;
    public float yGap=1.5f;
    private float lastY;
    private int groundType=0;
    private int typeCount=2;
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GameObject initGround=Instantiate(groundPrefab, new Vector3(0,-5,0), Quaternion.identity);
        initGround.transform.localScale = new Vector3(23f, 5f, 1f);
        //Instantiate(playerPrefab, new Vector3(-1f,-2f,0f), Quaternion.identity);
        lastY = -2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.transform.position.y + cameraDistance > lastY){
            GenerateGround();
        }
    }

    void GenerateGround(){
        if(groundType==0){
            GenerateGroundType0();
        }
        else if(groundType==1){
            GenerateGroundType1();
        }
    }

    void GenerateGroundType0(){
        lastY+=yGap;
        Instantiate(groundPrefab, new Vector3(-8f,lastY,0f), Quaternion.identity);
        Instantiate(groundPrefab, new Vector3(0f,lastY,0f), Quaternion.identity);
        Instantiate(groundPrefab, new Vector3(8f,lastY,0f), Quaternion.identity);
        groundType=(groundType+1)%typeCount;
    }
    /*
    void GenerateGroundType1(){
        lastY+=yGap;
        Instantiate(groundPrefab, new Vector3(-12f,lastY,0f), Quaternion.identity);
        Instantiate(groundPrefab, new Vector3(-4f,lastY,0f), Quaternion.identity);
        Instantiate(groundPrefab, new Vector3(4f,lastY,0f), Quaternion.identity);
        Instantiate(groundPrefab, new Vector3(12f,lastY,0f), Quaternion.identity);
        groundType=(groundType+1)%typeCount;
    }*/
    void GenerateGroundType1()
    {
        lastY += yGap;

        // 
        CreatePlatformWithEnemy(new Vector3(-12f, lastY, 0f));
        CreatePlatformWithEnemy(new Vector3(-4f, lastY, 0f));
        CreatePlatformWithEnemy(new Vector3(4f, lastY, 0f));
        CreatePlatformWithEnemy(new Vector3(12f, lastY, 0f));

        groundType = (groundType + 1) % typeCount;
    }


    void CreatePlatformWithEnemy(Vector3 position)
    {
        // 
        GameObject platform = Instantiate(groundPrefab, position, Quaternion.identity);

        //calculate top
        float platformTopY = position.y + (platform.GetComponent<Collider2D>()?.bounds.extents.y ?? 0.5f);

        // calculate bottom
        float enemyBottomOffset = enemyPrefab.GetComponent<Collider2D>()?.bounds.extents.y ?? 0.5f;

        // so that unity won't crash again when enemy is generated floating above the level or stuck in the level
        Vector3 enemyPosition = new Vector3(position.x, platformTopY + enemyBottomOffset, position.z);

        // 
        Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
    }


}
