using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Test_Raycast : MonoBehaviour
{
   
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private GameObject referenceObject;

    private void Update() {
        if(Input.GetMouseButtonDown(1))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            

            if(Physics.Raycast(ray,out RaycastHit hit))
            {
                   Debug.Log($"<color=yellow>Hit: {hit.collider.gameObject.name}</color>");
                    GameObject cubeObject = hit.transform.gameObject;

                    // ヒットした位置を小さい四角形のローカル座標に変換
                    Vector3 localHitPoint = cubeObject.transform.InverseTransformPoint(hit.point);
                    Debug.Log($"<color=yellow>HitLocalPoint: {localHitPoint}</color>");

                    // 小さい四角形にオブジェクトを配置
                    Vector3 worldLocalHitPoint = cubeObject.transform.TransformPoint(localHitPoint);
                    Instantiate(spawnObject, worldLocalHitPoint, Quaternion.identity, cubeObject.transform);


                    // 大きい四角形のワールド座標を計算
                    Vector3 worldReferencePoint = referenceObject.transform.TransformPoint(localHitPoint);
         
                    // 大きい四角形にオブジェクトを配置
                    Instantiate(spawnObject, worldReferencePoint, Quaternion.identity, referenceObject.transform);


            }
        }
    }



}
