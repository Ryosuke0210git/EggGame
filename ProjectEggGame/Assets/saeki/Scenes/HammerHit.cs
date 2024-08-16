using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//--------------------------------
//  作成者：ふじわら　作成日：2024/07/29
//--------------------------------
//  ハンマーが壁に当たった時の処理
//--------------------------------

public class HammerHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // hanmmerレイヤーに当たったら
        if (collision.gameObject.layer == LayerMask.NameToLayer("hammer"))
        {
            Debug.Log( "破壊しました" );

            HitPlay( collision );
        }
    }

    virtual protected void HitPlay( Collision collision )
    {
        // hanmmerレイヤーに当たったら
    }
}
