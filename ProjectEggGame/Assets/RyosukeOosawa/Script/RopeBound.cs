using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----------------------------------------------------------------------//
// ロープにぶつかったときに弾かれる処理
//----------------------------------------------------------------------//
public class RopeBound : MonoBehaviour
{
    [Header("バウンドさせる力の大きさ")]
    public float bounceForce = 10f;
    [Header("X方向の最小値")]
    public float xMin = -20f;
    [Header("X方向の最大値")]
    public float xMax = 20f;
    [Header("Z方向の最小値")]
    public float zMin = -20f;
    [Header("Z方向の最大値")]
    public float zMax = 20f;
    [Header("Y方向の最小値")]
    public float yMin = 0f;
    [Header("Y方向の最大値")]
    public float yMax = 10f;

    void Update()
    {
        Vector3 pos = transform.position;

        // X, Z, Y方向の境界をチェックし、超えた場合は位置を修正
        if (pos.x < xMin) pos.x = xMin;
        if (pos.x > xMax) pos.x = xMax;
        if (pos.z < zMin) pos.z = zMin;
        if (pos.z > zMax) pos.z = zMax;
        if (pos.y < yMin) pos.y = yMin;
        if (pos.y > yMax) pos.y = yMax;

        transform.position = pos;
    }

    void OnCollisionEnter(Collision collision)
    {
        // ロープに当たったら
        if (collision.gameObject.CompareTag("Rope"))
        {
            // 衝突した位置での法線を取得
            Vector3 bounceDirection = collision.contacts[0].normal;

            // プレイヤーのRigidbodyにアクセス
            Rigidbody rb = GetComponent<Rigidbody>();

            // 法線方向にバウンド力を加える
            rb.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
        }
    }
}
