using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public Camera cam;
    
    Rigidbody2D rb;
    Inventory inventory;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inventory = GetComponent<Inventory>();
    }

    void FixedUpdate()
    {
        float hMove = Input.GetAxisRaw("Horizontal");
        float vMove = Input.GetAxisRaw("Vertical");

        rb.velocity = (playerSpeed) * new Vector2(hMove, vMove);

        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        float dy = mousePos.y - rb.position.y;
        float dx = mousePos.x - rb.position.x;

        if (dx != 0)
            rb.SetRotation(Mathf.Rad2Deg * Mathf.Atan(dy / dx));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item")) {
            if (inventory.HasCapacity()) {
                inventory.Add(other.gameObject);
                other.gameObject.SetActive(false);
            }
        }
    }
}
