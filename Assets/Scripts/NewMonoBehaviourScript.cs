using UnityEngine;
using UnityEngine.SceneManagement;

public class How_to_paly : MonoBehaviour
{
    
    public void Game(string gameSceneName)
    {
        SceneManager.LoadScene(gameSceneName);
        Debug.Log("play"); 
    }

}