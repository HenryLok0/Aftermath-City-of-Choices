using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class BackpackTrigger : MonoBehaviour
{
    public Flowchart flowchart;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            flowchart.ExecuteBlock("PickupBackpack");
            Destroy(gameObject);
        }
    }
}
