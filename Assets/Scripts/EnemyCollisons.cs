﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisons : MonoBehaviour
{
    public GameObject parent;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            parent.GetComponent<Enemy>().currentTarget = collision.gameObject;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            parent.GetComponent<Enemy>().currentTarget = collision.gameObject;
        }
    }
}
