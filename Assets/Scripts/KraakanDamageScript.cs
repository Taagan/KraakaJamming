using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KraakanDamageScript : MonoBehaviour
{

    public float damage;
    public bool canTakeDamage;
    public float iFrameTimer;
    protected float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        canTakeDamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canTakeDamage)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            if (timer >= iFrameTimer)
            {
                timer = 0;
                canTakeDamage = true;
            }

        }
    }



    public void IFrame()
    {
        canTakeDamage = false;
    }
}
