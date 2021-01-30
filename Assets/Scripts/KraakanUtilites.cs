using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KraakanUtilites : MonoBehaviour
{
    public GameObject holdItem;
    public List<GameObject> stash;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            foreach (GameObject item in stash)
            {
                Debug.Log(item);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (holdItem == null)
        {
            if (collision.gameObject.tag =="Objective1" || collision.gameObject.tag == "Objective2" || collision.gameObject.tag == "Objective3")
            {
                holdItem = collision.gameObject;
            }
        }
        else
        {
            if (collision.gameObject.tag == "Lair" && holdItem != null)
            {
                stash.Add(holdItem);
                holdItem = null;
            }
        }
    }
}
