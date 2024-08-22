using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//--------------------------------
//  作成者：ふじわら　作成日：2024/07/29
//--------------------------------
//  ハンマーを振り子運動させるスクリプト
//  ハンマーはRigidbodyとHingeJointを使い、振り子運動を行う
//  ハンマーがwallレイヤーに当たったらHingejointの加速度を反対にする
//--------------------------------
public class HammerPendulum : MonoBehaviour
{
    [Header("振り子の速度"), SerializeField]
    private float speed = 5.0f;
    private HingeJoint hj;
    private void Start()
    {
        hj = GetComponent<HingeJoint>();

        // HingeJointのモーターを設定
        JointMotor motor = hj.motor;
        motor.targetVelocity = speed;
        motor.force = 1000;
        hj.motor = motor;
    }

    private void Update()
    {
        // speaceキーを押したらハンマーの速度が5倍になる
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JointMotor motor = hj.motor;
            motor.targetVelocity *= 5;
            hj.motor = motor;
        }

        // speaceキーを離すとハンマーの速度が元に戻る
        if (Input.GetKeyUp(KeyCode.Space))
        {
            JointMotor motor = hj.motor;
            motor.targetVelocity /= 5;
            hj.motor = motor;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // wallレイヤーに当たったら
        if (collision.gameObject.layer == LayerMask.NameToLayer("wall"))
        {
            // HingeJointのモーターの速度を反転
            JointMotor motor = hj.motor;
            motor.targetVelocity = -motor.targetVelocity;
            motor.force = 1000;
            hj.motor = motor;
        }
    }
}
