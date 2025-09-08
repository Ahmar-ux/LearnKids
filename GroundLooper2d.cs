using UnityEngine;

public class GroundLooper2D : MonoBehaviour
{
    public GameObject[] grounds;   // Assign your ground objects here
    public float moveSpeed = 5f;
    public float spacing = -2f;    // Negative spacing = overlapping by 2 units

    private float groundWidth;

    void Start()
    {
        if (grounds.Length > 0)
        {
            // Use sprite width + spacing (which can be negative)
            groundWidth = grounds[0].GetComponent<SpriteRenderer>().bounds.size.x + spacing;
        }
    }

    void Update()
    {
        foreach (GameObject ground in grounds)
        {
            // Move each ground to the left
            ground.transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            // Reposition when it's off-screen
            if (ground.transform.position.x < -groundWidth)
            {
                GameObject rightMost = GetRightMostGround();
                float newX = rightMost.transform.position.x + groundWidth;
                ground.transform.position = new Vector3(newX, ground.transform.position.y, ground.transform.position.z);
            }
        }
    }

    // Find the ground currently farthest to the right
    GameObject GetRightMostGround()
    {
        GameObject rightMost = grounds[0];
        foreach (GameObject ground in grounds)
        {
            if (ground.transform.position.x > rightMost.transform.position.x)
            {
                rightMost = ground;
            }
        }
        return rightMost;
    }
}
