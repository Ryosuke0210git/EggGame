using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g���v���C���[���ǂ������m�F
        if (collision.gameObject.CompareTag("Egg"))
        {
            // �v���C���[�I�u�W�F�N�g��j��
            Destroy(collision.gameObject);
        }
    }
}
