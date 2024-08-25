using System.Collections;  // コルーチンを使用するための名前空間
using UnityEngine;  // Unityの基本的な機能を使用するための名前空間

public class camera_zoom : MonoBehaviour  // CameraZoomクラスはMonoBehaviourを継承
{
    Transform camera;  // カメラのTransformを格納する変数
    Camera cam;  // カメラのCameraを格納する変数

    void Start()  // ゲーム開始時に一度だけ実行されるメソッド
    {
        camera = GetComponent<Transform>();  // カメラのTransformを取得
        cam = this.gameObject.GetComponent<Camera>();  // カメラのCameraを取得
    }

    void Update()  // ゲーム実行中に毎フレーム実行されるメソッド
    {
        if (Input.GetKey(KeyCode.W))  // Wキーが押されたら
        {
            cam.orthographicSize = cam.orthographicSize - 0.1f;  // カメラのorthographicSizeを0.1減らす(ズームイン)
        }
    }
}
