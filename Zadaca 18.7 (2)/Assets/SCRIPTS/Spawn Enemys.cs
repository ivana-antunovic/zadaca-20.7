using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnRadius = 10f;
    private GameManager gameManager;
    private Transform player;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        Player playerObj = FindAnyObjectByType<Player>();
        if (playerObj != null)
            player = playerObj.transform;

        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
       


        Vector2 circle = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 spawnPosition = new Vector3(
            player.position.x + circle.x,
            player.position.y, 
            player.position.z + circle.y
        );

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    void Update()
    {
        if (gameManager != null && gameManager.playerHP <= 0)
        {
            CancelInvoke(nameof(SpawnEnemy));
        }
    }
}

