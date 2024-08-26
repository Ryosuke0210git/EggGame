using System.Collections;  // コルーチンを使用するための名前空間
using UnityEngine;
using UnityEngine.UIElements;         // Unityの基本的な機能を使用するための名前空間

public class camera_zoom : MonoBehaviour  // CameraZoomクラスはMonoBehaviourを継承
{
    // AudioSourceコンポーネントを取得
    AudioSource[] sounds;



    public float zoomSpeed = 1.0f;  // ズームの速度を格納する変数

    public Vector3 firstPosition;   // カメラの初期位置を格納する変数

    public Vector3 finalPosition;   // ズーム後のカメラの位置を格納する変数

    private Camera cam;             // カメラの情報を格納する変数


    private void Start()  // ゲーム開始時に一度だけ実行される処理
    {
        Application.targetFrameRate = 500;  // 30FPSに設定

        sounds = this.GetComponents<AudioSource>();

        cam = Camera.main;                       // カメラの情報を取得
        cam.transform.position = firstPosition;  // カメラの初期位置を取得
        HammerCollision.GameEnd = true;          // プレイヤーが動けないようにする
        Invoke("SoundKong", 3.0f);               // 3秒後にコングを鳴らす
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(cam.transform.position, finalPosition) > 2.0f)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, finalPosition, zoomSpeed * Time.deltaTime);  // カメラを目標位置に向かって移動
        }
    }

    // コングを鳴らすメソッド
    void SoundKong()
    {
        sounds[2].Play();                 // コングを鳴らす
        HammerCollision.GameEnd = false;  // プレイヤーが動けるようにする
        Invoke("SoundBGM", 0.5f);         // 0.5秒後にBGMを鳴らす
    }

    void SoundBGM()
    {
        sounds[0].Play();                 // BGMを鳴らす
    }
}

