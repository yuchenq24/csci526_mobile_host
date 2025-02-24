using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Camera mainCamera;
    public float cameraSpeed=0.3f;
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.position+=new Vector3(0,cameraSpeed*Time.deltaTime,0);
    }
}
