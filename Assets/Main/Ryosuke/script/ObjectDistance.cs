
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDistance : MonoBehaviour
{
    public float moveSpeed = 5.0f; // �ړ����x

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // ���������̈ړ�
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;   // ���������̈ړ�

        transform.position += new Vector3(0, moveY, moveX); // �I�u�W�F�N�g�̈ʒu���X�V
    }
}