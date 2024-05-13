using UnityEngine;


public class BallCollision : MonoBehaviour
{

    GameManager gameManager;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
            gameManager.DecreaseBlocks();

        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.RestartScene();
    }
}
