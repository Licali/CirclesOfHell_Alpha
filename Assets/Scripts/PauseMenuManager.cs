using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) 
            {
                ResumeGame();
            } else
            {
                PauseGame();
            }
        }
    }
    /// <summary>
    /// Continue game process
    /// </summary>
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // restore game speed
        isPaused = false;
    }
    /// <summary>
    /// Paused game process 
    /// </summary>
    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; //game time stop (sleep, freeze, no game process in pause status)
        isPaused=true;
    }
    /// <summary>
    /// Return to main menu from game by lick button
    /// </summary>
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
