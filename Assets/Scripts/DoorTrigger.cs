using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DoorTrigger : MonoBehaviour
{
    public Flowchart flowchart; // Inspector 拖拉到場上的 Flowchart
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Player")) // Player要有Tag
        {
            triggered = true; // 避免重複
            flowchart.ExecuteBlock("DoorChoice");
        }
    }
}
    