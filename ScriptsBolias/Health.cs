using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Healthbar healthbar;
    [SerializeField] private AudioClip hitClip, dieClip;
    [SerializeField] private int maxHealth;

    private SpriteRenderer spriteRenderer;
    private int health;

    void Start()
    {
        health = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Arrow arrow = collision.gameObject.GetComponent<Arrow>();

        if(arrow != null)
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        health--;

        if(health <= 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            AudioManager.Instance.PlaySoundEffect(dieClip, 1f);
            GameManager.Instance.DecreaseEnemiesLeft();
        }
        else
        {
            healthbar.UpdateHealthbar(maxHealth, health);
            AudioManager.Instance.PlaySoundEffect(hitClip, 0.5f);
            StartCoroutine(Blink(0.1f));
        }
    }

    private IEnumerator Blink(float blinkTime)
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(blinkTime);
        spriteRenderer.color = Color.white;
    }

}
