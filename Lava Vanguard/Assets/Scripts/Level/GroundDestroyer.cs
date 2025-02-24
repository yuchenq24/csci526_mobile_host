using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyer : MonoBehaviour
{
    public float moveSpeed=0.3f;
    public float destroyY=-10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<destroyY){
            Destroy(gameObject);
        }
    }
}
