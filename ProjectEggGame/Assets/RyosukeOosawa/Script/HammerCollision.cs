using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerCollision : MonoBehaviour
{
    [Header("�Đ�����p�[�e�B�N��1")]
    public GameObject particleObject1;

    public bool GameEnd = false;  //�Q�[���I���𔻒肷��t���O           
    public float WinPlayer = 1;   //�ǂ���̃v���C���[�����������𔻒肷��t���O

    // �I�t�Z�b�g�̃x�N�g�����`���܂��i���[�J�����W�n�ł̃I�t�Z�b�g�j
    Vector3 localOffset = new Vector3(-18.0f, 8.0f, 0.0f);

    void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g���v���C���[���ǂ������m�F
        if (collision.gameObject.CompareTag("Egg"))
        {
            // ���[�J�����W�n�̃I�t�Z�b�g�����[���h���W�n�ɕϊ����܂�
            Vector3 worldOffset = this.transform.TransformDirection(localOffset);

            // ���݂̍��W�Ƀ��[���h���W�n�̃I�t�Z�b�g���������V�������W���v�Z���܂�
            Vector3 newPosition = this.transform.position + worldOffset;

            // ��]���w�肵�܂��i�Ⴆ�΁Ay���𒆐S��90�x��]�j
            Quaternion rotation = Quaternion.Euler(0, 0, 0);

            // �V�������W�Ɖ�]�Ńp�[�e�B�N���I�u�W�F�N�g�𐶐����܂�
            Instantiate(particleObject1, newPosition, rotation);

            //// �Փ˂����I�u�W�F�N�g�̖��O��Player1_Egg�̏ꍇ
            //if (collision.gameObject.name == "Player1_Egg")
            //{
            //    WinPlayer = 1;
            //}
            //else
            //{
            //    WinPlayer = 2;
            //}

            // �v���C���[�I�u�W�F�N�g��j��
            Destroy(collision.gameObject);

            // �Q�[���I���t���O�𗧂Ă�
            GameEnd = true;
        }
    }
}
