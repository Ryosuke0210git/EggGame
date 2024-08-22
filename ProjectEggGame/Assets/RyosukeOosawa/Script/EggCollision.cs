using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----------------------------------------------------------------------//
// —‘“¯m‚ª‚Ô‚Â‚©‚Á‚½‚Æ‚«‚Ìˆ—
//----------------------------------------------------------------------//
public class EggCollision : MonoBehaviour
{
    public float bounciness = 1.0f; // ’e—Í«
    public float friction = 0.5f;   // –€C
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Rigidbody‚Ìİ’è
        rb.drag = friction; // ‹ó‹C’ïR
        rb.angularDrag = friction; // ‰ñ“]’ïR
    }

    void OnCollisionEnter(Collision collision)
    {
        // Õ“Ë‚µ‚½ƒIƒuƒWƒFƒNƒg‚ª‘¼‚Ì—‘‚Å‚ ‚é‚©Šm”F
        if (collision.gameObject.CompareTag("Egg"))
        {
            // Õ“Ë‚Ìî•ñ‚ğæ“¾
            Rigidbody otherRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 relativeVelocity = rb.velocity - otherRb.velocity;

            // ’e—Í«‚ÉŠî‚Ã‚¢‚Ä”½”­‚·‚é—Í‚ğŒvZ
            float impulse = Vector3.Dot(relativeVelocity, collision.contacts[0].normal) * (1 + bounciness);

            // Õ“Ë‚µ‚½•ûŒü‚É”½”­‚·‚é—Í‚ğ‰Á‚¦‚é
            rb.AddForce(collision.contacts[0].normal * impulse, ForceMode.Impulse);
            otherRb.AddForce(-collision.contacts[0].normal * impulse, ForceMode.Impulse);

            // ”½”­—Í‚ÉŠî‚Ã‚¢‚Ä‰ñ“]‚Ì•â³
            Vector3 angularImpulse = Vector3.Cross(collision.contacts[0].normal, relativeVelocity);
            rb.AddTorque(angularImpulse * bounciness, ForceMode.Impulse);
            otherRb.AddTorque(-angularImpulse * bounciness, ForceMode.Impulse);
        }
    }
}
