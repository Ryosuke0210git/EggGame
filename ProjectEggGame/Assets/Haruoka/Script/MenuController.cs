using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    [SerializeField] GameObject MenuObject; //メニュー画面のUIを割り当てる用の変数

    public bool MenuFlag;   //メニュー画面の表示・非表示のフラグ

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
        //メニュー画面が非表示ならば
        if(MenuFlag == false)
        { 
            if(Input.GetKeyDown(KeyCode.Escape))        //ESCキーを押したとき
            {
                MenuObject.gameObject.SetActive(true);  //メニュー画面表示
                MenuFlag = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))       //ESCキーを押したとき
            {
                MenuObject.gameObject.SetActive(false); //メニュー画面非表示
                MenuFlag = false;
            }
        }
    }

    //"StartMenuButton"に割り当てている関数
    public void Start_Menu()
    {
        MenuFlag = true;
        MenuObject.gameObject.SetActive(true);          //メニュー画面表示
    }

    //"EndMenuButton"に割り当てている関数
    public void End_Menu()
    {
        MenuFlag = false;
        MenuObject.gameObject.SetActive(false);         //メニュー画面非表示
    }
}
