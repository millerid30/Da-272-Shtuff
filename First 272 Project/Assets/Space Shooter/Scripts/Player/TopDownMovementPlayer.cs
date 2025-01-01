using UnityEngine;

public class TopDownMovementPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    float vertical;
    float horizontal;

    public float speedLimit = 0.71f;

    public float moveSpeed;
    private bool facingRight = true;

    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Flip();
    }
    void FixedUpdate()
    {
        if (horizontal != 0 || vertical != 0)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
        // Diagonal speed limit
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= speedLimit;
            vertical *= speedLimit;
        }

        rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }
    private void Flip()
    {
        if (!facingRight && horizontal > 0)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            UI.transform.Rotate(new Vector3(0,180,0));
            facingRight = true;
        }
        if (facingRight && horizontal < 0)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            UI.transform.Rotate(new Vector3(0, 180, 0));
            facingRight = false;
        }
    }
}