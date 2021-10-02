using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    
    Camera cam;

    const float MAX_X_DELTA = 4.0f;
    const float MAX_Y_DELTA = 4.0f;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        Vector2 playerPos = player.GetComponent<Rigidbody2D>().position;

        // Have to use Vector3 for camera because z position actually matters, 
        // otherwise things get clipped
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newPos = new Vector3(Mathf.Clamp((mousePos.x + playerPos.x) / 2, playerPos.x - MAX_X_DELTA, playerPos.x + MAX_X_DELTA), 
                                     Mathf.Clamp((mousePos.y + playerPos.y) / 2, playerPos.y - MAX_Y_DELTA, playerPos.y + MAX_Y_DELTA),
                                     transform.position.z);

        transform.position = Vector3.Lerp(transform.position, newPos, 0.05f);
    }
}
