using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//--------------------------------
//  �쐬�ҁF�ӂ����@�쐬���F2024/07/29
//--------------------------------
//  �n���}�[���ǂɓ����������̃v���C���[����
//  �v���C���[��j�󂵁A�G�t�F�N�g�̃I�u�W�F�N�g�𐶐�����
//--------------------------------
public class HammerHit_player : HammerHit
{
    [Header("�G�t�F�N�g�̃v���n�u"), SerializeField]
    private GameObject effectPrefab;

    override protected void HitPlay( Collision collision )
    {
        // �v���C���[��j��
        Destroy(gameObject);

        Debug.Log( "�v���C���[��j�󂵂܂���" );

        // �G�t�F�N�g�̃v���n�u�𐶐�
        GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
    }
}
