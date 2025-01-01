using UnityEngine;

public class TopDownShipParallax : MonoBehaviour
{
    private float lengthX;
    private float lengthY;
    private float startX;
    private float startY;
    public GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
        lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
        lengthY = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 temp = new Vector2(cam.transform.position.x, cam.transform.position.y) * (1 - parallaxEffect);
        Vector2 dist = new Vector2(cam.transform.position.x, cam.transform.position.y) * parallaxEffect;

        transform.position = new Vector3(startX + dist.x, startY + dist.y, transform.position.z);

        if (temp.x > startX + lengthX)
        {
            startX += lengthX;
        }
        else if (temp.x < startX - lengthX)
        {
            startX -= lengthX;
        }
        else if (temp.y > startY + lengthY)
        {
            startY += lengthY;
        }
        else if (temp.y < startY - lengthY)
        {
            startY -= lengthY;
        }
    }
}