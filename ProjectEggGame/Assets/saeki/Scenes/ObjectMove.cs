using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//--------------------------------
//  �쐬�ҁF�ӂ����@�쐬���F2024/07/29
//--------------------------------
//  �I�u�W�F�N�g���ړ�������X�N���v�g
// �ړ���Rigidbody���g���A���̓L�[�ŕ�����ǂݎ��
// �܂��A�ړ����x��ύX���邱�Ƃ��ł���
//--------------------------------
public class ObjectMove : MonoBehaviour
{
    [Header("�ړ����x"), SerializeField]
    private float speed = 5.0f;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // ���̓L�[���擾
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // �ړ��������v�Z
        Vector3 move = new Vector3(x, 0, z);
        // �ړ������ɑ��x�������Ĉړ�
        rb.velocity = move * speed + Vector3.up * rb.velocity.y;
    }
}
