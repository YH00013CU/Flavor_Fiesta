using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneShuffler : MonoBehaviour
{
    public string[] sceneNames;
    public float minTimeBetweenScenes = 5f;
    public float maxTimeBetweenScenes = 10f;

    private float timeUntilNextSceneChange;

    void Start()
    {
        timeUntilNextSceneChange = Random.Range(minTimeBetweenScenes, maxTimeBetweenScenes);
    }

    void Update()
    {
        timeUntilNextSceneChange -= Time.deltaTime;
        if (timeUntilNextSceneChange <= 0f)
        {
            int randomIndex = Random.Range(0, sceneNames.Length);
            SceneManager.LoadScene(sceneNames[randomIndex]);
            timeUntilNextSceneChange = Random.Range(minTimeBetweenScenes, maxTimeBetweenScenes);
        }
    }
}
