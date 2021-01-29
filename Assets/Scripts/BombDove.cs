using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDove : Enemy
{
    public GameObject AggroRange;
    public float damageValue;


    public override void Attack()
    {
        
    }

    public override void Start()
    {
        speed = 35.0f;
        damageValue = 10;
    }

    public override void Update()
    {
        if (currentTarget != null)
        {
            Debug.Log("2");

            if (Vector3.Distance(this.transform.position,currentTarget.transform.position) < 30f)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, currentTarget.transform.position, speed * Time.deltaTime);

                Vector3 difference = currentTarget.transform.position - this.transform.position;

                float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
                Debug.Log("b");

            }
            else if (Vector3.Distance(this.transform.position, currentTarget.transform.position) > 30f)
            {
                currentTarget = null;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Player")
        {
            collision.gameObject.GetComponent<Kraakscript2>().TakeDamage(damageValue);
            Destroy(this);
        }
    }


}
