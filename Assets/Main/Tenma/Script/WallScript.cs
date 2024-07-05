using System;
using System.Collections;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using UnityEngine;

public class WallScript : MonoBehaviour
{
  
  private const string HAMMER_HEAD_TAG = "HammerHead";
  [SerializeField] WallDirection thisWallDirection;

  private Dictionary<WallDirection, MRUKAnchor> wallDirections;


  private void Start() {

    
    wallDirections = SmallHouse.Instance.GetWallDirections();
  }



   void OnTriggerEnter(Collider other)
   {    
        
        if(other.gameObject.tag != HAMMER_HEAD_TAG) return;
        SmallHouse.Instance.ColorDebug(thisWallDirection, "red");

        if(wallDirections == null) return;

        MRUKAnchor thisWall = wallDirections[thisWallDirection];
        DestroyWall(thisWall);
        
   }



   private void DestroyWall(MRUKAnchor wall)
   {

         GameObject wallChild = wall.gameObject.transform.GetChild(0).gameObject;

         MeshRenderer renderer = wallChild.GetComponent<MeshRenderer>();
         Debug.Log($"Renderer: {renderer}");
         renderer.enabled = false;

         renderer = this.gameObject.GetComponent<MeshRenderer>();
        renderer.enabled = false;
       
    
        
         
   }
}
