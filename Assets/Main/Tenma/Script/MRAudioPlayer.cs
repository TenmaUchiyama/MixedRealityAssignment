using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MRAudioPlayer : MonoBehaviour
{
     public static MRAudioPlayer Instance;

        [SerializeField] private GameObject audioSourcePrefab;
     
     

    [SerializeField] private AudioSO audioSO;
     private void Awake() {
        
        if(Instance == null)
        {
            Instance = this; 
        }
        else
        {
            Destroy(this); 
        }
     }

 



      public void PlayWallDestroySound(Vector3 position)
   {
       PlaySound(audioSO.wallDestroySound, position);
   }


    public void PlayWallReconstructSound(Vector3 position)
    {
         PlaySound(audioSO.wallReconstructSound, position);
    }

   private void PlaySound(AudioClip clip, Vector3 position)
   {
          GameObject audioSourceObject = Instantiate(audioSourcePrefab, position, Quaternion.identity);
        AudioSource audioSource = audioSourceObject.GetComponent<AudioSource>();

        if (audioSource != null)
        {
            audioSource.clip = clip;
            audioSource.spatialBlend = 1f; // 完全な3Dサウンド
            audioSource.minDistance = 1f;
            audioSource.maxDistance = 500f; // 必要に応じて調整
            audioSource.rolloffMode = AudioRolloffMode.Linear; // 必要に応じて変更
            audioSource.Play();
            
            // 再生が終わったらAudioSourceを破棄
            Destroy(audioSourceObject, clip.length); 
    }
   }



}
