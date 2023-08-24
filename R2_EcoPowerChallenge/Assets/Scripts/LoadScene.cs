using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public int sceneNumber;

    public void loadNewScene()
    {
        SceneManager.LoadScene(sceneNumber, LoadSceneMode.Single);
    }

    public void exitGame()
    {
        Application.Quit();
    }

}
