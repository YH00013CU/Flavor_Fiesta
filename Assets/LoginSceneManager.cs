using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginSceneManager : MonoBehaviour
{
    // Function to be called when login is successful
    public void OnLoginSuccess()
    {
        // Load the main menu scene
        SceneManager.LoadScene("MainMenue");
    }
}
