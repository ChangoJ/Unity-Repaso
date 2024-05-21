using UnityEngine;

public class Reposition : MonoBehaviour
{
    private float spriteWidth;

    void Start()
    {
        spriteWidth = GetComponent<SpriteRenderer>().size.x;
    }

    void Update()
    {
        if(transform.position.x < -spriteWidth)
        {
            transform.Translate(Vector2.right * 2f * spriteWidth);
        }
    }
}
