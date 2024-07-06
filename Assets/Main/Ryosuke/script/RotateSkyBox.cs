using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class RotateSkyBox : MonoBehaviour
{


    [SerializeField] List<SkyMaterialSO> skyMaterials;


    private int currentSkyInd = 0;


  

    public void ChangeSkyBox()
    {
         currentSkyInd = (currentSkyInd + 1) % skyMaterials.Count;
        RenderSettings.skybox = GetRandomMaterial(skyMaterials[currentSkyInd].skyMaterials);
           
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


    // void Start()
    // {
    //     // �R���[�`���̋N��
    //     StartCoroutine(DelayCoroutine());

    //     RenderSettings.skybox = sunsetSkyMaterial;
    // }

    // // �R���[�`���{��
    // private IEnumerator DelayCoroutine()
    // {
    //     // 3�b�ԑ҂�
    //     yield return new WaitForSeconds(3);
    //     RenderSettings.skybox = eveningSkyMaterial;
    //     // 3�b�ԑ҂�
    //     yield return new WaitForSeconds(3);
    //     RenderSettings.skybox = nightSkyMaterial;

    // }
}