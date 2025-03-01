using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class EnemyView : MonoBehaviour
{
    public EnemyData enemyData;
    public void Init(string ID)
    {
        enemyData = GameDataManager.EnemyData[ID];
        transform.position = GetSpawnPosition();
    }
    protected abstract void Approching();
    protected abstract Vector3 GetSpawnPosition();
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerManager.Instance.GetHurt(1);
            Debug.Log(" HP - 1");
        }
    }
    private void Update()
    {
        Approching();
    }
}


