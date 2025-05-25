using UnityEngine;
using System.Collections;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitPrefabs;
    [SerializeField] private float spawnInterval = 1.5f;

    private float minX, maxX;
    private float spawnY;

    private bool isPaused = false;

    private void Start()
    {
        Camera cam = Camera.main;
        Vector3 left = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 right = cam.ViewportToWorldPoint(new Vector3(1, 0, 0));
        Vector3 top = cam.ViewportToWorldPoint(new Vector3(0, 1, 0));

        minX = left.x + 0.5f;
        maxX = right.x - 0.5f;
        spawnY = top.y + 1f;

        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(1f); 

        while (true)
        {
            if (!isPaused)
            {
                SpawnFruit();
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnFruit()
    {
        int index = Random.Range(0, fruitPrefabs.Length);
        float xPos = Random.Range(minX, maxX);
        Vector2 spawnPos = new Vector2(xPos, spawnY);

        Instantiate(fruitPrefabs[index], spawnPos, Quaternion.identity);
    }

    public void PauseSpawning()
    {
        isPaused = true;
    }

    public void ResumeSpawning()
    {
        isPaused = false;
    }

    public void ClearFruits()
    {
        GameObject[] allFruits = GameObject.FindGameObjectsWithTag("Fruit");
        foreach (var fruit in allFruits)
        {
            Destroy(fruit); 
        }
    }
}
