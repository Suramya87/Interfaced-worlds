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

    public void QuitGame()
    {
        Debug.Log("Quit Game"); 
        Application.Quit();
        Debug.Log("Quit Game"); 
    }
}
