using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;

    float bounds = 5.05f;

   
    void Update()
    {
        Move();
    }

    void Move()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float newPositionX = transform.position.x + speed * xInput * Time.deltaTime;

        if (newPositionX < bounds && newPositionX > -bounds)
        {
            transform.position += new Vector3(speed * xInput * Time.deltaTime, 0f, 0f);

        }
    }
}
