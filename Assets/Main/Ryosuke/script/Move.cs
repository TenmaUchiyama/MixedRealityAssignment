using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //GameObject�^��ϐ�point�Ő錾���܂��B
    public GameObject point;
    //GameObject�^��ϐ�chara�Ő錾���܂��B
    public GameObject chara;

    //�R���C�_�[����������̊֐�
    private void OnTriggerEnter(Collider other)
    {
        //�����S�[���I�u�W�F�N�g�̃R���C�_�[�ɐڐG�������̏����B
        if (other.name == chara.name)
        {
            //Chara���ڐG������point�I�u�W�F�N�g�̈ʒu�Ɉړ������I
            chara.transform.position = point.transform.position;

        }
    }
}
