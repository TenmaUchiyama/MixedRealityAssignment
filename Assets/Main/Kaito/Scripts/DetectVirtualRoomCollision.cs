using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectVirtualRoomCollision : MonoBehaviour
{
    // OnTriggerEnterはトリガーコライダーによる衝突検出
    private void OnTriggerEnter(Collider other)
    {
        FallenObjectManager fallenObjManager = other.GetComponent<FallenObjectManager>();
        
        if (fallenObjManager != null)
        {
            fallenObjManager.OnCollisionNotified();
        }
    }
}
