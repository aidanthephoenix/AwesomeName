using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Gui Scene");//(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SettingsMenu(){
        SceneManager.LoadScene("Settings");
    }


    public void QuitGame(){
        Application.Quit();
    }
    public bool isMuted = false;

    public void OffMusic(){
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
    }

}