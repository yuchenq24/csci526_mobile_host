using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFollower : MonoBehaviour
{
    private Camera mainCamera;
    private float yOffset;
    void Start()
    {
        mainCamera = Camera.main;
        yOffset = transform.position.y - mainCamera.transform.position.y;       
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, mainCamera.transform.position.y + yOffset, transform.position.z);
    }
}
