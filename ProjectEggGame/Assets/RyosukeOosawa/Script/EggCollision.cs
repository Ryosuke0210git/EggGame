using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----------------------------------------------------------------------//
// 卵同士がぶつかったときの処理
//----------------------------------------------------------------------//
public class EggCollision : MonoBehaviour
{
    public float bounciness = 1.0f; // 弾力性
    public float friction = 0.5f;   // 摩擦
    private Rigidbody rb;

    // AudioSourceコンポーネントを取得
    AudioSource[] sounds;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sounds = this.GetComponents<AudioSource>();

        // Rigidbodyの設定
        rb.drag = friction; // 空気抵抗
        rb.angularDrag = friction; // 回転抵抗
    }

    void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトが他の卵であるか確認
        if (collision.gameObject.CompareTag("Egg"))
        {
            // 衝突音
            sounds[0].Play();

            // 衝突の情報を取得
            Rigidbody otherRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 relativeVelocity = rb.velocity - otherRb.velocity;

            // 弾力性に基づいて反発する力を計算
            float impulse = Vector3.Dot(relativeVelocity, collision.contacts[0].normal) * (1 + bounciness);

            // 衝突した方向に反発する力を加える
            rb.AddForce(collision.contacts[0].normal * impulse, ForceMode.Impulse);
            otherRb.AddForce(-collision.contacts[0].normal * impulse, ForceMode.Impulse);

            // 反発力に基づいて回転の補正
            Vector3 angularImpulse = Vector3.Cross(collision.contacts[0].normal, relativeVelocity);
            rb.AddTorque(angularImpulse * bounciness, ForceMode.Impulse);
            otherRb.AddTorque(-angularImpulse * bounciness, ForceMode.Impulse);
        }
    }
}
