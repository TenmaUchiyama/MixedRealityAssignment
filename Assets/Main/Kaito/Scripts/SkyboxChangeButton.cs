using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChangeButton : MonoBehaviour
{
    public string ToMode;
    public GameObject managerObject;

    // �{�^���ɐG�ꂳ�������̃}�e���A����ς��������̂�Tag���L��
    public string ProjectileTagName = "Projectile";

    void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g��Projectile�^�O�������Ă��邩�m�F
        if (collision.gameObject.CompareTag(ProjectileTagName))
        {
            SkyManager skyManager = managerObject.GetComponent<SkyManager>();
            skyManager.SkymodeChangeTo(ToMode);
        }

        Destroy(collision.gameObject);
    }
}
