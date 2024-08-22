using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Refree : MonoBehaviour
{
    [Header("���s����邽�߂̃X�N���v�g"), SerializeField]
    private GameObject Winer;

    [Header("�����̕���"), SerializeField]
    private GameObject Victory1;

    [Header("�����̕���"), SerializeField]
    private GameObject Victory2;

    void FixedUpdate()
    {
        if(Winer.GetComponent<HammerCollision>().GameEnd)
        {
            //�X���[���[�V�������J�n
            Time.timeScale = 0.2f;

            //�R���[�`�����J�n
            StartCoroutine(GameSet());

            //�Q�[���I���t���O�����Z�b�g
            Winer.GetComponent<HammerCollision>().GameEnd = false;

        }
    }

    IEnumerator GameSet()
    {
        // 2�b�҂�
        yield return new WaitForSeconds(2.0f);

        //�X���[���[�V����������
        Time.timeScale = 1.0f;

        if (Winer.GetComponent<HammerCollision>().WinPlayer == 1)
        {
            Debug.Log("Player1�̏���");

            //�摜��\��
            Victory1.SetActive(true);
        }
        else
        {
            Debug.Log("Player2�̏���");

            //�摜��\��
            Victory2.SetActive(true);
        }
    }
}
