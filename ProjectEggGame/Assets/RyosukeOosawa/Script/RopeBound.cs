using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----------------------------------------------------------------------//
// ���[�v�ɂԂ������Ƃ��ɒe����鏈��
//----------------------------------------------------------------------//
public class RopeBound : MonoBehaviour
{
    [Header("�o�E���h������͂̑傫��")]
    public float bounceForce = 10f;
    [Header("X�����̍ŏ��l")]
    public float xMin = -20f;
    [Header("X�����̍ő�l")]
    public float xMax = 20f;
    [Header("Z�����̍ŏ��l")]
    public float zMin = -20f;
    [Header("Z�����̍ő�l")]
    public float zMax = 20f;
    [Header("Y�����̍ŏ��l")]
    public float yMin = 0f;
    [Header("Y�����̍ő�l")]
    public float yMax = 10f;

    void Update()
    {
        Vector3 pos = transform.position;

        // X, Z, Y�����̋��E���`�F�b�N���A�������ꍇ�͈ʒu���C��
        if (pos.x < xMin) pos.x = xMin;
        if (pos.x > xMax) pos.x = xMax;
        if (pos.z < zMin) pos.z = zMin;
        if (pos.z > zMax) pos.z = zMax;
        if (pos.y < yMin) pos.y = yMin;
        if (pos.y > yMax) pos.y = yMax;

        transform.position = pos;
    }

    void OnCollisionEnter(Collision collision)
    {
        // ���[�v�ɓ���������
        if (collision.gameObject.CompareTag("Rope"))
        {
            // �Փ˂����ʒu�ł̖@�����擾
            Vector3 bounceDirection = collision.contacts[0].normal;

            // �v���C���[��Rigidbody�ɃA�N�Z�X
            Rigidbody rb = GetComponent<Rigidbody>();

            // �@�������Ƀo�E���h�͂�������
            rb.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
        }
    }
}
