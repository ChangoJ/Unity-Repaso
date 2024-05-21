using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel; 
    [SerializeField] private TMP_Text scoreText;

    private int score;
    private bool isGameOver;

    public static GameManager Instance { get; private set; }

    void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if(isGameOver && Input.anyKeyDown)
        {
            ResetGame();
        }
    }

    private void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int points)
    {
        score += points;

        if(score < 0)
        {
            score = 0;
        }

        scoreText.text = "score: " + score.ToString();
    }

    public void StopGame()
    {
        isGameOver = true;
        StopScroll();
        StopSpawn();
        ShowGameOverPanel();
    }

    private void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    private void StopSpawn()
    {
        Spawner[] spawners = FindObjectsOfType<Spawner>();
        
        foreach(Spawner spawner in spawners)
        {
            spawner.StopSpawn();
        }
    }

    private void StopScroll()
    {
        Scroll[] scrollingObjects = FindObjectsOfType<Scroll>();

        foreach (Scroll scrollingObject in scrollingObjects)
        {
            scrollingObject.StopScroll();
        }
    }
}
