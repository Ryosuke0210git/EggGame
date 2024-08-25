using System.Collections;  // コルーチンを使用するための名前空間
using UnityEngine;  // Unityの基本的な機能を使用するための名前空間

public class camera_zoom : MonoBehaviour  // CameraZoomクラスはMonoBehaviourを継承
{
    public float zoomSpeed = 1.0f;  // ズームの速度を格納する変数

    public Vector3 firstPosition;  // カメラの初期位置を格納する変数

    public Vector3 finalPosition;  // ズーム後のカメラの位置を格納する変数

    private Camera cam;  // カメラの情報を格納する変数


    private void Start()  // ゲーム開始時に一度だけ実行される処理
    {
            cam = Camera.main;  // カメラの情報を取得
            cam.transform.position = firstPosition;  // カメラの初期位置を取得
            StartCoroutine(MoveCamera());  // MoveCameraメソッドを実行
    }

    private IEnumerator MoveCamera()  // ズームするメソッド
    {
        while(Vector3.Distance(cam.transform.position, finalPosition) > 0.1f)  // カメラの位置が目標位置に近づいている間
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, finalPosition, zoomSpeed * Time.deltaTime);  // カメラを目標位置に向かって移動
            yield return null;  // 1フレーム待つ
        }
    }
}

