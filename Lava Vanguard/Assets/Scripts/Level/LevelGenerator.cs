using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject playerPrefab;
    public int maxAttempts=2;
    public float cameraDistance=5.0f;
    public float minX=-20f,maxX=20f;
    public float minDisX = 5.0f,maxDisX=5.0f;
    public float minDisY=0.5f,maxDisY=1.7f;
    private float lastY;
    // Start is called before the first frame update
    void Start()
    {
        lastY = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.transform.position.y + cameraDistance > lastY){
            GenerateGround();
        }
    }

    void GenerateGround(){
        List<Vector3> spawnPositions = new List<Vector3>();
        for (int i = 0; i < maxAttempts; i++){
            float spawnX = Random.Range(minX, maxX);
            float spawnY = lastY + Random.Range(minDisY, maxDisY);
            bool valid = true;
            for(int j=0;j<spawnPositions.Count;j++){
                float disX=Mathf.Abs(spawnX-spawnPositions[j].x);
                float disY=Mathf.Abs(spawnY-spawnPositions[j].y);
                if(disX<minDisX || disY<minDisY || disY>maxDisY){
                    valid=false;
                    break;
                }
            }
            if(valid){
                spawnPositions.Add(new Vector3(spawnX, spawnY, 0));
            }
        }
        foreach(Vector3 pos in spawnPositions){
            lastY=Mathf.Max(lastY,pos.y);
            Instantiate(groundPrefab, pos, Quaternion.identity);
        }
    }
}
