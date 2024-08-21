using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトがプレイヤーかどうかを確認
        if (collision.gameObject.CompareTag("Egg"))
        {
            // プレイヤーオブジェクトを破壊
            Destroy(collision.gameObject);
        }
    }
}
