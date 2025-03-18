using UnityEngine;

public class SuicideKey : MonoBehaviour
{
    public GameObject enemyPrefab;
    private bool enemySpawned = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && !enemySpawned)
        {
            SpawnEnemyOnPlayer();
        }
    }

    void SpawnEnemyOnPlayer()
    {
        if (enemyPrefab != null)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            enemy.tag = "Ennemy";

            enemySpawned = true;
        }
    }
}
