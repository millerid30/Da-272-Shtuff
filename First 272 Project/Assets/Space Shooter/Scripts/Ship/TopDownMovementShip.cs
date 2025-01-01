using System;
using UnityEngine;

public class TopDownMovementShip : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    float moveInput;
    float turnInput;
    float rotationAngle;
    [Range(1f, 100f)] public float moveSpeed = 50.0f;
    [Range(1f, 100f)] public float turnSpeed = 35.0f;
    [Range(0f, 1f)] public float driftFactor = 0.9f;
    [Range(0f, 10f)] public float drag = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
        turnInput = Input.GetAxisRaw("Horizontal") * turnSpeed * Time.deltaTime;
    }
    void FixedUpdate()
    {
        Thrust();
        KillOrthogonalVelocity();
        Steering();
    }
    void Thrust()
    {
        if (moveInput == 0)
        {
            rb.drag = Mathf.Lerp(rb.drag, drag, Time.deltaTime * 3);
        }
        Vector2 thrustVector = transform.up * moveInput * moveSpeed;
        rb.AddForce(thrustVector, ForceMode2D.Force);
    }
    void Steering()
    {
        rotationAngle -= turnInput * turnSpeed;
        rb.MoveRotation(rotationAngle);
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            anim.SetBool("TurnLeft", true);
            anim.SetBool("TurnRight", false);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            anim.SetBool("TurnRight", true);
            anim.SetBool("TurnLeft", false);
        }
        else
        {
            anim.SetBool("TurnLeft", false);
            anim.SetBool("TurnRight", false);
        }
    }
    void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(rb.velocity, transform.right);

        rb.velocity = forwardVelocity + rightVelocity * driftFactor;
    }
}