using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isEnergyBall=false;
    void Start()
    {
        Destroy(gameObject, 5);
    }

    
    void Update()
    {
        //transform.Translate(0, 3f * Time.deltaTime,0 );
        transform.Translate(Vector3.forward * Time.deltaTime);
    }
}
