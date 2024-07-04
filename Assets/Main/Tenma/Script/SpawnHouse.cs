using System;
using System.Collections;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpawnHouse : MonoBehaviour
{
   [SerializeField] GameObject housePrefab; 


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
        GameObject houseObject = Instantiate(housePrefab,nearestTable.transform.position,Quaternion.identity );
        
        Vector3 roomFaceDirection = room.GetFacingDirection(nearestTable); 
        

        houseObject.transform.forward = roomFaceDirection;


          
        ClassifyWall(walls, gameObject, roomFaceDirection);
       
    }



    private void ClassifyWall(List<MRUKAnchor> walls, GameObject houseObject, Vector3 roomDirection) 
    {
        foreach(MRUKAnchor wall in walls)
        {
            Vector3 housePosition = houseObject.transform.position; 
            wall.GetClosestSurfacePosition(housePosition, out Vector3 closestPosition);


            float angle = Vector3.SignedAngle(roomDirection, closestPosition, Vector3.up); 
           

             if (angle > -45f && angle <= 45f)
            {
               ColorDebug("Front: "+ angle);
            }
            else if (angle > 45f && angle <= 135f)
            {
               ColorDebug("Right: "+ angle);
            }
            else if (angle > 135f || angle <= -135f)
            {
                ColorDebug("Behind: "+ angle);
            }
            else if (angle > -135f && angle <= -45f)
            {
               ColorDebug("Left: "+ angle);
            }
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
