using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Main_Menu : MonoBehaviour
{
    public static float volumemaster = 1;
   public void LoadLevel1()
    {
        SceneManager.LoadScene("level1");
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void Volume(float volume)
    {
        volumemaster = volume;
    }
}
