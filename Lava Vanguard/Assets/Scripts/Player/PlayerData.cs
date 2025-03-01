using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    
    public PlayerData(float speed, float jumpForce, float jumpAirTime, float jumpAirForce, int health,int maxHealth){
        this.speed = speed;
        this.jumpForce = jumpForce;
        this.jumpAirTime = jumpAirTime;
        this.jumpAirForce = jumpAirForce;
        this.health = health;
        this.maxHealth=maxHealth;
    }
    public static PlayerData DefaultData=new PlayerData(
        speed:5f,
        jumpForce:5f,
        jumpAirTime:0.3f,
        jumpAirForce:5f,
        health:10,
        maxHealth:10);

    public float speed;
    public float jumpForce;
    public float jumpAirTime;
    public float jumpAirForce;
    public int health;
    public int maxHealth;

}
