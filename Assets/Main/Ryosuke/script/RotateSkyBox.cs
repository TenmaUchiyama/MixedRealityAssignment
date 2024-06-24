using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkyBox : MonoBehaviour
{

    [SerializeField] Material sunsetSkyMaterial;
    [SerializeField] Material nightSkyMaterial;


    void Start()
    {
        RenderSettings.skybox = sunsetSkyMaterial;
    }

    void Update()
    {
        //エンターキーが入力された場合「true」
        if (Input.GetKey(KeyCode.Return))
        {
            RenderSettings.skybox = nightSkyMaterial;
        }
    }
}