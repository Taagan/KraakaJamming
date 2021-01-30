using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopScript : MonoBehaviour
{
    public int damageValue = 10;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponentInParent<KraakanDamageScript>().canTakeDamage)
        {
            collision.gameObject.GetComponentInParent<KraakanDamageScript>().IFrame();
            collision.gameObject.GetComponent<Kraakscript2>().TakeDamage(damageValue);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "PlayerHitBox")
        {
            Debug.Log(gameObject.name + " took damage");
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag =="Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
