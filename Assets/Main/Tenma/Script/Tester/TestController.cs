using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestController : MonoBehaviour
{
   [SerializeField] Transform controller; 

    void Update()
    {
        Vector3 position = controller.position; 
        Vector3 rotation = controller.forward; 

        if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
           Debug.Log($"SecondaryIndexPressed");
          if(Physics.Raycast(position, rotation, out RaycastHit hit))
          {
                  Debug.Log($"Hit: {hit.collider.gameObject.name}");
                  MeshRenderer renderer = hit.collider.gameObject.GetComponent<MeshRenderer>();

                  if(renderer.enabled)
                  {
                      renderer.enabled = false;
                  }
                  else
                  {
                      renderer.enabled = true;
                  }
             
          }
        }
    }
}
