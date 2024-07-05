using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkyBox : MonoBehaviour
{

    [SerializeField] Material sunsetSkyMaterial;
    [SerializeField] Material nightSkyMaterial;
    [SerializeField] Material eveningSkyMaterial;


    void Start()
    {
        // コルーチンの起動
        StartCoroutine(DelayCoroutine());

        RenderSettings.skybox = sunsetSkyMaterial;
    }

    // コルーチン本体
    private IEnumerator DelayCoroutine()
    {
        // 3秒間待つ
        yield return new WaitForSeconds(3);
        RenderSettings.skybox = eveningSkyMaterial;
        // 3秒間待つ
        yield return new WaitForSeconds(3);
        RenderSettings.skybox = nightSkyMaterial;

    }
}