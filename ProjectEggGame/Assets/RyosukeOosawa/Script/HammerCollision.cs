using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerCollision : MonoBehaviour
{
    [Header("再生するパーティクル1")]
    public GameObject particleObject1;

    public bool GameEnd = false;  //ゲーム終了を判定するフラグ           
    public float WinPlayer = 1;   //どちらのプレイヤーが勝ったかを判定するフラグ

    // オフセットのベクトルを定義します（ローカル座標系でのオフセット）
    Vector3 localOffset = new Vector3(-18.0f, 8.0f, 0.0f);

    void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトがプレイヤーかどうかを確認
        if (collision.gameObject.CompareTag("Egg"))
        {
            // ローカル座標系のオフセットをワールド座標系に変換します
            Vector3 worldOffset = this.transform.TransformDirection(localOffset);

            // 現在の座標にワールド座標系のオフセットを加えた新しい座標を計算します
            Vector3 newPosition = this.transform.position + worldOffset;

            // 回転を指定します（例えば、y軸を中心に90度回転）
            Quaternion rotation = Quaternion.Euler(0, 0, 0);

            // 新しい座標と回転でパーティクルオブジェクトを生成します
            Instantiate(particleObject1, newPosition, rotation);

            //// 衝突したオブジェクトの名前がPlayer1_Eggの場合
            //if (collision.gameObject.name == "Player1_Egg")
            //{
            //    WinPlayer = 1;
            //}
            //else
            //{
            //    WinPlayer = 2;
            //}

            // プレイヤーオブジェクトを破壊
            Destroy(collision.gameObject);

            // ゲーム終了フラグを立てる
            GameEnd = true;
        }
    }
}
