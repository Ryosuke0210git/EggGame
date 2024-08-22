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

    // AudioSource�R���|�[�l���g���擾
    AudioSource[] sounds;

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
