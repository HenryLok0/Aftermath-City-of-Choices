using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawnAndCameraBounds : MonoBehaviour
{
    public Transform player;       // 玩家物件
    public Transform cameraObj;    // 攝影機物件

    public Vector3 spawnPoint = new Vector3(0, 0, 0);  // 玩家出生
    public Vector2 minBound = new Vector2(-10, -8);    // 移動&攝影機限制最小
    public Vector2 maxBound = new Vector2(10, 8);      // 移動&攝影機限制最大
    public float cameraSmooth = 0.1f;
    public Vector3 cameraOffset = new Vector3(0, 0, -10);

    void Start()
    {
        if (player != null)
            player.position = spawnPoint;
        if (cameraObj != null)
            cameraObj.position = spawnPoint + cameraOffset;
    }

    void Update()
    {
        // 玩家移動範圍限制
        if (player != null)
        {
            Vector3 p = player.position;
            float px = Mathf.Clamp(p.x, minBound.x, maxBound.x);
            float py = Mathf.Clamp(p.y, minBound.y, maxBound.y);
            player.position = new Vector3(px, py, p.z); // 更新玩家座標
        }
    }

    void LateUpdate()
    {
        // 攝影機 Clamp 同前
        if (player == null || cameraObj == null) return;

        Camera cam = cameraObj.GetComponent<Camera>();
        float vertExtent = cam.orthographicSize;
        float horzExtent = cam.orthographicSize * cam.aspect;

        Vector3 targetPos = player.position + cameraOffset;
        float clampX = Mathf.Clamp(targetPos.x, minBound.x + horzExtent, maxBound.x - horzExtent);
        float clampY = Mathf.Clamp(targetPos.y, minBound.y + vertExtent, maxBound.y - vertExtent);
        Vector3 clampPos = new Vector3(clampX, clampY, targetPos.z);

        cameraObj.position = Vector3.Lerp(cameraObj.position, clampPos, cameraSmooth);
    }
}
