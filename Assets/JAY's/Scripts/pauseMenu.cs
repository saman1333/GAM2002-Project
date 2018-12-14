using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class pauseMenu : MonoBehaviour {

    public static bool GamePaused = false;
    public GameObject OnPauseMenu;

		void Update () {
		if (CrossPlatformInputManager.GetAxis("Pause") >0)
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                pause();
            }
        }
	}

    public void Resume()
    {
        OnPauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void pause ()
    {
        OnPauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

   

}
