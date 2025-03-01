using DG.Tweening;
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
    private void Start()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(GenerateRandomEnemy);
        sequence.AppendInterval(1f);
        sequence.SetLoops(-1);
    }
}
