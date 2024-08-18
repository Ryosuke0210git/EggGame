using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveStage : MonoBehaviour
{
    [SerializeField] private float tiltSpeed = 40.0f; // ステージの傾き速度
    [SerializeField] private float maxTiltAngle = 50.0f; // ステージの最大傾き角度

    private float tiltX = 0.0f;
    private float tiltZ = 0.0f;

    void Update()
    {
        // 前後の傾き (Wキーで前に、Sキーで後ろに傾ける)
        float tiltForwardBackward = -Input.GetAxis("Vertical") * tiltSpeed * Time.deltaTime;

        // 左右の傾き (Aキーで左に、Dキーで右に傾ける)
        float tiltLeftRight = -Input.GetAxis("Horizontal") * tiltSpeed * Time.deltaTime;

        // 新しい傾き角度を計算
        tiltX = Mathf.Clamp(tiltX - tiltForwardBackward, -maxTiltAngle, maxTiltAngle);
        tiltZ = Mathf.Clamp(tiltZ + tiltLeftRight, -maxTiltAngle, maxTiltAngle);

        // ステージオブジェクトを傾ける
        transform.rotation = Quaternion.Euler(tiltX, 0.0f, tiltZ);
    }
}
