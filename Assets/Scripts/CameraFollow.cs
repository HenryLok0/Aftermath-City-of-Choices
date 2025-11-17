using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 0, -10);

    // 八個場景傳送點/初始視角座標
    public Vector3[] scenePositions = new Vector3[]
    {
        new Vector3(8, 8, -10),    // 場景1
        new Vector3(23, -7, -10),  // 場景2
        new Vector3(40, 5, -10),   // 場景3 ...
        new Vector3(60, 8, -10),
        new Vector3(80, -2, -10),
        new Vector3(105, 6, -10),
        new Vector3(130, 0, -10),
        new Vector3(155, -5, -10)
    };

    public Vector2[] minBounds = new Vector2[]
    {
        new Vector2(-10, -8),  // 場景1
        new Vector2(20, -8),   // 場景2
        new Vector2(36, 1),
        new Vector2(58, 6),
        new Vector2(76, -7),
        new Vector2(100, 1),
        new Vector2(126, -4),
        new Vector2(151, -9)
    };
    public Vector2[] maxBounds = new Vector2[]
    {
        new Vector2(10, 8),   // 場景1
        new Vector2(41, 8),   // 場景2
        new Vector2(44, 9),
        new Vector2(62, 10),
        new Vector2(84, 2),
        new Vector2(110, 10),
        new Vector2(134, 8),
        new Vector2(159, 3)
    };

    private int currentRegion = 0;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        Camera cam = GetComponent<Camera>();
        float vertExtent = cam.orthographicSize;
        float horzExtent = cam.orthographicSize * cam.aspect;

        // Clamp到當前指定區域
        float clampX = Mathf.Clamp(desiredPosition.x, minBounds[currentRegion].x + horzExtent, maxBounds[currentRegion].x - horzExtent);
        float clampY = Mathf.Clamp(desiredPosition.y, minBounds[currentRegion].y + vertExtent, maxBounds[currentRegion].y - vertExtent);

        Vector3 clampedPosition = new Vector3(clampX, clampY, desiredPosition.z);

        transform.position = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);
    }

    // Fungus專用，傳送並切Clamp
    public void TeleportCameraToScene(int sceneIndex)
    {
        if (sceneIndex >= 0 && sceneIndex < scenePositions.Length)
        {
            currentRegion = sceneIndex;
            transform.position = scenePositions[sceneIndex];
        }
    }
}
