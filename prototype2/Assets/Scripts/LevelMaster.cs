using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMaster : MonoBehaviour
{

    // Variables referencing two edge colliders
    public EdgeCollider2D BottomWall;
    public EdgeCollider2D TopWall;

    // Use this for initialization
    void Start()
    {
        // Get the width and height of the camera (in pixels)
        float screenW = Camera.main.pixelWidth;
        float screenH = Camera.main.pixelHeight;

        // Create an array consisting of two Vector2 object
        Vector2[] edgePoints = new Vector2[2];

        // Convert screen coordinates point (0,0) to world coordinates
        Vector3 leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));
        // Convert screen coordinates point (0,H) to world coordinates
        Vector3 rightBottom = Camera.main.ScreenToWorldPoint(new Vector3(screenW, 0f, 0f));

        // Set the two points in the array to screen left bottom
        // and screen right bottom points            
        edgePoints[0] = leftBottom;
        edgePoints[1] = rightBottom;

        // Position the bottom wall edge collider
        // at the bottm of the camera
        BottomWall.points = edgePoints;

        // Convert screen coordinates point (W,0) to world coordinates
        Vector3 leftTop = Camera.main.ScreenToWorldPoint(new Vector3(0f, screenH, 0f));
        // Convert screen coordinates point (W,H) to world coordinates
        Vector3 rightTop = Camera.main.ScreenToWorldPoint(new Vector3(screenW, screenH, 0f));

        // Set the two points in the array to screen right bottom
        // and screen right top points            
        edgePoints[0] = leftTop;
        edgePoints[1] = rightTop;

        // Position the top wall edge collider
        // at the top edge of the camera
        TopWall.points = edgePoints;
    }
}
