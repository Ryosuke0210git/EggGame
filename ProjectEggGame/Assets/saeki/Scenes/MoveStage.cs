using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveStage : MonoBehaviour
{
    [SerializeField] private float tiltSpeed = 40.0f; // �X�e�[�W�̌X�����x
    [SerializeField] private float maxTiltAngle = 50.0f; // �X�e�[�W�̍ő�X���p�x

    private float tiltX = 0.0f;
    private float tiltZ = 0.0f;

    void Update()
    {
        // �O��̌X�� (W�L�[�őO�ɁAS�L�[�Ō��ɌX����)
        float tiltForwardBackward = -Input.GetAxis("Vertical") * tiltSpeed * Time.deltaTime;

        // ���E�̌X�� (A�L�[�ō��ɁAD�L�[�ŉE�ɌX����)
        float tiltLeftRight = -Input.GetAxis("Horizontal") * tiltSpeed * Time.deltaTime;

        // �V�����X���p�x���v�Z
        tiltX = Mathf.Clamp(tiltX - tiltForwardBackward, -maxTiltAngle, maxTiltAngle);
        tiltZ = Mathf.Clamp(tiltZ + tiltLeftRight, -maxTiltAngle, maxTiltAngle);

        // �X�e�[�W�I�u�W�F�N�g���X����
        transform.rotation = Quaternion.Euler(tiltX, 0.0f, tiltZ);
    }
}
