using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public GameObject deathMenuPanel;
    public float cameraDistance=5f;
    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            Debug.Log("Player is dead");
            Time.timeScale = 0f;
            deathMenuPanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, mainCamera.transform.position.y - cameraDistance, 0);
    }
}
