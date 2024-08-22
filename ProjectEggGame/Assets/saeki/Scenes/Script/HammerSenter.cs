using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//--------------------------------
//  作成者：ふじわら　作成日：2024/07/29
//--------------------------------
//  ハンマーを中心に戻すスクリプト
//  Rキーを押している間ハンマーが中心に戻る
//--------------------------------

public class HammerSenter : MonoBehaviour
{
    private HingeJoint hj;

    private bool isReturn = false;

    private Coroutine coroutine;

    private void Start()
    {
        hj = GetComponent<HingeJoint>();
    }

    private void Update()
    {
        // Rキーを押したらハンマーが中心に戻る
        if (Input.GetKeyDown(KeyCode.R) && !isReturn)
        {
            isReturn = true;
            coroutine = StartCoroutine(ReturnHammer());
        }

        // Rキーを離すとハンマーが中心に戻る処理を中断
        if (Input.GetKeyUp(KeyCode.R) && isReturn)
        {
            isReturn = false;
            StopCoroutine(coroutine);
        }
    }

    private IEnumerator ReturnHammer()
    {
        // ハンマーが中心に戻るまでの時間
        float time = 0.5f;
        float elapsedTime = 0.0f;

        // ハンマーの初期角度
        float startAngle = hj.angle;

        // ハンマーの中心に戻る角度
        float endAngle = 0.0f;

        hj.useSpring = true;
        hj.useMotor = false;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;

            // ハンマーの角度を補間
            float angle = Mathf.Lerp(startAngle, endAngle, elapsedTime / time);
            JointSpring spring = hj.spring;
            spring.targetPosition = angle;
            hj.spring = spring;

            yield return null;
        }

        hj.useSpring = false;
        hj.useMotor = true;

        isReturn = false;
    }
}
