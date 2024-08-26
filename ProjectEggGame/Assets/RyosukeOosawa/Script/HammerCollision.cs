using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HammerCollision : MonoBehaviour
{
    [Header("再生するパーティクル1")]
    public GameObject particleObject1;
    [Header("卵の破片")]
    public GameObject EggCrash;

    public Image fadePanel;              // フェード用のUIパネル（Image）
    private float fadeDuration = 2.0f;   // フェードの完了にかかる時間
    public static bool GameEnd = false;  // ゲーム終了を判定するフラグ           
    public static int WinPlayer = 0;     // どちらのプレイヤーが勝ったかを判定するフラグ

    // オフセットのベクトルを定義します（ローカル座標系でのオフセット）
    Vector3 localOffset = new Vector3(-18.0f, 8.0f, 0.0f);

    // AudioSourceコンポーネントを取得
    AudioSource[] sounds;

    void Start()
    {
        sounds = this.GetComponents<AudioSource>();
        EggCrash.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトがプレイヤーかどうかを確認
        if (collision.gameObject.CompareTag("Egg"))
        {
            // 卵の破片を表示
            EggCrash.SetActive(true);

            // ローカル座標系のオフセットをワールド座標系に変換します
            Vector3 worldOffset = this.transform.TransformDirection(localOffset);

            // 現在の座標にワールド座標系のオフセットを加えた新しい座標を計算します
            Vector3 newPosition = this.transform.position + worldOffset;

            // 回転を指定します（例えば、y軸を中心に90度回転）
            Quaternion rotation = Quaternion.Euler(0, 0, 0);

            // 新しい座標と回転でパーティクルオブジェクトを生成します
            Instantiate(particleObject1, newPosition, rotation);

            // 衝突したオブジェクトの名前がPlayer1_Eggの場合
            if (collision.gameObject.name == "Player1_Egg")
            {
                WinPlayer = 2;
            }
            else
            {
                WinPlayer = 1;
            }

            // プレイヤーオブジェクトを破壊
            Destroy(collision.gameObject);

            // 決着
            GameEnd = true;

            // 卵の破壊音
            sounds[2].Play();

            // 3秒後にシーンを遷移
            Invoke("ChangeScene", 1.0f);
        }
    }

    // シーンを遷移させる
    void ChangeScene()
    {
        // ゴングの音
        sounds[3].Play();
        StartCoroutine(FadeOutAndLoadScene());
    }

    public IEnumerator FadeOutAndLoadScene()
    {
        fadePanel.enabled = true;                 // パネルを有効化
        float elapsedTime = 0.0f;                 // 経過時間を初期化
        Color startColor = fadePanel.color;       // フェードパネルの開始色を取得
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f); // フェードパネルの最終色を設定

        // フェードアウトアニメーションを実行
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;                         // 経過時間を増やす
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);   // フェードの進行度を計算
            fadePanel.color = Color.Lerp(startColor, endColor, t); // パネルの色を変更してフェードアウト
            yield return null;                                     // 1フレーム待機
        }
        fadePanel.color = endColor;               // フェードが完了したら最終色に設定
        GameEnd = false;                          // ゲーム終了フラグをリセット
        SceneManager.LoadScene("Result");         //シーンを読み込む
    }
}
