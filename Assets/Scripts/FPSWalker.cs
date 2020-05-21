using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSWalker : MonoBehaviour
{
    public Vector2 acceleration;
    public float speed;
    public LayerMask layer;
    public float offset;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.zero;
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 rotation = transform.eulerAngles;
        rotation.y += mouseX * acceleration.x * Time.deltaTime;
        rotation.x += -mouseY * acceleration.y * Time.deltaTime;
        rotation.z = 0;
        transform.eulerAngles = rotation;

        float movHori = Input.GetAxis("Horizontal");
        float movVert = Input.GetAxis("Vertical");

        Vector3 posi = transform.position;
        transform.Translate(movHori * speed * Time.deltaTime, 0, 
            movVert * speed * Time.deltaTime);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, layer))
            posi.y = hit.point.y + offset;

        transform.position = new Vector3(transform.position.x, posi.y, transform.position.z);
    }
}
