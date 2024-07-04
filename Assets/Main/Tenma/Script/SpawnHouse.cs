using System;
using System.Collections;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpawnHouse : MonoBehaviour
{
   [SerializeField] GameObject gameObject; 


   private void Start() {
    MRUK.Instance.RoomCreatedEvent.AddListener(OnRoomLoaded); 
   }

    private void OnRoomLoaded(MRUKRoom room)
    {

        

        if( room != MRUK.Instance.GetCurrentRoom()) return; 

        var anchors = room.Anchors;
        List<MRUKAnchor> tables = new List<MRUKAnchor>();
        List<MRUKAnchor> walls = new List<MRUKAnchor>(); 
        foreach(var anchor in anchors)
        {
            if(anchor.HasAnyLabel(MRUKAnchor.SceneLabels.TABLE))
            {
                tables.Add(anchor); 
            }

            if(anchor.HasAnyLabel(MRUKAnchor.SceneLabels.WALL_FACE))
            {
                walls.Add(anchor); 
            }
        }

        MRUKAnchor nearestTable = this.ExtractNearestTable(tables); 
        gameObject.transform.position = nearestTable.gameObject.transform.position;
        Vector3 roomFaceDirection = room.GetFacingDirection(nearestTable); 
        float originalAngle = Mathf.Atan2(roomFaceDirection.z, roomFaceDirection.x) * Mathf.Rad2Deg;
        Vector3 rotatedDirection = Quaternion.Euler(0, 90, 0) * roomFaceDirection;
        Vector3 rotatedDirection2 = Quaternion.Euler(0, 90, 0) * rotatedDirection;
        Vector3 rotatedDirection3 = Quaternion.Euler(0, 90, 0) * rotatedDirection2;
          ColorDebug("Original " + roomFaceDirection, "yellow");
          ColorDebug("Rotated " + rotatedDirection, "yellow");
          ColorDebug("LocalRotated " + (Mathf.Atan2(roomFaceDirection.z, rotatedDirection.x) * Mathf.Rad2Deg), "yellow");
          ColorDebug("LocalRotated " + (Mathf.Atan2(roomFaceDirection.z, rotatedDirection2.x) * Mathf.Rad2Deg), "yellow");
          ColorDebug("LocalRotated " + (Mathf.Atan2(roomFaceDirection.z, rotatedDirection3.x) * Mathf.Rad2Deg), "yellow");

          

        gameObject.transform.forward = roomFaceDirection;
        ClassifyWall(walls, gameObject, roomFaceDirection);
       
    }



    private void ClassifyWall(List<MRUKAnchor> walls, GameObject houseObject, Vector3 direction) 
    {
        foreach(MRUKAnchor wall in walls)
        {
            Vector3 wallPosition = wall.transform.position; 
            
            var wallDirection = (wallPosition- houseObject.transform.position);
            var WallDirectionInObject  = houseObject.transform.InverseTransformDirection(wallDirection); 
            

            ColorDebug(WallDirectionInObject, "yellow");
        }
        
    }



    private MRUKAnchor ExtractNearestTable(List<MRUKAnchor> anchors)
    {
        Vector3 cameraPosition = Camera.main.transform.position;

        MRUKAnchor nearestAnchor = anchors[0]; 
        float closestDistance = Mathf.Infinity;
        
        foreach(MRUKAnchor anchor in anchors)
        {
            Vector3 anchorPosition = anchor.gameObject.transform.position;

            float distance = Vector3.Distance(cameraPosition, anchorPosition);

            if(distance < closestDistance)
            {
                closestDistance = distance;
                nearestAnchor = anchor;
            }
        }


        return nearestAnchor;
    }

    private void ColorDebug<T>(T msg, string color = "yellow")
    {
        Debug.Log($"<color={color}>{msg}</color>");
    }
}
