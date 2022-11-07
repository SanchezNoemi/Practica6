using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeBar : MonoBehaviour
{
    public Image lifeBar;
    float maxHP = 300;
    float hp= 150;
    void Start()
    {
        lifeBar.fillAmount = hp / maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
