using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentFlowchart : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
