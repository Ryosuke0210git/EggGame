using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    [SerializeField] GameObject MenuObject; //���j���[��ʂ�UI�����蓖�Ă�p�̕ϐ�

    public bool MenuFlag;   //���j���[��ʂ̕\���E��\���̃t���O

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        MenuFlag = false;
    }

    private void Update()
    {
        //���j���[��ʂ���\���Ȃ��
        if(MenuFlag == false)
        { 
            if(Input.GetKeyDown(KeyCode.Escape))        //ESC�L�[���������Ƃ�
            {
                MenuObject.gameObject.SetActive(true);  //���j���[��ʕ\��
                MenuFlag = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))       //ESC�L�[���������Ƃ�
            {
                MenuObject.gameObject.SetActive(false); //���j���[��ʔ�\��
                MenuFlag = false;
            }
        }
    }

    //"StartMenuButton"�Ɋ��蓖�ĂĂ���֐�
    public void Start_Menu()
    {
        MenuFlag = true;
        MenuObject.gameObject.SetActive(true);          //���j���[��ʕ\��
    }

    //"EndMenuButton"�Ɋ��蓖�ĂĂ���֐�
    public void End_Menu()
    {
        MenuFlag = false;
        MenuObject.gameObject.SetActive(false);         //���j���[��ʔ�\��
    }
}
