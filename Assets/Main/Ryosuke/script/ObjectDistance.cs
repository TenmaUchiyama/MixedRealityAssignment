
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDistance : MonoBehaviour
{
    public float moveSpeed = 5.0f; // 移動速度

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // 水平方向の移動
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;   // 垂直方向の移動

        transform.position += new Vector3(0, moveY, moveX); // オブジェクトの位置を更新
    }
}