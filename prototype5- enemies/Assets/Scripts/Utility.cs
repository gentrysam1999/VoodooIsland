using UnityEngine;

public class Utility : MonoBehaviour
{

    // Returns true if game object is visible by the specified camera,
    // otherwise returns false.
    public static bool isVisible(Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }
}
