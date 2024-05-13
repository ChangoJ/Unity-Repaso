using UnityEngine;

public class BallMovement : MonoBehaviour
{


    Rigidbody2D rb;
    [SerializeField] Vector2 launchForce;
    bool isBallLaunched;

    void Start()
    {
       rb =  GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {

        if (Input.GetButtonDown("Launch") && !isBallLaunched)
        {
            isBallLaunched = true;
            rb.AddForce(launchForce);
            transform.parent = null;
        }
    }
}
