using UnityEngine;
using UnityEngine.InputSystem;
using Fungus;

public class PlayerInteract : MonoBehaviour
{
    public GameObject backpackObj;
    public float pickupDistance = 1.2f;

    public Flowchart flowchart; // Inspector拖入

    // --- 新增這行 ---
    private bool hasPickUpBackpack = false;
    private bool firedAlready = false; // 保證只觸發一次

    private void Update()
    {
        // 拾取背包（F鍵）
        if (backpackObj != null)
        {
            float dist = Vector2.Distance(transform.position, backpackObj.transform.position);
            if (dist < pickupDistance)
            {
                Debug.Log("Press F [F] to pickup Backpack");
                if (Keyboard.current.fKey.wasPressedThisFrame)
                {
                    if (flowchart != null)
                        flowchart.ExecuteBlock("PickupBackpack");
                    Destroy(backpackObj);
                    hasPickUpBackpack = true;      // 標記已撿到
                }
            }
        }

        // 走到(-8,8)自動觸發DoorChoice
        if (hasPickUpBackpack && !firedAlready &&
            flowchart != null &&
            Vector2.Distance(transform.position, new Vector2(-8f, 8f)) < 1.0f)
        {
            firedAlready = true;
            flowchart.ExecuteBlock("DoorChoice");
        }
    }
}
