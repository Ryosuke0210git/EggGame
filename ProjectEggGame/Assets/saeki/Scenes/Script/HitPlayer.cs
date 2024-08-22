using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{

    //���̃X�N���v�g��Player���C���[�̃I�u�W�F�N�g�ƏՓ˂������ɁA���̃I�u�W�F�N�g�͓������������Ƃ͋t�ɔ�΂����悤�ɂ���X�N���v�g

    // ��΂���鋭���̒���
    [SerializeField] private float bounceForce = 10.0f;

    private void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g�� "Player" ���C���[�ɑ����Ă��邩�m�F
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Rigidbody�R���|�[�l���g���擾�i�I�u�W�F�N�g����΂���邽�߁j
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            Debug.Log("HitPlayer");

            if (rb != null)
            {
                // �Փ˂����ʒu�ƃv���C���[�̈ʒu���g���Ĕ��˕������v�Z
                Vector3 direction = collision.transform.position - transform.position;

                // ���˕����ɗ͂�������
                rb.AddForce(direction.normalized * bounceForce, ForceMode.Impulse);
            }
        }
    }
}
