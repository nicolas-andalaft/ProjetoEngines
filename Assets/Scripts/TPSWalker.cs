using UnityEditor;
using UnityEngine;

public class TPSWalker : MonoBehaviour
{
    public float speed;
    public float heightOffset;
    public float jumpJorce;
    public bool isOnGround;
    public bool isJumping;
    public bool isMoving;
    public LayerMask groundLayer;
    public Animator animator;
    public GameObject attackCollider;
    public GameObject jumpParticles;
    public AudioSource attackSound;
    public AudioSource jumpingSound;

    private Rigidbody rigidbody;
    private Transform transformCamera;

    public static Vector3 floorPoint = Vector3.zero;
    public static bool attackPressed;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        transformCamera = GameObject.FindWithTag("CameraSystem").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        bool jumpPressed = Input.GetButtonDown("Jump");
        attackPressed = Input.GetButtonDown("Fire1");

        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        Vector3 mov = new Vector3(movH, 0, movV);
        if (mov.magnitude > 1f)
            mov.Normalize();

        isOnGround = Physics.Raycast(transform.position, Vector3.down, out _, heightOffset + 0.1f);

        isJumping = jumpPressed || !isOnGround;
        isMoving = mov.magnitude > 0.1f;

        rigidbody.useGravity = isJumping;
        rigidbody.constraints = (
            RigidbodyConstraints.FreezeRotationX |
            RigidbodyConstraints.FreezeRotationY |
            RigidbodyConstraints.FreezeRotationZ
        );
        if (!isJumping)
            rigidbody.constraints = rigidbody.constraints | RigidbodyConstraints.FreezePositionY;
        
        if (jumpPressed && isOnGround)
        {
            rigidbody.AddForce(Vector3.up * jumpJorce, ForceMode.Impulse);
            jumpingSound.Play();
        }

        if (isMoving)
        {
            transform.LookAt(transform.position + transformCamera.TransformDirection(mov) * 5);
            transform.Translate(0, 0, mov.magnitude * speed * Time.deltaTime);
        }

        jumpParticles.SetActive(isJumping);

        animator.SetFloat("speed", mov.magnitude);
        animator.SetBool("isJumping", isJumping);

        attackCollider.SetActive(attackPressed);
        if (attackPressed)
        {
            animator.SetTrigger("attack");
            attackSound.Play();
        }

        if (!isJumping)
        {
            RaycastHit hit;
            bool hadHit = Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, groundLayer);
            if (hadHit)
            {
                floorPoint = hit.point;
                Vector3 pos = transform.position;
                pos.y = hit.point.y + heightOffset;
                transform.position = pos;
            }

            rigidbody.velocity = Vector3.zero;
        }
    }
}
