using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemy;
    public GameObject spawnPont;
    public int enemiesNumber;

    [HideInInspector]
    public List<SpawnPoint> enemySpawnPoints;
    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < enemiesNumber; i++) {
            var spawnPosition = new Vector3(Random.Range(-8f, 8f), 0f, Random.Range(-8f, 8f));
            var spawnRotation = Quaternion.Euler(0f, Random.Range(0, 180), 0f);
            SpawnPoint enemySpawnPoint = (Instantiate(spawnPont, spawnPosition, spawnRotation)).GetComponent<SpawnPoint>();
            enemySpawnPoints.Add(enemySpawnPoint);
        }
    }

    public void SpawnEnemies() {
        int i = 0;
        foreach (SpawnPoint point in enemySpawnPoints) {
            Vector3 position = point.transform.position;
            Quaternion rotation = point.transform.rotation;
            GameObject newEnemy = Instantiate(enemy, position, rotation);
            newEnemy.name = i + "";
            PlayerController playerController = newEnemy.GetComponent<PlayerController>();
            playerController.isLocalPlayer = false;
            Health health = newEnemy.GetComponent<Health>();
            i++;
        }
    }
}