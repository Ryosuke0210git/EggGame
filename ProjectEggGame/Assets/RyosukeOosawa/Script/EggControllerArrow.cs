using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----------------------------------------------------------------------//
// ���Q�̑���𐧌䂷��X�N���v�g
//----------------------------------------------------------------------//
public class EggControllerArrow : MonoBehaviour
{
    [Header("�]���鑬�x")]
    public float rollSpeed = 5f;
    [Header("�ő呬�x")]
    public float maxSpeed = 10f;
    [Header("��]���x")]
    public float rotationSpeed = 100f;

    private Rigidbody rb;  


    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Rigidbody���擾
    }

    void Update()
    {
        Vector3 movement = new Vector3();

        // ���L�[�̓��͂��擾
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement.z += 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movement.z -= 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x -= 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement.x += 1;
        }

        // �ő呬�x�𐧌�
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(movement.normalized * rollSpeed);
        }

        // ���𓮂��ɍ��킹�ĉ�]������
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime));
        }
    }
}
