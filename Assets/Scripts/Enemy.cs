using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : MonoBehaviour
{
    public GameObject currentTarget;

    public abstract void  Attack();
    public abstract void Update();
    public abstract void Start();
    public abstract void TakeDamage(float damage);


}
