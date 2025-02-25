using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    PlayerData playerData;
    private Rigidbody2D rb;
    private bool isGrounded=false;
    private bool isJumping=false;
    private float jumpTempTime=0.0f;
    // Start is called before the first frame update
    public void Init()
    {
        playerData=PlayerData.defaultData;
        rb=GetComponent<Rigidbody2D>();
    }

    public void MoveLeft(){
        rb.velocity=new Vector2(-playerData.speed,rb.velocity.y);
        if(transform.localScale.x>0){
            transform.localScale=new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
        }
    }

    public void MoveRight(){
        rb.velocity=new Vector2(playerData.speed,rb.velocity.y);
        if(transform.localScale.x<0){
            transform.localScale=new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
        }
    }

    public void MoveStop(){
        rb.velocity=new Vector2(0,rb.velocity.y);
    }

    public void JumpStart(){
        if(isGrounded){
            isJumping=true;
            jumpTempTime=playerData.jumpAirTime;
            rb.velocity=new Vector2(rb.velocity.x,playerData.jumpForce);
            isGrounded=false;
        }
    }

    public void JumpMaintain(){
        if(isJumping&&jumpTempTime>0){
            rb.velocity=new Vector2(rb.velocity.x,playerData.jumpAirForce);
            jumpTempTime-=Time.deltaTime;
        }
    }

    public void JumpStop(){
        isJumping=false;
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            isGrounded=true;
        }
    }
}
