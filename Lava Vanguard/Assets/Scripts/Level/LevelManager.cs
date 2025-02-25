using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject player;
    public float cameraSpeedY=0.3f;
    public float cameraFollowDis=5.0f;
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetCameraPosition=mainCamera.transform.position;

        targetCameraPosition.y+=cameraSpeedY*Time.deltaTime;
        if(player.transform.position.x>targetCameraPosition.x+cameraFollowDis){
            targetCameraPosition.x=player.transform.position.x-cameraFollowDis;
        }
        else if(player.transform.position.x<targetCameraPosition.x-cameraFollowDis){
            targetCameraPosition.x=player.transform.position.x+cameraFollowDis;
        }
        mainCamera.transform.position=targetCameraPosition;
    }
}
