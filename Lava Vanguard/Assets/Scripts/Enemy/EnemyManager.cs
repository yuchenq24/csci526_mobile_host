using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    
    public static EnemyManager Instance { get; private set; }
    public Transform enemyContainer;
    [HideInInspector]
    public GameObject[] enemyPrefabs;
    private void Awake()
    {
        Instance = this;
    }
    public void GenerateRandomEnemy()
    {
        int suffix = Random.Range(0, enemyPrefabs.Length);
        var enemyView = Instantiate(enemyPrefabs[suffix],enemyContainer).GetComponent<EnemyView>();
        enemyView.Init("Enemy_0" + (suffix + 1));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            GenerateRandomEnemy();
    }
}
