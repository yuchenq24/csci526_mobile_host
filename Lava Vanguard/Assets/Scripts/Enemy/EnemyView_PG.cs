using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView_PG : MonoBehaviour
{
    public float speed = 2f;
    private bool movingRight = true; 
    public Transform groundCheck;

    private float leftLimit;
    private float rightLimit;
    // Start is called before the first frame update
    void Start()
    {
        
        leftLimit = transform.position.x - 1.2f;
        rightLimit = transform.position.x + 1.2f;
    }
    // Update is called once per frame
    void Update()
    {
        // 
        transform.Translate(Vector2.right * speed * Time.deltaTime * (movingRight ? 1 : -1));

        // 
        if (movingRight && transform.position.x >= rightLimit)
        {
            Flip();
        }
        else if (!movingRight && transform.position.x <= leftLimit)
        {
            Flip();
        }
    }
    
    
    void Flip()
    {
        movingRight = !movingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           PlayerManager.Instance.GetHurt(1);
            Debug.Log(" HP - 1" );
        }
    }


}

