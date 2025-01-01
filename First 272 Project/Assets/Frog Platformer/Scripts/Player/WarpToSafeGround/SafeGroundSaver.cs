using System.Collections;
using UnityEngine;

public class SafeGroundSaver : MonoBehaviour
{
    [SerializeField] private float saveFrequency = 3f;

    public Vector2 SafeGroundLocation { get; private set; } = Vector2.zero;

    private Coroutine safeGroundCoroutine;

    private GroundCheck groundCheck;

    private void Start()
    {
        safeGroundCoroutine = StartCoroutine(SaveGroundLocation());

        // initialize starting safe position
        print("Starting Safe ground set!");
        SafeGroundLocation = transform.position;
        groundCheck = GetComponent<GroundCheck>();
    }

    private IEnumerator SaveGroundLocation()
    {
        // update timer
        float elapsedTime = 0f;
        while (elapsedTime < saveFrequency)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // if player is touching ground
        if (groundCheck.IsGrounded())
        {
            // update SafeGroundLocation
            print("Safe ground set!");
            SafeGroundLocation = transform.position;
        }

        // restart coroutine
        safeGroundCoroutine = StartCoroutine(SaveGroundLocation());
    }

    public void WarpPlayerToSafeGround()
    {
        transform.position = SafeGroundLocation;
    }
}