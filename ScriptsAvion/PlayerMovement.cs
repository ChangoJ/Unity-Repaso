using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float upForce;

    private float yInput;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        yInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector2.up * upForce * yInput);
    }
}
