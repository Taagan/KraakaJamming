using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : MonoBehaviour
{
    public GameObject AggroRange;
    public GameObject currentTarget;
    protected SpriteRenderer spriteRenderer;
    protected bool facingRight;
    protected float damageValue;

    public abstract void  Attack();
    public abstract void Update();
    public abstract void Start();
    public abstract void TakeDamage(float damage);


}
