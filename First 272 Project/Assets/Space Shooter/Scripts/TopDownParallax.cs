using UnityEngine;

public class TopDownParallax : MonoBehaviour
{
    public GameObject ship;
    void FixedUpdate()
    {
        Vector3 look = new Vector3(transform.rotation.x,transform.rotation.y,-ship.transform.localEulerAngles.z);
        transform.rotation = Quaternion.Euler(look);
    }
}