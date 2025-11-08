using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame(string gameSceneName)
    {
        SceneManager.LoadScene(gameSceneName);
        Debug.Log("play"); 
    }

    public void CreidtsGame(string gameSceneName)
    {
        SceneManager.LoadScene(gameSceneName);
        Debug.Log("CREIDTS Game"); 
    }
    public void How(string gameSceneName)
    {
        SceneManager.LoadScene(gameSceneName);
        Debug.Log("How to play"); 
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game"); 
        Application.Quit();
        Debug.Log("Quit Game"); 
    }
}
