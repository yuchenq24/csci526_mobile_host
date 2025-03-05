using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        
        if (transform.position.x > 10) 
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")){
            Debug.Log("Enemy is hit");
            PlayerManager.Instance.GainEXP(1);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
