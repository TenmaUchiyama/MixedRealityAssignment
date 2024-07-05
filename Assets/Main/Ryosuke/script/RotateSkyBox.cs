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
        // �R���[�`���̋N��
        StartCoroutine(DelayCoroutine());

        RenderSettings.skybox = sunsetSkyMaterial;
    }

    // �R���[�`���{��
    private IEnumerator DelayCoroutine()
    {
        // 3�b�ԑ҂�
        yield return new WaitForSeconds(3);
        RenderSettings.skybox = eveningSkyMaterial;
        // 3�b�ԑ҂�
        yield return new WaitForSeconds(3);
        RenderSettings.skybox = nightSkyMaterial;

    }
}