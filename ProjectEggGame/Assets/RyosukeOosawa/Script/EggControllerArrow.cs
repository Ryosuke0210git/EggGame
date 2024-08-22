using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----------------------------------------------------------------------//
// 卵２の操作を制御するスクリプト
//----------------------------------------------------------------------//
public class EggControllerArrow : MonoBehaviour
{
    [Header("転がる速度")]
    public float rollSpeed = 5f;
    [Header("最大速度")]
    public float maxSpeed = 10f;
    [Header("回転速度")]
    public float rotationSpeed = 100f;

    private Rigidbody rb;  


    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Rigidbodyを取得
    }

    void Update()
    {
        Vector3 movement = new Vector3();

        // 矢印キーの入力を取得
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement.z += 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movement.z -= 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x -= 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement.x += 1;
        }

        // 最大速度を制限
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(movement.normalized * rollSpeed);
        }

        // 卵を動きに合わせて回転させる
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime));
        }
    }
}
