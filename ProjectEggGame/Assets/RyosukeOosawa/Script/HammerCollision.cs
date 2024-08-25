using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerCollision : MonoBehaviour
{
    public bool GameEnd = false; //�Q�[���I���𔻒肷��t���O
             
    public float WinPlayer=1;//�ǂ���̃v���C���[�����������𔻒肷��t���O

    void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g���v���C���[���ǂ������m�F
        if (collision.gameObject.CompareTag("Egg"))
        {
            //�Փ˂����I�u�W�F�N�g�̖��O��Player1_Egg�̏ꍇ
            if (collision.gameObject.name == "Player1_Egg")
            {
                WinPlayer = 1;
            }
            else
            {
                WinPlayer = 2;
            }

            // �v���C���[�I�u�W�F�N�g��j��
            Destroy(collision.gameObject);

            // �Q�[���I���t���O�𗧂Ă�
            GameEnd = true;
        }
    }
}
