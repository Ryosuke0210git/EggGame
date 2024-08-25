using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private static string previousSceneName;    //�V�[������ۑ�����

    //�^�C�g���V�[�������[�h����
    public void TitleLoadScene(string str)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(str);    //�V�[����ǂݍ���
    }

    //�`���[�g���A���V�[�������[�h����
    public void TutorialLoadScene(string str)
    {
        SceneManager.LoadScene(str);    //�V�[����ǂݍ���
    }

    //�X�e�[�W�I���V�[�������[�h����
    public void StageChoiceLoadScene(string str)
    {
        SceneManager.LoadScene(str);    //�V�[����ǂݍ���
    }

    //�X�e�[�W�V�[�������[�h����
    public void StageLoadScene(string str)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(str);    //�V�[����ǂݍ���
    }
    
    //�J�ڑO�̃V�[�������[�h����
    public void PreviousLoadScene()
    {
        if (!string.IsNullOrEmpty(previousSceneName))
        {
            SceneManager.LoadScene(previousSceneName);
        }
        else
        {
            Debug.LogWarning("�V�[�������Z�b�g����ĂȂ��B");
        }
    }

    //���݂̃V�[�������[�h����(���X�^�[�g����)
    public void CurrentLoadScene()
    {
        //���݂̃V�[�������擾
        string currentSceneName = SceneManager.GetActiveScene().name;

        Time.timeScale = 1;

        //���݂̃V�[�����ă��[�h
        SceneManager.LoadScene(currentSceneName);
    }

    //���U���g�V�[�������[�h����
    public void ResultLoadScene(string str)
    {
        previousSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(str);    //�V�[����ǂݍ���
    }

    //�Q�[�����I������
    public void GameEnd()�@{
        #if UNITY_EDITOR    //UnityEditor�ł̎��s�Ȃ�
            //�Đ����[�h����������
            UnityEditor.EditorApplication.isPlaying = false;
        #else   //UnityEditor�ł̎��s�łȂ����(���r���h��)�Ȃ�
                //�A�v���P�[�V�������I������
                Application.Quit();
        #endif
    }

}
