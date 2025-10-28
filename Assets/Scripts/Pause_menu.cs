using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI; // Assign your UI panel here
    private bool isPaused = false;

    void Update()
    {
        // Toggle pause with UpArrow
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; 
        isPaused = false;
    }

    // Optional Restart button handler
    // public void Restart()
    // {
    //     Time.timeScale = 1f; 
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    // }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; 
        isPaused = true;
    }
}
