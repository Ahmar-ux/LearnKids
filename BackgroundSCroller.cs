//For more queries contact at: kuhaxa@gmail.com
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Header("Background Settings")]
    public GameObject[] backgrounds; // Assign 3 background GameObjects here
    public float scrollSpeed = 2f;   // Speed at which backgrounds move
    private float bgWidth;           // Width of the background sprite

    void Start()
    {
        if (backgrounds.Length == 0)
        {
            Debug.LogError("No backgrounds assigned!");
            return;
        }

        // Assuming all backgrounds have the same width
        SpriteRenderer sr = backgrounds[0].GetComponent<SpriteRenderer>();
        if (sr != null)
            bgWidth = sr.bounds.size.x;
        else
            Debug.LogError("Backgrounds need a SpriteRenderer component!");
    }

    void Update()
    {
        foreach (GameObject bg in backgrounds)
        {
            // Move background left
            bg.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

            // If background completely left the screen, move it to the right
            if (bg.transform.position.x <= -bgWidth)
            {
                float rightMostX = GetRightMostBackgroundX();
                bg.transform.position = new Vector3(
                    rightMostX + bgWidth,
                    bg.transform.position.y,
                    bg.transform.position.z
                );
            }
        }
    }

    // Helper: find the rightmost background X position
    float GetRightMostBackgroundX()
    {
        float maxX = backgrounds[0].transform.position.x;
        foreach (GameObject bg in backgrounds)
        {
            if (bg.transform.position.x > maxX)
                maxX = bg.transform.position.x;
        }
        return maxX;
    }
}

