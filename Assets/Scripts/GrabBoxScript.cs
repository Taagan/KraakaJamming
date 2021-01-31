using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBoxScript : MonoBehaviour
{
    public GameObject parent;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("B");
        parent.GetComponent<KraakanUtilites>().HandleObjectives(collision);
    }
}
