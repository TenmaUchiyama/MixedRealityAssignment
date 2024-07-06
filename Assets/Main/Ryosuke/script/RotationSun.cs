using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class RotationSun : MonoBehaviour
{
    private const string LIGHT_TAG = "MainLight";
    public GameObject smallhouse;

    public float maxDistance = 10f; // Maximum distance where intensity should start decreasing
    public float maxIntensity = 1f; // Maximum intensity when objects are very close


    private Light directionalLight; 

    // Start is called before the first frame update
    void Start()
    {
        directionalLight = GameObject.FindWithTag(LIGHT_TAG).GetComponent<Light>(); 

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 housepos = smallhouse.transform.position;
        Vector3 sunpos = this.transform.position;
        Vector3 direction = housepos - sunpos;

        float dis = Vector3.Distance(housepos, sunpos);
     

        // Calculate intensity based on distance
        float intensity = (1f / (dis * dis + 1f)) * 2f; // ����`�Ȋ֐���

        // Apply the intensity to the directional light
        directionalLight.intensity = intensity;

        // �x�N�g���̐��K��
        direction.Normalize();

        // �����̌������x�N�g���̕����ɍ��킹�ĉ�]������
        directionalLight.transform.rotation = Quaternion.LookRotation(direction);
    }
}
