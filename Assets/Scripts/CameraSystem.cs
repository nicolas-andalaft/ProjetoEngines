using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public float speed;
    private Transform transform;
    private Transform transformPlayer;

    private void Awake()
    {
        transform = GetComponent<Transform>();
        transformPlayer = GameObject.FindWithTag("Player").GetComponent<Transform>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        transform.position = transformPlayer.position;

        float movX = Input.GetAxis("Mouse X");
        transform.Rotate(0, movX * speed, 0);
    }
}
