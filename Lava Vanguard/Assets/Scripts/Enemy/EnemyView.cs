using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public EnemyData enemyData;
    public void Init(EnemyData enemyData)
    {
        this.enemyData = enemyData;
    }
    private void Update()
    {
        // Looming
        if (enemyData.type == EnemyType.Flying) {
            FlyingEnemyUpdate();
        }
    }

    private void FlyingEnemyUpdate() {
        float speed = 1f;
        float waveAmplitude = 2f;
        float waveFrequency = 2f;
        var playerPos = PlayerManager.Instance.playerView.transform.position;

        var direction = (playerPos - transform.position).normalized;

        transform.position += transform.up * Mathf.Sin(Time.time * waveFrequency) * waveAmplitude * Time.deltaTime;
        transform.position += direction * speed * Time.deltaTime;
    }
}


