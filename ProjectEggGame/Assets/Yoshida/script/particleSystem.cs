using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSystem : MonoBehaviour
{
    [Header("�Đ�����p�[�e�B�N��")]
    public GameObject particleObject;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Egg") //Egg�^�O�t���Q�[���I�u�W�F�N�g�i���j�ƏՓ˂�����
        {
            Instantiate(particleObject, this.transform.position, Quaternion.identity); //�p�[�e�B�N���p�I�u�W�F�N�g����
        }
    }
}
