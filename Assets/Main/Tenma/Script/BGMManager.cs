using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[Serializable]
public class BGMData
{

    public SkyType skyType;
    public BGMComponent[] Front; 
    public BGMComponent[] Right; 
    public BGMComponent[] Left; 
    public BGMComponent[] Ceiling; 
    public BGMComponent[] Behind; 

}

public class BGMManager : MonoBehaviour
{

    public static BGMManager Instance { get; private set; }
   [SerializeField] List<BGMData> bgmDataList;
    private SkyType currentSkyType = SkyType.Daytime;   

    private Dictionary<WallDirection, bool> activeWallDirection = new Dictionary<WallDirection, bool>{
        {WallDirection.Front, false},
        {WallDirection.Right, false},
        {WallDirection.Left, false},
        {WallDirection.Ceiling, false},
        {WallDirection.Behind, false}

    };

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



    public void SetCurrentTime(SkyType skyType)
    {
    
        StopAllSoundInTheTime(currentSkyType);
        currentSkyType = skyType;
        PlayBGM();
        
    }


    private void StopAllSoundInTheTime(SkyType skyType) 
    {
         foreach(BGMData bgmData in bgmDataList )
        {
            if(bgmData.skyType == skyType)
            {
                StopBGM(bgmData.Front);
                StopBGM(bgmData.Right);
                StopBGM(bgmData.Left);
                StopBGM(bgmData.Ceiling);
                StopBGM(bgmData.Behind);
            }
        }

    }


    public void SetWallDirectionDeactive(WallDirection wallDirection)
    {
        activeWallDirection[wallDirection] = false;
        StopBGM();
    }

 

    public void SetWallDirectionActive(WallDirection wallDirection)
    {
     
        activeWallDirection[wallDirection] = true;
        PlayBGM();
    }


    public void PlayBGM()
    {
            
        foreach (BGMData bgm in bgmDataList)
        {
            if (bgm.skyType == currentSkyType)
            {
                if (activeWallDirection[WallDirection.Front])
                {
                    PlayBGM(bgm.Front);
                }
                if (activeWallDirection[WallDirection.Right])
                {
                    PlayBGM(bgm.Right);
                }
                if (activeWallDirection[WallDirection.Left])
                {
                    PlayBGM(bgm.Left);
                }
                if (activeWallDirection[WallDirection.Ceiling])
                {
                    PlayBGM(bgm.Ceiling);
                }
                if (activeWallDirection[WallDirection.Behind])
                {
                    PlayBGM(bgm.Behind);
                }
            }
        }

    }

    private void PlayBGM(BGMComponent[] audioComponents)
    {
        foreach (BGMComponent bgmComponent in audioComponents)
        {
            if(bgmComponent.IsPlaying) continue;
            bgmComponent.StartSound();
        }
    }

    
    private void StopBGM()
    {
        foreach (BGMData bgm in bgmDataList)
        {
            if (bgm.skyType == currentSkyType)
            {
                if (!activeWallDirection[WallDirection.Front])
                {
                    StopBGM(bgm.Front);
                }
                if (!activeWallDirection[WallDirection.Right])
                {
                    StopBGM(bgm.Right);
                }
                if (!activeWallDirection[WallDirection.Left])
                {
                    StopBGM(bgm.Left);
                }
                if (!activeWallDirection[WallDirection.Ceiling])
                {
                    StopBGM(bgm.Ceiling);
                }
                if (!activeWallDirection[WallDirection.Behind])
                {
                    StopBGM(bgm.Behind);
                }
            }
        }
    }


    private void StopBGM(BGMComponent[] audioComponents)
    {
        foreach (BGMComponent bgmComponent in audioComponents)
        {
            if(!bgmComponent.IsPlaying) continue;
            bgmComponent.StopSound();
        }
    }

}
