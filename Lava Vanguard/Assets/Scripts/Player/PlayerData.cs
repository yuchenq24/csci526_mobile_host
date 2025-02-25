using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public PlayerData(float speed, float jumpForce, float jumpAirTime, float jumpAirForce){
        this.speed = speed;
        this.jumpForce = jumpForce;
        this.jumpAirTime = jumpAirTime;
        this.jumpAirForce = jumpAirForce;
    }
    public static PlayerData DefaultData=new PlayerData(
        speed:5f,
        jumpForce:5f,
        jumpAirTime:0.3f,
        jumpAirForce:5f);

    public float speed;
    public float jumpForce;
    public float jumpAirTime;
    public float jumpAirForce;

}
