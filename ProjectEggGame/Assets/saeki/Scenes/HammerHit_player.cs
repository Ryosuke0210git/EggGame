using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//--------------------------------
//  作成者：ふじわら　作成日：2024/07/29
//--------------------------------
//  ハンマーが壁に当たった時のプレイヤー処理
//  プレイヤーを破壊し、エフェクトのオブジェクトを生成する
//--------------------------------
public class HammerHit_player : HammerHit
{
    [Header("エフェクトのプレハブ"), SerializeField]
    private GameObject effectPrefab;

    override protected void HitPlay( Collision collision )
    {
        // プレイヤーを破壊
        Destroy(gameObject);

        Debug.Log( "プレイヤーを破壊しました" );

        // エフェクトのプレハブを生成
        GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
    }
}
