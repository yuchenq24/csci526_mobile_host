using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerView playerView;
    public GameObject deathMenuPanel;
    public static PlayerManager Instance { get; private set; }
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        playerView.Init();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            playerView.MoveLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerView.MoveRight();
        }
        else
        {
            playerView.MoveStop();
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            playerView.JumpStart();
        }
        else if (Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            playerView.JumpMaintain();
        }
        else if (Input.GetKeyUp(KeyCode.K) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Space))
        {
            playerView.JumpStop();
        }
    }
    
    public void GetHurt(int damage)
    {
        if (playerView == null )
        {
            Debug.LogError("error! playerview not initiated");
            return;
        }
        playerView.UpdateHealth(damage);

    } 
    

    public void KillPlayer()
    {

    }
    /*
        When the player leaves the ground, isGrounded is set to false
        so that the player can't jump in the air.
        */
    // void OnCollisionExit2D(Collision2D collision){
    //     if(collision.gameObject.CompareTag("Ground")){
    //         isGrounded=false;
    //     }
    // }
}

