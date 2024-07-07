
using Oculus.Interaction;
using UnityEngine;

public class HandTracker : MonoBehaviour
{
   [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer; 
   [SerializeField] OVRSkeleton hand; 
   [SerializeField] GameObject skyboxSelectorPrefab;
   [SerializeField] ActiveStateGroup armFaceActiveState;
   [SerializeField] float objectOffset =0.03f;
   



    private bool isObjectVisible = false;
    private bool isArmFaceActive = false;


    private void Start() {
      
    }

   private void Update() {

      
        
         if (skinnedMeshRenderer.enabled && armFaceActiveState.Active) {
              if(!isObjectVisible) {
                 
                        skyboxSelectorPrefab.SetActive(true);
                        isObjectVisible = true;
           
              }
    
         }

         if(!skinnedMeshRenderer.enabled || !armFaceActiveState.Active) {
             
                if(isObjectVisible) {
                        skyboxSelectorPrefab.SetActive(false);
                        isObjectVisible = false;
                }
              
              
         }


        if(isObjectVisible && hand.Bones.Count > 0) {
            Vector3 index = hand.Bones[(int)OVRSkeleton.BoneId.Hand_Index1].Transform.position;
            Vector3 middle = hand.Bones[(int)OVRSkeleton.BoneId.Hand_Middle1].Transform.position;
            Vector3 ring = hand.Bones[(int)OVRSkeleton.BoneId.Hand_Ring1].Transform.position;
            Vector3 pinky = hand.Bones[(int)OVRSkeleton.BoneId.Hand_Pinky1].Transform.position;
            Vector3 thumb = hand.Bones[(int)OVRSkeleton.BoneId.Hand_Thumb1].Transform.position;

            // 手のひらの中心位置を計算
            Vector3 palmPosition = (index + middle + ring + pinky + thumb) / 5;
            Quaternion wristRotation = hand.Bones[(int)OVRSkeleton.BoneId.Hand_WristRoot].Transform.rotation;

            // 手のひらの法線方向を計算（親指から小指へのベクトルと手首の回転を使用）
            Vector3 palmNormal = Vector3.Cross(thumb - pinky, wristRotation * Vector3.forward).normalized;

            // 手のひらの法線方向に少しオフセットを追加してオブジェクトを配置
            float offsetDistance = -0.03f; // 手のひらからのオフセット距離を調整
            Vector3 offsetPosition = palmPosition + palmNormal * offsetDistance;

            skyboxSelectorPrefab.transform.position = offsetPosition;
            skyboxSelectorPrefab.transform.LookAt(Camera.main.transform.position);

         }
   }

   
}
