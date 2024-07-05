using System;
using System.Collections;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using UnityEngine;

public class WallScript : MonoBehaviour
{
  
  private const string HAMMER_HEAD_TAG = "HammerHead";
  private const string WAND_HEAD_TAG = "WandHead";
  [SerializeField] WallDirection thisWallDirection;

  private Dictionary<WallDirection, MRUKAnchor> wallDirections;


  private void Start() {

    
    wallDirections = SmallHouse.Instance.GetWallDirections();
  }



   void OnTriggerEnter(Collider other)
   {    
        
        if(other.gameObject.tag == HAMMER_HEAD_TAG) {
        SmallHouse.Instance.ColorDebug(thisWallDirection, "red");

        if(wallDirections == null) return;

        MRUKAnchor thisWall = wallDirections[thisWallDirection];
        DestroyWall(thisWall);
        }


        if(other.gameObject.tag == WAND_HEAD_TAG) {
        SmallHouse.Instance.ColorDebug(thisWallDirection, "green");

        if(wallDirections == null) return;

        MRUKAnchor thisWall = wallDirections[thisWallDirection];
        RestoreWall(thisWall);

        }
   }


   
  private void RestoreWall(MRUKAnchor wall) 
  {
    GameObject wallChild = wall.gameObject.transform.GetChild(0).gameObject;

    MeshRenderer renderer = wallChild.GetComponent<MeshRenderer>();
    renderer.enabled = true;

    renderer = this.gameObject.GetComponent<MeshRenderer>();
    renderer.enabled = true;
  }

   private void DestroyWall(MRUKAnchor wall)
   {

         GameObject wallChild = wall.gameObject.transform.GetChild(0).gameObject;

         MeshRenderer renderer = wallChild.GetComponent<MeshRenderer>();
         renderer.enabled = false;

         renderer = this.gameObject.GetComponent<MeshRenderer>();
         renderer.enabled = false;
       
    
        
         
   }
}
