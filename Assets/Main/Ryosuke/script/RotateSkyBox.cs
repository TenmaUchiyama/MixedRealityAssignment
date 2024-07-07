
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum SkyType
{
    Daytime, 
    Sunset,
    Night
}

public class RotateSkyBox : MonoBehaviour
{


    public static RotateSkyBox Instance { get; private set; }
    
    [SerializeField] List<SkyMaterialSO> skyMaterials;
    [SerializeField] Image sunsetSkyIcon; 


    private int currentSkyInd = (int)SkyType.Daytime;


    public SkyType GetCurrentSkyType()
    {
      return (SkyType)currentSkyInd;
    }
    private void Start() {
        RenderSettings.skybox = GetRandomMaterial(skyMaterials[currentSkyInd].skyMaterials);
        sunsetSkyIcon.sprite = skyMaterials[currentSkyInd].skySprite;
      
    }
  

    public void ChangeSkyBox()
    {
         currentSkyInd = (currentSkyInd + 1) % skyMaterials.Count;
        RenderSettings.skybox = GetRandomMaterial(skyMaterials[currentSkyInd].skyMaterials);
        sunsetSkyIcon.sprite = skyMaterials[currentSkyInd].skySprite;
        BGMManager.Instance.SetCurrentTime((SkyType)currentSkyInd);
    }

    private Material GetRandomMaterial(List<Material> materials)
    {
        int randomIndex = Random.Range(0, materials.Count );
        return materials[randomIndex];
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChangeSkyBox();
        }
    }


}