using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView_02 : EnemyView
{
    private bool movingRight = true; 
    private float leftLimit;
    private float rightLimit;

    private void Start()
    {
        //hardcode!
        leftLimit = transform.position.x - 1.2f;
        rightLimit = transform.position.x + 1.2f;
    }
    protected override void Approching()
    {

        transform.Translate(Vector2.right * enemyData.Speed * Time.deltaTime * (movingRight ? 1 : -1));

        if (movingRight && transform.position.x >= rightLimit)
        {
            Flip();
        }
        else if (!movingRight && transform.position.x <= leftLimit)
        {
            Flip();
        }
    }
    protected override Vector3 GetSpawnPosition()
    {
        var g = LevelGenerator.Instance.grounds[Random.Range(0, LevelGenerator.Instance.grounds.Count)];
        return g.transform.position + new Vector3(0, 0.25f, 0);
    }
    void Flip()
    {
        movingRight = !movingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}

