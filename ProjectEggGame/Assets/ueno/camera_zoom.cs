using System.Collections;  // �R���[�`�����g�p���邽�߂̖��O���
using UnityEngine;  // Unity�̊�{�I�ȋ@�\���g�p���邽�߂̖��O���

public class camera_zoom : MonoBehaviour  // CameraZoom�N���X��MonoBehaviour���p��
{
    Transform camera;  // �J������Transform���i�[����ϐ�
    Camera cam;  // �J������Camera���i�[����ϐ�

    void Start()  // �Q�[���J�n���Ɉ�x�������s����郁�\�b�h
    {
        camera = GetComponent<Transform>();  // �J������Transform���擾
        cam = this.gameObject.GetComponent<Camera>();  // �J������Camera���擾
    }

    void Update()  // �Q�[�����s���ɖ��t���[�����s����郁�\�b�h
    {
        if (Input.GetKey(KeyCode.W))  // W�L�[�������ꂽ��
        {
            cam.orthographicSize = cam.orthographicSize - 0.1f;  // �J������orthographicSize��0.1���炷(�Y�[���C��)
        }
    }
}
