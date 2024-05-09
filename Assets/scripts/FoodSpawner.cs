using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foodPrefabs; // Array to hold prefabs for different foods
    public float spawnRate = 2f; // Rate at which foods will spawn (in seconds)
    public float spawnTimer = 0f; // Timer to track when to spawn the next food

    void Update()
    {
        // Increment the spawn timer
        spawnTimer += Time.deltaTime;

        // Check if it's time to spawn a new food
        if (spawnTimer >= spawnRate)
        {
            // Reset the timer
            spawnTimer = 0f;

            // Spawn a random food at the top of the screen
            SpawnFood();
        }
    }

    void SpawnFood()
    {
        // Choose a random food prefab from the array
        GameObject foodPrefab = foodPrefabs[Random.Range(0, foodPrefabs.Length)];

        // Calculate a random position at the top of the screen
        float randomX = Random.Range(Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).x,
                                      Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x);
        float spawnY = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y; // Top of the screen
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);

        // Instantiate the selected food prefab at the calculated position
        GameObject food = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);

        // Optionally, you can add code here to set different speeds for foods based on country
        // For simplicity, let's assume all foods fall at the same speed for now
        // You can adjust the Rigidbody2D component of the food prefab for different speeds
    }
}
