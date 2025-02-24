using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speed=5f;
    public float jumpForce=5f;
    public float jumpAirTime=0.3f;
    public float jumpAirForce=5f;

    private Rigidbody2D rb;
    private bool isGrounded=false;
    private bool isJumping=false;
    private float jumpTempTime=0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        Move();
        Jump();
    }

    void Move(){
        if(Input.GetKey(KeyCode.A)){
            rb.velocity=new Vector2(-speed,rb.velocity.y);
            if(transform.localScale.x>0){
                transform.localScale=new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
            }
        }
        else if(Input.GetKey(KeyCode.D)){
            rb.velocity=new Vector2(speed,rb.velocity.y);
            if(transform.localScale.x<0){
                transform.localScale=new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
            }
        }
        else{
            rb.velocity=new Vector2(0,rb.velocity.y);
        }
    }

    void Jump(){
        if(Input.GetKeyDown(KeyCode.K) && isGrounded){
            isJumping=true;
            jumpTempTime=jumpAirTime;
            rb.velocity=new Vector2(rb.velocity.x,jumpForce);
            isGrounded=false;
        }
        if(Input.GetKey(KeyCode.K)&&isJumping&&jumpTempTime>0){
            rb.velocity=new Vector2(rb.velocity.x,jumpAirForce);
            jumpTempTime-=Time.deltaTime;
        }
        if(Input.GetKeyUp(KeyCode.K)){
            isJumping=false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            isGrounded=true;
        }
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
