using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BGMSO", menuName = "ScriptableObjects/BGMSO", order = 1)]
public class BGMSO : ScriptableObject
{
    

    public List<AudioClip> FrontBGM; 
    public List<AudioClip> BackBGM;
    public List<AudioClip> LeftBGM;
    public List<AudioClip> RightBGM;
}
