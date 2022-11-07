using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergyBar : MonoBehaviour
{
    public Image energyBar;
    private float timer = 0;
    private float timeBtwSpawn = 10;
    //private bool flag=false;
    void Start()
    {
        timer = timeBtwSpawn;
    }

    void Update()
    {
        Load();
    }

    public bool ReLoad()
    {
        
        if (energyBar.fillAmount==0)
        {
            //Debug.Log("if" + energyBar.fillAmount);
            timer = timeBtwSpawn;
           

            return true;
            
        }
        else
        {
            //Debug.Log("else"  + energyBar.fillAmount);
            return false;
        }
        
    }

    public void Load()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            energyBar.fillAmount = timer / timeBtwSpawn;

        }
        
    }

}
