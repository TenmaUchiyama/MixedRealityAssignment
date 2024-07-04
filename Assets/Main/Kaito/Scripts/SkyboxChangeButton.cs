using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChangeButton : MonoBehaviour
{
    public string ToMode;
    public GameObject managerObject;

    // ボタンに触れさせたら空のマテリアルを変えたい物体のTagを記入
    public string ProjectileTagName = "Projectile";

    void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトがProjectileタグを持っているか確認
        if (collision.gameObject.CompareTag(ProjectileTagName))
        {
            SkyManager skyManager = managerObject.GetComponent<SkyManager>();
            skyManager.SkymodeChangeTo(ToMode);
        }

        Destroy(collision.gameObject);
    }
}
