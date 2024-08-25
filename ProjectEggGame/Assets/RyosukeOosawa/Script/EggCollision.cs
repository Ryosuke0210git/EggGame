using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----------------------------------------------------------------------//
// �����m���Ԃ������Ƃ��̏���
//----------------------------------------------------------------------//
public class EggCollision : MonoBehaviour
{
    public float bounciness = 1.0f; // �e�͐�
    public float friction = 0.5f;   // ���C
    private Rigidbody rb;

    // AudioSource�R���|�[�l���g���擾
    AudioSource[] sounds;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sounds = this.GetComponents<AudioSource>();

        // Rigidbody�̐ݒ�
        rb.drag = friction; // ��C��R
        rb.angularDrag = friction; // ��]��R
    }

    void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g�����̗��ł��邩�m�F
        if (collision.gameObject.CompareTag("Egg"))
        {
            // �Փˉ�
            sounds[0].Play();

            // �Փ˂̏����擾
            Rigidbody otherRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 relativeVelocity = rb.velocity - otherRb.velocity;

            // �e�͐��Ɋ�Â��Ĕ�������͂��v�Z
            float impulse = Vector3.Dot(relativeVelocity, collision.contacts[0].normal) * (1 + bounciness);

            // �Փ˂��������ɔ�������͂�������
            rb.AddForce(collision.contacts[0].normal * impulse, ForceMode.Impulse);
            otherRb.AddForce(-collision.contacts[0].normal * impulse, ForceMode.Impulse);

            // �����͂Ɋ�Â��ĉ�]�̕␳
            Vector3 angularImpulse = Vector3.Cross(collision.contacts[0].normal, relativeVelocity);
            rb.AddTorque(angularImpulse * bounciness, ForceMode.Impulse);
            otherRb.AddTorque(-angularImpulse * bounciness, ForceMode.Impulse);
        }
    }
}
