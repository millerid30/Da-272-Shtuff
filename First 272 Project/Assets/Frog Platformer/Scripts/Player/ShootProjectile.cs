using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class ShootProjectile : MonoBehaviour
{
    [SerializeField] private GameObject launcher;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Image crosshair;
    [SerializeField] private GameObject projectilePrefab;
    private GameObject projectileInst;

    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;
    // check for ammo?
    
    private void Start()
    {
        crosshair.gameObject.SetActive(false);
    }
    private void Update()
    {
        FollowMouse();
        if (InputManager.FireIsHeld)
        {
            crosshair.gameObject.SetActive(true);
        }
        if (InputManager.FireIsReleased)
        {
            crosshair.gameObject.SetActive(false);
            Shoot();
        }
    }
    private void FollowMouse()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)launcher.transform.position).normalized;
        launcher.transform.right = direction;

        crosshair.transform.position = worldPosition;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector3 localScale = Vector3.one;
        if (angle > 90 || angle < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.x = 1f;
        }
        launcher.transform.localScale = localScale;
    }
    private void Shoot()
    {
        if (InputManager.FireIsReleased)
        {
            projectileInst = Instantiate(projectilePrefab, spawnPoint.position, launcher.transform.rotation);
        }
    }
}