using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    int blocksLeft;
    
    void Start()
    {
        blocksLeft = GameObject.FindGameObjectsWithTag("Block").Length;
    }

    public void DecreaseBlocks()
    {
        blocksLeft--;

        if (blocksLeft == 0)
        {
            LoadNextScene();
        }

    }

    public void RestartScene()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);
    }

    void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    
   
}
