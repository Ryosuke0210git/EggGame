using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private static string previousSceneName;    //シーン名を保存する

    //タイトルシーンをロードする
    public void TitleLoadScene(string str)
    {
        SceneManager.LoadScene(str);    //シーンを読み込む
    }

    //チュートリアルシーンをロードする
    public void TutorialLoadScene(string str)
    {
        SceneManager.LoadScene(str);    //シーンを読み込む
    }

    //ステージ選択シーンをロードする
    public void StageChoiceLoadScene(string str)
    {
        SceneManager.LoadScene(str);    //シーンを読み込む
    }

    //ステージシーンをロードする
    public void StageLoadScene(string str)
    {
        SceneManager.LoadScene(str);    //シーンを読み込む
    }
    
    //遷移前のシーンをロードする
    public void PreviousLoadScene()
    {
        if (!string.IsNullOrEmpty(previousSceneName))
        {
            SceneManager.LoadScene(previousSceneName);
        }
        else
        {
            Debug.LogWarning("シーン名がセットされてない。");
        }
    }

    //リザルトシーンをロードする
    public void ResultLoadScene(string str)
    {
        previousSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(str);    //シーンを読み込む
    }

    //ゲームを終了する
    public void GameEnd()　{
        #if UNITY_EDITOR    //UnityEditorでの実行なら
            //再生モードを解除する
            UnityEditor.EditorApplication.isPlaying = false;
        #else   //UnityEditorでの実行でなければ(→ビルド後)なら
                //アプリケーションを終了する
                Application.Quit();
        #endif
    }

}
