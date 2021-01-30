using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    public GameObject kraaka;
    private Kraakscript2 kraakscript;
    public Slider boostChargeSlider;
    public Slider energySlider;
    public Slider healthSlider;
    public int moralMeter;
    public float energy;
    public float health;


    // Start is called before the first frame update
    void Start()
    {
        kraakscript = kraaka.GetComponent<Kraakscript2>();
    }

    // Update is called once per frame
    void Update()
    {
        energy = kraakscript.currentEnergy / kraakscript.maxEnergy;
        health = kraakscript.healthPoints / kraakscript.maxHealthPoints;

        float boostCharge = kraakscript.diveBoostTimer / kraakscript.diveBoostChargeTime;

        if (boostCharge > 1)
            boostCharge = 1;

        if (kraakscript.diveBoostPerfect)
            boostChargeSlider.GetComponent<barChangeColorScript>().color2Active = true;
        else
            boostChargeSlider.GetComponent<barChangeColorScript>().color2Active = false;


        if (energy > 1)
        {
            energy = 1;
        }

        if (energy < 0)
        {
            energy = 0;
        }
        

        energySlider.value = energy;
        healthSlider.value = health;
        boostChargeSlider.value = boostCharge;

    }
}
