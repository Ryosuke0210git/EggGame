using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//--------------------------------
//  �쐬�ҁF�ӂ����@�쐬���F2024/07/29
//--------------------------------
//  �n���}�[��U��q�^��������X�N���v�g
//  �n���}�[��Rigidbody��HingeJoint���g���A�U��q�^�����s��
//  �n���}�[��wall���C���[�ɓ���������Hingejoint�̉����x�𔽑΂ɂ���
//--------------------------------
public class HammerPendulum : MonoBehaviour
{
    [Header("�U��q�̑��x"), SerializeField]
    private float speed = 5.0f;
    private HingeJoint hj;
    private void Start()
    {
        hj = GetComponent<HingeJoint>();

        // HingeJoint�̃��[�^�[��ݒ�
        JointMotor motor = hj.motor;
        motor.targetVelocity = speed;
        motor.force = 1000;
        hj.motor = motor;
    }

    private void Update()
    {
        // speace�L�[����������n���}�[�̑��x��5�{�ɂȂ�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JointMotor motor = hj.motor;
            motor.targetVelocity *= 5;
            hj.motor = motor;
        }

        // speace�L�[�𗣂��ƃn���}�[�̑��x�����ɖ߂�
        if (Input.GetKeyUp(KeyCode.Space))
        {
            JointMotor motor = hj.motor;
            motor.targetVelocity /= 5;
            hj.motor = motor;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // wall���C���[�ɓ���������
        if (collision.gameObject.layer == LayerMask.NameToLayer("wall"))
        {
            // HingeJoint�̃��[�^�[�̑��x�𔽓]
            JointMotor motor = hj.motor;
            motor.targetVelocity = -motor.targetVelocity;
            motor.force = 1000;
            hj.motor = motor;
        }
    }
}
