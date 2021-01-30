using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KraakanUtilites : MonoBehaviour
{
    public GameObject heldItem;
    public List<string> stash;
    public List<string> returnedItems;
    public int moral;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            foreach (string item in stash)
            {
                Debug.Log(item);
            }
        }
        if (heldItem != null)
        {
            if (gameObject.GetComponent<Kraakscript2>().facingRight)
            {
                heldItem.transform.localPosition = new Vector3(-.5f, -.75f);
            }
            else
            {
                heldItem.transform.localPosition = new Vector3(-.5f, .75f);
            }
        }

    }

    public void HandleObjectives(Collision2D collision)
    {
        if (heldItem == null)
        {
            if (collision.gameObject.tag == "Objective0" || collision.gameObject.tag == "Objective1" || collision.gameObject.tag == "Objective2")
            {

                heldItem = collision.gameObject;
                heldItem.transform.SetParent(this.transform);
                heldItem.transform.SetPositionAndRotation(new Vector3(0, -.5f), heldItem.transform.rotation);
                Debug.Log(heldItem + "is our helditem");
            }
        }
        else
        {
            if (collision.gameObject.tag == "Lair" && heldItem != null)
            {
                stash.Add(heldItem.name);
                DestroyObject(heldItem);
                heldItem = null;
            }
            else if (collision.gameObject.tag == "Human")
            {
                GiveBackItem(heldItem, collision);
            }
        }
    }


    public void GiveBackItem(GameObject item, Collision2D collision)
    {
        for (int i = 0; i < 3; i++)
        {
            if (collision.gameObject.tag =="Objective"+i && item.tag =="Objective"+i)
            {
                returnedItems.Add(item.name);
                collision.gameObject.GetComponent<NPCScript>().Happy();
                moral++;
                heldItem = null;
            }
        }
    }
}
