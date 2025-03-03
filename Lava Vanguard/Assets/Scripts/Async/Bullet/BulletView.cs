using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    public float speed = 1.0f;
    public float lifeDistance = 30.0f;
    private Vector3 startPosition;

    [Header("Auto-Aiming")]
    private bool hasTarget = false; 
    public float detectionRange = 6.0f;
    public float maxAimDeviation = 5f;
    public LayerMask enemyLayer;       
    private Vector3 fireDirection;
    private float angle;
        

    void Start()
    {
        startPosition = transform.position;
        FindClosestEnemy();
        ApplyInitialRotation();
    }

    private void FindClosestEnemy()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, detectionRange, enemyLayer);
        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;
        foreach (Collider2D enemy in enemies)
        {   
            if (enemy.CompareTag("Enemy") && enemy.gameObject.activeInHierarchy)
            {
                Rigidbody2D targetRb = enemy.GetComponent<Rigidbody2D>();
                Vector3 targetVelocity = targetRb != null ? targetRb.velocity : Vector3.zero;

                Vector3 targetPosition = enemy.transform.position;
                float timeToHit = Vector3.Distance(transform.position, targetPosition) / speed;
                Vector3 predictedPosition = targetPosition + targetVelocity * timeToHit;

                float distance = Vector3.Distance(predictedPosition, transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy.transform;
                }
            }
        }

        if (closestEnemy != null)
        {
            // Debug.Log("ClosestEnemy: " + closestEnemy.position);
            fireDirection = (closestEnemy.position - transform.position).normalized;
            hasTarget = true;
        }
        else
        {
            fireDirection = new Vector3(1, 0, 0);
            hasTarget = false;
        }
        
    }

    private void ApplyInitialRotation()
    {   
        // Debug.Log("Fire Direction: " + fireDirection);
        if (hasTarget)
        {   
            transform.forward = fireDirection;
            // float angle = Mathf.Atan2(fireDirection.y, fireDirection.x) * Mathf.Rad2Deg;
            
            // transform.rotation = Quaternion.Euler(0,0,angle);
            transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
        }
    }

    private void Update()
    {
        if (Vector3.Distance(startPosition, transform.position) > lifeDistance)
        {
            Destroy(gameObject);
        }
        transform.Translate(fireDirection * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            PlayerManager.Instance.GainEXP(1);
            Debug.Log("Enemy is dead");
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
