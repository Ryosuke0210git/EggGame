using System.Collections;  // �R���[�`�����g�p���邽�߂̖��O���
using UnityEngine;
using UnityEngine.UIElements;         // Unity�̊�{�I�ȋ@�\���g�p���邽�߂̖��O���

public class camera_zoom : MonoBehaviour  // CameraZoom�N���X��MonoBehaviour���p��
{
    // AudioSource�R���|�[�l���g���擾
    AudioSource[] sounds;



    public float zoomSpeed = 1.0f;  // �Y�[���̑��x���i�[����ϐ�

    public Vector3 firstPosition;   // �J�����̏����ʒu���i�[����ϐ�

    public Vector3 finalPosition;   // �Y�[����̃J�����̈ʒu���i�[����ϐ�

    private Camera cam;             // �J�����̏����i�[����ϐ�


    private void Start()  // �Q�[���J�n���Ɉ�x�������s����鏈��
    {
        Application.targetFrameRate = 500;  // 30FPS�ɐݒ�

        sounds = this.GetComponents<AudioSource>();

        cam = Camera.main;                       // �J�����̏����擾
        cam.transform.position = firstPosition;  // �J�����̏����ʒu���擾
        HammerCollision.GameEnd = true;          // �v���C���[�������Ȃ��悤�ɂ���
        Invoke("SoundKong", 3.0f);               // 3�b��ɃR���O��炷
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(cam.transform.position, finalPosition) > 2.0f)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, finalPosition, zoomSpeed * Time.deltaTime);  // �J������ڕW�ʒu�Ɍ������Ĉړ�
        }
    }

    // �R���O��炷���\�b�h
    void SoundKong()
    {
        sounds[2].Play();                 // �R���O��炷
        HammerCollision.GameEnd = false;  // �v���C���[��������悤�ɂ���
        Invoke("SoundBGM", 0.5f);         // 0.5�b���BGM��炷
    }

    void SoundBGM()
    {
        sounds[0].Play();                 // BGM��炷
    }
}

