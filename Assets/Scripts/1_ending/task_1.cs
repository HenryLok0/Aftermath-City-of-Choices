using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TaskOneTrigger : MonoBehaviour
{
    // Assign your player and flowchart in the Inspector
    public Transform player;
    public Flowchart flowchart;
    private bool triggered = false; // Ensures only one trigger

    void Update()
    {
        Vector2 playerPos = new Vector2(player.position.x, player.position.y);
        // Area bounds: X from -5 to 4, Y from -2 to 0
        if (!triggered &&
            playerPos.x >= -5 && playerPos.x <= 3 &&
            playerPos.y >= 4 && playerPos.y <= 7)
        {
            flowchart.ExecuteBlock("Task 1");
            triggered = true;
        }

        // Optional: Reset 'triggered' when player leaves area
        if (triggered &&
            (playerPos.x < -5 || playerPos.x > 4 ||
             playerPos.y < -2 || playerPos.y > 0))
        {
            triggered = false;
        }
    }
}
