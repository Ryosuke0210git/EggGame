using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerCollision : MonoBehaviour
{
    public bool GameEnd = false; //ゲーム終了を判定するフラグ
             
    public float WinPlayer=1;//どちらのプレイヤーが勝ったかを判定するフラグ

    void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトがプレイヤーかどうかを確認
        if (collision.gameObject.CompareTag("Egg"))
        {
            //衝突したオブジェクトの名前がPlayer1_Eggの場合
            if (collision.gameObject.name == "Player1_Egg")
            {
                WinPlayer = 1;
            }
            else
            {
                WinPlayer = 2;
            }

            // プレイヤーオブジェクトを破壊
            Destroy(collision.gameObject);

            // ゲーム終了フラグを立てる
            GameEnd = true;
        }
    }
}
