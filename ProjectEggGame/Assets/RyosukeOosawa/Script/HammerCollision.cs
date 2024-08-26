using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HammerCollision : MonoBehaviour
{
    [Header("�Đ�����p�[�e�B�N��1")]
    public GameObject particleObject1;
    [Header("���̔j��")]
    public GameObject EggCrash;

    public Image fadePanel;              // �t�F�[�h�p��UI�p�l���iImage�j
    private float fadeDuration = 2.0f;   // �t�F�[�h�̊����ɂ����鎞��
    public static bool GameEnd = false;  // �Q�[���I���𔻒肷��t���O           
    public static int WinPlayer = 0;     // �ǂ���̃v���C���[�����������𔻒肷��t���O

    // �I�t�Z�b�g�̃x�N�g�����`���܂��i���[�J�����W�n�ł̃I�t�Z�b�g�j
    Vector3 localOffset = new Vector3(-18.0f, 8.0f, 0.0f);

    // AudioSource�R���|�[�l���g���擾
    AudioSource[] sounds;

    void Start()
    {
        sounds = this.GetComponents<AudioSource>();
        EggCrash.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g���v���C���[���ǂ������m�F
        if (collision.gameObject.CompareTag("Egg"))
        {
            // ���̔j�Ђ�\��
            EggCrash.SetActive(true);

            // ���[�J�����W�n�̃I�t�Z�b�g�����[���h���W�n�ɕϊ����܂�
            Vector3 worldOffset = this.transform.TransformDirection(localOffset);

            // ���݂̍��W�Ƀ��[���h���W�n�̃I�t�Z�b�g���������V�������W���v�Z���܂�
            Vector3 newPosition = this.transform.position + worldOffset;

            // ��]���w�肵�܂��i�Ⴆ�΁Ay���𒆐S��90�x��]�j
            Quaternion rotation = Quaternion.Euler(0, 0, 0);

            // �V�������W�Ɖ�]�Ńp�[�e�B�N���I�u�W�F�N�g�𐶐����܂�
            Instantiate(particleObject1, newPosition, rotation);

            // �Փ˂����I�u�W�F�N�g�̖��O��Player1_Egg�̏ꍇ
            if (collision.gameObject.name == "Player1_Egg")
            {
                WinPlayer = 2;
            }
            else
            {
                WinPlayer = 1;
            }

            // �v���C���[�I�u�W�F�N�g��j��
            Destroy(collision.gameObject);

            // ����
            GameEnd = true;

            // ���̔j��
            sounds[2].Play();

            // 3�b��ɃV�[����J��
            Invoke("ChangeScene", 1.0f);
        }
    }

    // �V�[����J�ڂ�����
    void ChangeScene()
    {
        // �S���O�̉�
        sounds[3].Play();
        StartCoroutine(FadeOutAndLoadScene());
    }

    public IEnumerator FadeOutAndLoadScene()
    {
        fadePanel.enabled = true;                 // �p�l����L����
        float elapsedTime = 0.0f;                 // �o�ߎ��Ԃ�������
        Color startColor = fadePanel.color;       // �t�F�[�h�p�l���̊J�n�F���擾
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f); // �t�F�[�h�p�l���̍ŏI�F��ݒ�

        // �t�F�[�h�A�E�g�A�j���[�V���������s
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;                         // �o�ߎ��Ԃ𑝂₷
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);   // �t�F�[�h�̐i�s�x���v�Z
            fadePanel.color = Color.Lerp(startColor, endColor, t); // �p�l���̐F��ύX���ăt�F�[�h�A�E�g
            yield return null;                                     // 1�t���[���ҋ@
        }
        fadePanel.color = endColor;               // �t�F�[�h������������ŏI�F�ɐݒ�
        GameEnd = false;                          // �Q�[���I���t���O�����Z�b�g
        SceneManager.LoadScene("Result");         //�V�[����ǂݍ���
    }
}
