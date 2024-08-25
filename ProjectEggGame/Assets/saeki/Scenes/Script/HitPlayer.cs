using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{

    //このスクリプトはPlayerレイヤーのオブジェクトと衝突した時に、このオブジェクトは当たった方向とは逆に飛ばされるようにするスクリプト

    // 飛ばされる強さの調整
    [SerializeField] private float bounceForce = 10.0f;

    private void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトが "Player" レイヤーに属しているか確認
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Rigidbodyコンポーネントを取得（オブジェクトが飛ばされるため）
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            Debug.Log("HitPlayer");

            if (rb != null)
            {
                // 衝突した位置とプレイヤーの位置を使って反射方向を計算
                Vector3 direction = collision.transform.position - transform.position;

                // 反射方向に力を加える
                rb.AddForce(direction.normalized * bounceForce, ForceMode.Impulse);
            }
        }
    }
}
