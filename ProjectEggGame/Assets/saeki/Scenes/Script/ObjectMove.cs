using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//--------------------------------
//  作成者：ふじわら　作成日：2024/07/29
//--------------------------------
//  オブジェクトを移動させるスクリプト
// 移動はRigidbodyを使い、入力キーで方向を読み取る
// また、移動速度を変更することができる
//--------------------------------
public class ObjectMove : MonoBehaviour
{
    [Header("移動速度"), SerializeField]
    private float speed = 5.0f;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // 入力キーを取得
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // 移動方向を計算
        Vector3 move = new Vector3(x, 0, z);
        // 移動方向に速度をかけて移動
        rb.velocity = move * speed + Vector3.up * rb.velocity.y;
    }
}
