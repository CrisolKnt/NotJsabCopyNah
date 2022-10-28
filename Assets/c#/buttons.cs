using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
  public void restart_level()
    {
        static_variable.checkpointtoload = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);   
    }

    public void MenuScreen()
    {
        SceneManager.LoadSceneAsync("Main Menu");
        SceneManager.UnloadSceneAsync("level1");
    }

    public static void respawn()
    {
        static_variable.checkpointtoload = LevelEvents.checkpoint;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
