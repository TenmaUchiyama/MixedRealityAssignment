using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered"); 
        Debug.Log($"<color=red>Triggered: {other.gameObject.name}</color>");
    }
}
