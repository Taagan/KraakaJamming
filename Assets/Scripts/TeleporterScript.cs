using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterScript : MonoBehaviour
{
    public GameObject leftTeleporter;
    public GameObject rightTeleporter;
    Vector3 leftPos;
    Vector3 rightPos;
    private void Start()
    {
        leftPos = leftTeleporter.transform.position;
        rightPos = rightTeleporter.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.gameObject.tag =="TeleporterLeft")
        {
            Debug.Log("b");
            if (collision.gameObject.tag =="Player" || collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.transform.position = new Vector3(rightPos.x -10,collision.gameObject.transform.position.y, -5);
            }
        }
        else if (this.gameObject.tag=="TeleporterRight")
        {
            Debug.Log("a");
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.transform.position = new Vector3(leftPos.x + 10, collision.gameObject.transform.position.y,-5);
            }
        }
    }

}
