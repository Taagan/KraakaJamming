using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barChangeColorScript : MonoBehaviour
{

    public Color color1 = Color.red;
    public Color color2 = Color.green;

    public bool color2Active = false;

    private Image bar;


    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (color2Active)
            bar.color = color2;
        else
            bar.color = color1;
    }
}
