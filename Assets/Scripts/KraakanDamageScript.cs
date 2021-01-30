using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KraakanDamageScript : MonoBehaviour
{

    public float damage;
    public bool canTakeDamage;
    public float iFrameTimer;
    protected float iTimer = 0;

    private SpriteRenderer attack_nebb;
    private BoxCollider2D hurtBox;

    [HideInInspector]
    public bool attacking = false;
    [HideInInspector]
    public float attackTimer = 0;
    public float attackStandardTime = 1f;//seconds of attack, multiplied by lengthMultiplier in StartAttack

    // Start is called before the first frame update
    void Start()
    {
        canTakeDamage = true;
        attack_nebb = transform.Find("näbb").GetComponent<SpriteRenderer>();
        hurtBox = transform.Find("HurtBox").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (iTimer > 0)
            iTimer -= Time.deltaTime;
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;

        //enable/disable attack-hitbox
        //beroende på om man attackerar eller inte
        //också den attack-näbben
        float alpha = attackTimer / attackStandardTime;
        if (alpha > 1)
            alpha = 1;
        attack_nebb.color = new Color(attack_nebb.color.r, attack_nebb.color.g, attack_nebb.color.b, alpha);


        if (attackTimer > 0)
            hurtBox.enabled = true;
        else
            hurtBox.enabled = false;


        if (iTimer > 0 || attackTimer > 0)
            canTakeDamage = false;
        else
            canTakeDamage = true;
    }

    public void StartAttack(float lengthMultiplier)
    {
        attackTimer = attackStandardTime * lengthMultiplier;
    }
    
    public void IFrame()
    {
        canTakeDamage = false;
        iTimer = iFrameTimer;
    }
}
