using System.Collections;  // �R���[�`�����g�p���邽�߂̖��O���
using UnityEngine;  // Unity�̊�{�I�ȋ@�\���g�p���邽�߂̖��O���

public class camera_zoom : MonoBehaviour  // CameraZoom�N���X��MonoBehaviour���p��
{
    public float zoomSpeed = 1.0f;  // �Y�[���̑��x���i�[����ϐ�

    public Vector3 firstPosition;  // �J�����̏����ʒu���i�[����ϐ�

    public Vector3 finalPosition;  // �Y�[����̃J�����̈ʒu���i�[����ϐ�

    private Camera cam;  // �J�����̏����i�[����ϐ�


    private void Start()  // �Q�[���J�n���Ɉ�x�������s����鏈��
    {
            cam = Camera.main;  // �J�����̏����擾
            cam.transform.position = firstPosition;  // �J�����̏����ʒu���擾
            StartCoroutine(MoveCamera());  // MoveCamera���\�b�h�����s
    }

    private IEnumerator MoveCamera()  // �Y�[�����郁�\�b�h
    {
        while(Vector3.Distance(cam.transform.position, finalPosition) > 0.1f)  // �J�����̈ʒu���ڕW�ʒu�ɋ߂Â��Ă����
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, finalPosition, zoomSpeed * Time.deltaTime);  // �J������ڕW�ʒu�Ɍ������Ĉړ�
            yield return null;  // 1�t���[���҂�
        }
    }
}

