using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Refree : MonoBehaviour
{
    [Header("勝敗を取るためのスクリプト"), SerializeField]
    private GameObject Winer;

    [Header("勝利の文字"), SerializeField]
    private GameObject Victory1;

    [Header("勝利の文字"), SerializeField]
    private GameObject Victory2;

    void FixedUpdate()
    {
        if(Winer.GetComponent<HammerCollision>().GameEnd)
        {
            //スローモーションを開始
            Time.timeScale = 0.2f;

            //コルーチンを開始
            StartCoroutine(GameSet());

            //ゲーム終了フラグをリセット
            Winer.GetComponent<HammerCollision>().GameEnd = false;

        }
    }

    IEnumerator GameSet()
    {
        // 2秒待つ
        yield return new WaitForSeconds(2.0f);

        //スローモーションを解除
        Time.timeScale = 1.0f;

        if (Winer.GetComponent<HammerCollision>().WinPlayer == 1)
        {
            Debug.Log("Player1の勝ち");

            //画像を表示
            Victory1.SetActive(true);
        }
        else
        {
            Debug.Log("Player2の勝ち");

            //画像を表示
            Victory2.SetActive(true);
        }
    }
}
