using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float cameraSpeed;

    public Camera mainCamera;
    
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float hMove = Input.GetAxisRaw("Horizontal");
        float vMove = Input.GetAxisRaw("Vertical");

        rb.velocity = (playerSpeed) * new Vector2(hMove, vMove);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item")) {
            Destroy(other.gameObject);
        }
    }
}
