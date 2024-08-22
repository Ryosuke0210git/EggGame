using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSystem : MonoBehaviour
{
    [Header("再生するパーティクル")]
    public GameObject particleObject;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Egg") //Eggタグ付きゲームオブジェクト（卵）と衝突したか
        {
            Instantiate(particleObject, this.transform.position, Quaternion.identity); //パーティクル用オブジェクト生成
        }
    }
}
