using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimpleScoring : MonoBehaviour
{
    private int score = 0; // Player's score
    public int health = 100; // Player's health
    public HealthBar healthBar; // Reference to the HealthBar script attached to the HealthSlider
    public TMP_Text scoreText; // Reference to the TextMeshPro text element to display the score
    public Image gameOverImage; // Reference to the game over image UI Image component
    public GameObject restartButton; // Reference to the restart button GameObject
    public int currentHealth;

    void Start()
    {
        // Load saved score and health from PlayerPrefs on scene start
        score = PlayerPrefs.GetInt("Score", 0);
        health = PlayerPrefs.GetInt("Health", 100);
        UpdateScoreUI();
        healthBar.SetHealth(health);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FallingObject"))
        {
            IncreaseScore();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("WrongFood"))
        {
            DecreaseHealth();
            Destroy(collision.gameObject);
        }
    }

    private void IncreaseScore()
    {
        score += 10;
        UpdateScoreUI();
        // Save updated score to PlayerPrefs
        PlayerPrefs.SetInt("Score", score);
    }

    private void DecreaseHealth()
    {
        health -= 20;
        health = Mathf.Max(0, health);
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            GameOver();
        }
        // Save updated health to PlayerPrefs
        PlayerPrefs.SetInt("Health", health);
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    private void GameOver()
    {
        gameOverImage.gameObject.SetActive(true);
        restartButton.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        // Reset score and health to their initial values
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Health", 100);

        // Load the scene again
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Reset time scale to normal
        Time.timeScale = 1;
    }

}
