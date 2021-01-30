using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDove : Enemy
{
    [SerializeField]
    protected float health = 1;
    public float speed;
    public float ignoreDistance;
    public float rotationSpeed;
    

    public override void Attack()
    {
        
    }

    public override void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        if (currentTarget != null)
        {
            if (Vector3.Distance(this.transform.position,currentTarget.transform.position) < 30f)
            {

                Vector2 difference = currentTarget.transform.position - this.transform.position;


                float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

                Quaternion rotation = Quaternion.AngleAxis(rotationZ, Vector3.forward);
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, rotationSpeed * Time.deltaTime);


                this.transform.position += this.transform.right * speed * Time.deltaTime;

            }
            else if (Vector3.Distance(this.transform.position, currentTarget.transform.position) > ignoreDistance)
            {
                currentTarget = null;
            }
        }
        AutoRotate();
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Player")
        {
            if (collision.gameObject.GetComponentInParent<KraakanDamageScript>().canTakeDamage)
            {
            collision.gameObject.GetComponentInParent<KraakanDamageScript>().IFrame();
            collision.gameObject.GetComponent<Kraakscript2>().TakeDamage(damageValue);
            }
        }
        if (collision.gameObject.tag =="PlayerHitBox")
        {
            Debug.Log(gameObject.name + " took damage");
            TakeDamage(collision.gameObject.GetComponentInParent<KraakanDamageScript>().damage);
        }
    }

    private void AutoRotate()
    {

        if (transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z <= 270)
        {
            facingRight = false;
            if (!spriteRenderer.flipY)
                spriteRenderer.flipY = true;
        }
        else
        {
            facingRight = true;
            if (spriteRenderer.flipY)
                spriteRenderer.flipY = false;
        }
    }

    public override void TakeDamage(float damage)
    {
        health -= damage;
    }
}
