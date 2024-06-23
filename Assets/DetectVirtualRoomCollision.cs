using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectVirtualRoomCollision : MonoBehaviour
{
    // OnTriggerEnter�̓g���K�[�R���C�_�[�ɂ��Փˌ��o
    private void OnTriggerEnter(Collider other)
    {
        FallenObjectManager fallenObjManager = other.GetComponent<FallenObjectManager>();
        
        if (fallenObjManager != null)
        {
            fallenObjManager.OnCollisionNotified();
        }
    }
}
