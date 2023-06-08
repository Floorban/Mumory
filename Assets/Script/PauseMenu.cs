using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;
    public Button PauseButton;
    private void Start() {
        pauseMenu.SetActive(false);
        PauseButton = GameObject.Find("ButtonForPause").GetComponent<Button>();
        PauseButton.onClick.AddListener(PauseBehavior);
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
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToClassroom(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Classroom");
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
    public void QuitGame(){
        Application.Quit();
    }

}