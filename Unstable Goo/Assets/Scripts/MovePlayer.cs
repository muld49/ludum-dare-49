using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float playerSpeed;
    public float cameraSpeed;

    public Camera mainCamera;
    
    Rigidbody2D rb;

    bool isCameraMoving;

    const float CAMERA_THRESHOLD = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isCameraMoving = false;
    }

    void FixedUpdate()
    {
        float hMove = Input.GetAxisRaw("Horizontal");
        float vMove = Input.GetAxisRaw("Vertical");

        rb.velocity = (playerSpeed) * new Vector2(hMove, vMove);

        Vector2 cameraMove = Vector2.Lerp(mainCamera.transform.position, rb.position, cameraSpeed);
        Vector3 cameraPos = new Vector3(cameraMove.x, cameraMove.y, mainCamera.transform.position.z);
        mainCamera.transform.position = cameraPos;
    }
}
