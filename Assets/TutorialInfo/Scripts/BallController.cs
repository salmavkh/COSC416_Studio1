using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody sphereRigidbody;
    public float ballSpeed = 2f;
    public float jumpForce = 5f;
    private bool isGrounded = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero; // intialize our input vector if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.W))
            {
                inputVector += Vector2.up; // "a += b" <=> "a = a + b" 
            }
            if (Input.GetKey(KeyCode.S))
            {
                inputVector += Vector2.down;
            }
            if (Input.GetKey(KeyCode.D))
            {
                inputVector += Vector2.right;
            }
            if (Input.GetKey(KeyCode.A))
            {
                inputVector += Vector2.left;
            }

            Debug.Log("Resultant Vector: " + inputVector);
            Vector3 inputXZPlane = new(inputVector.x, 0, inputVector.y);
            sphereRigidbody.AddForce(inputXZPlane * ballSpeed);

        }

        // Handle jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            sphereRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Prevent double jumps
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the ball touches the ground
        // Before this, add the "Ground" tag to the selected Ground object
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true; // Reset grounded state to allow jumping
        }
    }

}
