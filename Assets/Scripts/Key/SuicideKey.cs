using UnityEngine;

public class SuicideKey : MonoBehaviour
{
    public GameObject enemyPrefab;
    private bool enemySpawned = false;

    //si touche k pressé, fait apparaitre ennemi sur le player
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && !enemySpawned)
        {
            SpawnEnemyOnPlayer();
        }
    }

    //permet de faire apparaitre l'ennemi (initialisation)
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
