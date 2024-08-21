using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//----------------------------------------------------------------------//
// 青のハンマーを振り下ろす処理
//----------------------------------------------------------------------//
public class BlueHammerSwing : MonoBehaviour
{
    [Header("振り下ろす速度")]
    public float swingSpeed = 1.0f;
    [Header("戻る速度")]
    public float returnSpeed = 1.0f;

    private bool PushFg = false;    // ボタンが押されたかどうか
    private bool ReturnFg = false;  // 戻るかどうか

    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Space)) // スペースキーを押す
        {
            // ボタンが押されていなければ
            if(!PushFg)
            {
                PushFg = true;
            }
        }

        // ハンマーを振り下ろす
        if (PushFg)
        {
            SwingHammer();
        }
    }

    void SwingHammer()
    {
        // transformを取得
        Transform myTransform = this.transform;

        // ワールド座標を基準に、回転を取得
        Vector3 localAngle = myTransform.localEulerAngles;

        if(ReturnFg == false)
        {
            localAngle.z += swingSpeed;  // 回転させる

            // 地面まで振り下ろしたら戻る
            if (localAngle.z >= 90)
            {
                ReturnFg = true;
                localAngle.z = 90;
            }
        }
        else
        {
            localAngle.z -= returnSpeed;  // 回転させる

            // 戻り切ったら止める
            if (localAngle.z <= 0)
            {
                ReturnFg = false;
                PushFg = false;
                localAngle.z = 0;
            }
        }

        myTransform.eulerAngles = localAngle; // 回転角度を設定     
    }
}
