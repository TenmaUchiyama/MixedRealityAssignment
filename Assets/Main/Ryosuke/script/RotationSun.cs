using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSun : MonoBehaviour
{
    public GameObject smallhouse;
    public GameObject smallsun;
    public Light directionalLight;

    public float maxDistance = 10f; // Maximum distance where intensity should start decreasing
    public float maxIntensity = 1f; // Maximum intensity when objects are very close


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 housepos = smallhouse.transform.position;
        Vector3 sunpos = smallsun.transform.position;
        Vector3 direction = housepos - sunpos;

        float dis = Vector3.Distance(housepos, sunpos);
        Debug.Log("�����́F" + dis);
        

        // Calculate intensity based on distance
        float intensity = 1f / (dis * dis + 1f); // ����`�Ȋ֐���

        // Apply the intensity to the directional light
        directionalLight.intensity = intensity;

        // �x�N�g���̐��K��
        direction.Normalize();

        // �����̌������x�N�g���̕����ɍ��킹�ĉ�]������
        directionalLight.transform.rotation = Quaternion.LookRotation(direction);
    }
}
