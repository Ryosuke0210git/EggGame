using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//--------------------------------
//  �쐬�ҁF�ӂ����@�쐬���F2024/07/29
//--------------------------------
//  �n���}�[�𒆐S�ɖ߂��X�N���v�g
//  R�L�[�������Ă���ԃn���}�[�����S�ɖ߂�
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
        // R�L�[����������n���}�[�����S�ɖ߂�
        if (Input.GetKeyDown(KeyCode.R) && !isReturn)
        {
            isReturn = true;
            coroutine = StartCoroutine(ReturnHammer());
        }

        // R�L�[�𗣂��ƃn���}�[�����S�ɖ߂鏈���𒆒f
        if (Input.GetKeyUp(KeyCode.R) && isReturn)
        {
            isReturn = false;
            StopCoroutine(coroutine);
        }
    }

    private IEnumerator ReturnHammer()
    {
        // �n���}�[�����S�ɖ߂�܂ł̎���
        float time = 0.5f;
        float elapsedTime = 0.0f;

        // �n���}�[�̏����p�x
        float startAngle = hj.angle;

        // �n���}�[�̒��S�ɖ߂�p�x
        float endAngle = 0.0f;

        hj.useSpring = true;
        hj.useMotor = false;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;

            // �n���}�[�̊p�x����
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
