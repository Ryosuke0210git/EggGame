using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----------------------------------------------------------------------//
// ���P�̑���𐧌䂷��X�N���v�g
//----------------------------------------------------------------------//
public class EggControllerWASD : MonoBehaviour
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

    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3();

        // �Q�[�����I�����Ă��Ȃ��ꍇ
        if (HammerCollision.GameEnd == false)
        {
            // WASD�L�[�̓��͂��擾
            if (Input.GetKey(KeyCode.W))
            {
                movement.z += 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                movement.z -= 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                movement.x -= 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                movement.x += 1;
            }
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
