using UnityEngine;
using UnityEngine.SceneManagement;

public class sceee : MonoBehaviour
{
    // Array to store scene names
    public string[] sceneNames = { "play_France", "play_Italy", "play_Japan" };

    // Time between scene changes
    public float sceneChangeInterval = 15f;

    private void Start()
    {
        // Start shuffling scenes
        InvokeRepeating("ShuffleScenes", sceneChangeInterval, sceneChangeInterval);
    }

    // Function to shuffle scenes
    public void ShuffleScenes()
    {
        // Get a random scene index
        int randomIndex = Random.Range(0, sceneNames.Length);

        // Load the scene with the new index
        SceneManager.LoadScene(sceneNames[randomIndex]);
    }
}
