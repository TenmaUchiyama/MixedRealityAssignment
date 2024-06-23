using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenObjectManager : MonoBehaviour
{
    public bool isCollided = false;
    public GameObject objectToInstantiate; // ��������I�u�W�F�N�g�̃v���n�u
    public Vector3 instantiatePosition; // ��������ʒu

    public void OnCollisionNotified()
    {
        if (!isCollided)
        {
            isCollided = true;
            Debug.Log("Collision detected by Virtual Room");
            // �w�肵���ʒu�ɃI�u�W�F�N�g�𕡐�
            Instantiate(objectToInstantiate, instantiatePosition, Quaternion.identity);
        } 
        else
        {
            Debug.Log("Delete the object");
        }
    }
}
