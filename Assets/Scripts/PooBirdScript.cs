using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooBirdScript : Enemy
{
    public GameObject poop;
    [SerializeField]
    protected float health = 1;
    public float speed;
    public float ignoreDistance;
    public float rotationSpeed;
    public float poopCD = 1;
    [HideInInspector]
    public float poopTimer;
    public float rotateTimer;
    int randomValue;

    public override void Attack()
    {
        Instantiate(poop, new Vector3(this.transform.position.x, this.transform.position.y - 1), Quaternion.identity);
    }

    public override void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        speed = 10;
        randomValue = 5;
    }

    public override void TakeDamage(float damage)
    {
        health -= damage;
    }

    public override void Update()
    {
        AutoRotate();
        Movement();
        poopTimer += Time.deltaTime;
        rotateTimer += Time.deltaTime;
        if (poopTimer >= poopCD)
        {
            Attack();
            poopTimer = 0;
        }
        if (rotateTimer > randomValue)
        {
            randomValue = Random.Range(5, 25);
            Rotate();
            rotateTimer = 0;
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponentInParent<KraakanDamageScript>().canTakeDamage)
        {
            Debug.Log(gameObject.name + " dealt damage");

            Debug.Log(collision.gameObject.GetComponentInParent<KraakanDamageScript>().canTakeDamage);
            collision.gameObject.GetComponentInParent<KraakanDamageScript>().IFrame();
            collision.gameObject.GetComponent<Kraakscript2>().TakeDamage(damageValue);
        }
        if (collision.gameObject.tag == "PlayerHitBox")
        {
            Debug.Log(gameObject.name + " took damage");
            TakeDamage(collision.gameObject.GetComponentInParent<KraakanDamageScript>().damage);
        }
    }
    private void Movement()
    {
        if (currentTarget != null)
        {
            Debug.Log(currentTarget.name);
            this.transform.position += this.transform.right * speed * Time.deltaTime;

            if (Vector3.Distance(this.transform.position, currentTarget.transform.position) > ignoreDistance)
            {
                currentTarget = null;
            }
        }
    }


    private void Rotate()
    {
        this.transform.Rotate(0.0f, 0.0f, 180);
    }

    //this.transform.Rotate(0.0f, 0.0f, Mathf.Sin(Random.value));

}
