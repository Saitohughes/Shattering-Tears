using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    public KeyCode resetKey = KeyCode.R;

    void Update()
    {
        // Check if the specified key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Call the Reset function
            ResetScene();
        }
    }

    void ResetScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
