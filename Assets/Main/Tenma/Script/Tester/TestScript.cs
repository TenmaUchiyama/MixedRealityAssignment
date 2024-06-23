using System.Collections;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using Unity.Collections;
using UnityEngine;

public class TestScript : MonoBehaviour
{


  [SerializeField] Transform pointToMove;

  private void Update() {
    if(Input.GetKeyDown(KeyCode.Space))
    {
       Debug.Log($"<color=yellow>Space Pressed</color>");
       var rooms = MRUK.Instance.Rooms;
       Debug.Log($"<color=yellow>MRUK: {rooms.Count}</color>");
       Debug.Log($"<color=red>MRUK: {MRUK.Instance.GetCurrentRoom()}</color>");

      foreach(var room in MRUK.Instance.Rooms)
      {
         
        if(room == MRUK.Instance.GetCurrentRoom()) 
        {
          Debug.Log($"<color=green>This Room: {room.ToString()}</color>");
          Debug.Log($"<color=green>This Room: {room.CeilingAnchor}</color>");
          
           
          GameObject roomObject = GameObject.Find(room.gameObject.name); 
          Debug.Log($"<color=red>{roomObject != null}</color>");
          if(roomObject)
          {
            Debug.Log($"<color=red>Room Found</color>");
            
            roomObject.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
            roomObject.transform.position = pointToMove.position;
            
          }

          
        }
        Debug.Log($"<color=yellow>MRUK: {room}</color>");
    
      }
    }
  }
}
