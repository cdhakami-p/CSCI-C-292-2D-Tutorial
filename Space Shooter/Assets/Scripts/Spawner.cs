using UnityEngine;
using UnityEngine.Rendering;

public class Spawner : MonoBehaviour
{

    [SerializeField] float spawnRate = 2f;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject meteorPrefab;

    float xMin;
    float xMax;
    float ySpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xMin = Camera.main.ViewportToWorldPoint(new Vector3(.1f, 0, 0)).x;
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(.9f, 0, 0)).x;
        ySpawn = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.25f, 0)).y;

        InvokeRepeating("SpawnEnemy", 0, spawnRate);
        InvokeRepeating("SpawnMeteor", 0, Random.Range(0.5f,3f)*spawnRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        if (GameManager.instance != null && GameManager.instance.isGameOver)
        {
            return;
        }

        float xSpawn = Random.Range(xMin, xMax);
        Vector3 spawnPosition = new Vector3(xSpawn, ySpawn, 0);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    void SpawnMeteor()
    {
        if (GameManager.instance != null && GameManager.instance.isGameOver)
        {
            return;
        }

        float xSpawn = Random.Range(xMin, xMax);
        Vector3 spawnPosition = new Vector3(xSpawn, ySpawn, 0);
        Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);
    }
}
