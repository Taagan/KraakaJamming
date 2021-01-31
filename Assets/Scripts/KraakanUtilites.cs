using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KraakanUtilites : MonoBehaviour
{
    public GameObject heldItem;
    GameObject objectives;
    public List<string> stash;
    public List<string> returnedItems;
    public int moral;
    private bool obj0, obj1, obj2;
    // Start is called before the first frame update
    void Start()
    {
        obj0 = false;
        obj1 = false;
        obj2 = false;
        objectives = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
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
                if (heldItem.tag=="Objective0")
                {
                    obj0 = true;
                }
                else if (heldItem.tag == "Objective1")
                {
                    obj1 = true;
                }
                else if (heldItem.tag == "Objective2")
                {
                    obj2 = true;
                }
                stash.Add(heldItem.name);
                Destroy(heldItem);
                heldItem = null;
            }
            else
            {
                GiveBackItem(heldItem, collision);
            }
        }
    }

    private void ObjToTrue(int i)
    {
        if (i == 0)
        {
            obj0 = true;
            objectives.GetComponent<Objectives>().CompleteObjectives(0);
        }
        if (i == 1)
        {
            obj1 = true;
            objectives.GetComponent<Objectives>().CompleteObjectives(1);
        }
        if (i == 2)
        {
            obj2 = true;
            objectives.GetComponent<Objectives>().CompleteObjectives(2);
        }
    }

    public void GiveBackItem(GameObject item, Collision2D collision)
    {
        for (int i = 0; i < 3; i++)
        {
            if (collision.gameObject.tag =="Human"+i && item.tag =="Objective"+i)
            {
                ObjToTrue(i);
                returnedItems.Add(item.name);
                collision.gameObject.GetComponent<NPCScript>().Happy();
                moral++;
                heldItem = null;
                Destroy(item);
            }
        }
    }
}
