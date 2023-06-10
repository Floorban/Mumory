using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;
    public GameObject endScreen;
    private void Start() {
        pauseMenu.SetActive(false);
        endScreen.SetActive(false);
        Time.timeScale = 1f;
    }
    private void PauseBehavior(){
        if(isPaused){
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }
    public void PauseGame(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame(){
        pauseMenu.SetActive(false);
        endScreen.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToClassroom(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("class");
    }
    public void GoToClinic(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Clinic");
    }
    public void GoToHallway(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Hallway");
    }
    public void GoToHome(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Home");
    }

    public void GoToOrigin(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("origin");
    }
    public void QuitGame(){
        Application.Quit();
    }

}