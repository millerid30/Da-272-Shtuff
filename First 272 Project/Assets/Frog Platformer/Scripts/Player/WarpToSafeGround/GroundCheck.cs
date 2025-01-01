using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private float extraHeight = 0.25f;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Collider2D feetColl;

    private RaycastHit2D groundHit;

    public bool IsGrounded()
    {
        groundHit = Physics2D.BoxCast(feetColl.bounds.center, feetColl.bounds.size, 0f, Vector2.down, extraHeight, whatIsGround);

        if (groundHit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}