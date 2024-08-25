using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//----------------------------------------------------------------------//
// �̃n���}�[��U�艺�낷����
//----------------------------------------------------------------------//
public class BlueHammerSwing : MonoBehaviour
{
    [Header("�U�艺�낷���x")]
    public float swingSpeed = 1.0f;
    [Header("�߂鑬�x")]
    public float returnSpeed = 1.0f;
    [Header("�Đ�����p�[�e�B�N��1")]
    public GameObject particleObject1;

    // AudioSource�R���|�[�l���g���擾
    AudioSource[] sounds;
    // �I�t�Z�b�g�̃x�N�g�����`���܂��i���[�J�����W�n�ł̃I�t�Z�b�g�j
    Vector3 localOffset = new Vector3(-7.0f, 17.0f, 0.0f);

    private bool PushFg = false;    // �{�^���������ꂽ���ǂ���
    private bool ReturnFg = false;  // �߂邩�ǂ���

    void Start()
    {
        sounds = this.GetComponents<AudioSource>();
    }

    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Space)) // �X�y�[�X�L�[������
        {
            // �{�^����������Ă��Ȃ����
            if(!PushFg)
            {
                PushFg = true;
                sounds[0].Play();
            }
        }

        // �n���}�[��U�艺�낷
        if (PushFg)
        {
            SwingHammer();
        }
    }

    void SwingHammer()
    {
        // transform���擾
        Transform myTransform = this.transform;

        // ���[���h���W����ɁA��]���擾
        Vector3 localAngle = myTransform.localEulerAngles;

        if(ReturnFg == false)
        {
            localAngle.z += swingSpeed;  // ��]������

            // �n�ʂ܂ŐU�艺�낵����߂�
            if (localAngle.z >= 90)
            {
                ReturnFg = true;
                localAngle.z = 90;
                sounds[1].Play();

                // ���[�J�����W�n�̃I�t�Z�b�g�����[���h���W�n�ɕϊ����܂�
                Vector3 worldOffset = this.transform.TransformDirection(localOffset);

                // ���݂̍��W�Ƀ��[���h���W�n�̃I�t�Z�b�g���������V�������W���v�Z���܂�
                Vector3 newPosition = this.transform.position + worldOffset;

                // ��]���w�肵�܂��i�Ⴆ�΁Ay���𒆐S��90�x��]�j
                Quaternion rotation = Quaternion.Euler(90, 0, 0);

                // �V�������W�Ɖ�]�Ńp�[�e�B�N���I�u�W�F�N�g�𐶐����܂�
                Instantiate(particleObject1, newPosition, rotation);
            }
        }
        else
        {
            localAngle.z -= returnSpeed;  // ��]������

            // �߂�؂�����~�߂�
            if (localAngle.z <= 0)
            {
                ReturnFg = false;
                PushFg = false;
                localAngle.z = 0;
            }
        }

        myTransform.eulerAngles = localAngle; // ��]�p�x��ݒ�     
    }
}
