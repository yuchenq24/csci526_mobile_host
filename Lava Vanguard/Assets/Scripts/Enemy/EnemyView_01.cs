using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView_01 : EnemyView
{
    private readonly float waveAmplitude = 2f;
    private readonly float waveFrequency = 2f;
    protected override void Approching()
    {
        var playerPos = PlayerManager.Instance.playerView.transform.position;
        var direction = (playerPos - transform.position).normalized;

        transform.position += Mathf.Sin(Time.time * waveFrequency) * Time.deltaTime * waveAmplitude * transform.up;
        transform.position += enemyData.Speed * Time.deltaTime * direction;
    }
    protected override Vector3 GetSpawnPosition()
    {
        Camera camera = Camera.main;
        float cameraHeight = 2f * camera.orthographicSize;
        float cameraWidth = cameraHeight * camera.aspect;

        float buffer = 2f; // Extra distance off-screen
        int side = Random.Range(0, 4); // 0 = Left, 1 = Right, 2 = Top, 3 = Bottom

        switch (side)
        {
            case 0: // Left
                return new Vector3(-cameraWidth / 2 - buffer, Random.Range(-cameraHeight / 2, cameraHeight / 2), 0);
            case 1: // Right
                return new Vector3(cameraWidth / 2 + buffer, Random.Range(-cameraHeight / 2, cameraHeight / 2), 0);
            case 2: // Top
                return new Vector3(Random.Range(-cameraWidth / 2, cameraWidth / 2), cameraHeight / 2 + buffer, 0);
            case 3: // Bottom
                return new Vector3(Random.Range(-cameraWidth / 2, cameraWidth / 2), -cameraHeight / 2 - buffer, 0);
            default:
                return Vector3.zero;
        }
    }
}
