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
    [Header("再生するパーティクル1")]
    public GameObject particleObject1;

    // AudioSourceコンポーネントを取得
    AudioSource[] sounds;
    // オフセットのベクトルを定義します（ローカル座標系でのオフセット）
    Vector3 localOffset = new Vector3(-7.0f, 17.0f, 0.0f);

    private bool PushFg = false;    // ボタンが押されたかどうか
    private bool ReturnFg = false;  // 戻るかどうか

    void Start()
    {
        sounds = this.GetComponents<AudioSource>();
    }

    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Space)) // スペースキーを押す
        {
            // ボタンが押されていなければ
            if(!PushFg)
            {
                PushFg = true;
                sounds[0].Play();
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
                sounds[1].Play();

                // ローカル座標系のオフセットをワールド座標系に変換します
                Vector3 worldOffset = this.transform.TransformDirection(localOffset);

                // 現在の座標にワールド座標系のオフセットを加えた新しい座標を計算します
                Vector3 newPosition = this.transform.position + worldOffset;

                // 回転を指定します（例えば、y軸を中心に90度回転）
                Quaternion rotation = Quaternion.Euler(90, 0, 0);

                // 新しい座標と回転でパーティクルオブジェクトを生成します
                Instantiate(particleObject1, newPosition, rotation);
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
