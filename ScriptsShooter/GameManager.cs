using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private int lives;

    private int enemiesLeft;
    private bool allWavesSpawned;

    public bool IsPlayerDead { get; private set; }

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        UpdateLivesText();
    }

    private void UpdateLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
    }

    public void IncreaseEnemiesLeft()
    {
        enemiesLeft++;
    }

    public void DecreaseEnemiesLeft()
    {
        enemiesLeft--;

        if( enemiesLeft == 0 && allWavesSpawned)
        {
            LoadNextScene();
        }
    }

    public void SetAllWavesSpawned()
    {
        allWavesSpawned = true;
    }

    public void LoadNextScene()
    {
        Reset();
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void Die()
    {
        IsPlayerDead = true;
        lives--;
        UpdateLivesText();
        StopEnemies();
        StopEnemiesSpawn();
        StartCoroutine(WaitAndRestart(0.5f));
    }

    private void Reset()
    {
        enemiesLeft = 0;
        allWavesSpawned = false;
        IsPlayerDead = false;
    }

    private IEnumerator WaitAndRestart(float restartTime)
    {
        yield return new WaitForSeconds(restartTime);
        Reset();

        if(lives > 0)
        {
            int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(activeSceneIndex);
        }
        else
        {
            ResetGame();
        }
    }

    private void ResetGame()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
        Destroy(AudioManager.Instance.gameObject);
    }

    private void StopEnemiesSpawn()
    {
        Spawner spawner = FindObjectOfType<Spawner>();
        spawner.StopAllCoroutines();
    }

    private void StopEnemies()
    {
        EnemyMovement[] enemies = FindObjectsOfType<EnemyMovement>();

        foreach (EnemyMovement enemy in enemies)
        {
            enemy.StopMovement();
        }
    }
}
