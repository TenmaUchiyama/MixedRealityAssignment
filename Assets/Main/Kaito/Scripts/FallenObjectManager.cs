using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenObjectManager : MonoBehaviour
{
    public bool isCollided = false;
    public GameObject objectToInstantiate; // 複製するオブジェクトのプレハブ
    public Vector3 instantiatePosition; // 複製する位置

    public void OnCollisionNotified()
    {
        if (!isCollided)
        {
            isCollided = true;
            Debug.Log("Collision detected by Virtual Room");
            // 指定した位置にオブジェクトを複製
            Instantiate(objectToInstantiate, instantiatePosition, Quaternion.identity);
        } 
        else
        {
            Debug.Log("Delete the object");
        }
    }
}
