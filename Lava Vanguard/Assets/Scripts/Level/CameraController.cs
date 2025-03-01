using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject player;
    public float cameraSpeedY = 0.3f;
    public float cameraFollowDistance = 5.0f;
    private void FixedUpdate()
    {
        Vector3 targetCameraPosition = mainCamera.transform.position;

        targetCameraPosition.y += cameraSpeedY * Time.deltaTime;
        if (player.transform.position.x > targetCameraPosition.x + cameraFollowDistance)
        {
            targetCameraPosition.x = player.transform.position.x - cameraFollowDistance;
        }
        else if (player.transform.position.x < targetCameraPosition.x - cameraFollowDistance)
        {
            targetCameraPosition.x = player.transform.position.x + cameraFollowDistance;
        }
        mainCamera.transform.position = targetCameraPosition;
    }
}
