using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//--------------------------------
//  �쐬�ҁF�ӂ����@�쐬���F2024/07/29
//--------------------------------
//  �n���}�[���ǂɓ����������̏���
//--------------------------------

public class HammerHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // hanmmer���C���[�ɓ���������
        if (collision.gameObject.layer == LayerMask.NameToLayer("hammer"))
        {
            Debug.Log( "�j�󂵂܂���" );

            HitPlay( collision );
        }
    }

    virtual protected void HitPlay( Collision collision )
    {
        // hanmmer���C���[�ɓ���������
    }
}
