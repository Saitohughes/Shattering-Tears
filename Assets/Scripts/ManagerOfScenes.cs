using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerOfScenes : MonoBehaviour
{
    public string scene;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeScene", 5f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(scene);
    }
}
