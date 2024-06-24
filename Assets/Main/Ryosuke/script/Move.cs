using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //GameObject型を変数pointで宣言します。
    public GameObject point;
    //GameObject型を変数charaで宣言します。
    public GameObject chara;
    public GameObject target;

    //コライダーが乗った時の関数
    private void OnTriggerEnter(Collider other)
    {
        //もしゴールオブジェクトのコライダーに接触した時の処理。
        if (other.name == chara.name)
        {
            //Charaが接触したらpointオブジェクトの位置に移動！
            //chara.transform.position = point.transform.position;

            Instantiate(target, point.transform.position, Quaternion.identity);
            Destroy(chara, .1005f);
        }
    }

    
}
