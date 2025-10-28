using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    
    public void Game(string gameSceneName)
    {
        SceneManager.LoadScene(gameSceneName);
        Debug.Log("play"); 
    }

}
