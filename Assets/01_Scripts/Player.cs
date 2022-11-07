using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public GameObject player;

    private Gyroscope gyro;
    private float x, y, sensivity = 50F;
    private bool gyroEnable = false;
    private int life = 10;

    public Image lifeBar;
    float maxHP = 300;
     float hp = 300;
    public GameObject prefabBullet;
    public GameObject energyBall;
    public Transform weapon;
    public Image energyBar;
    public EnergyBar bar;

    void Start()
    {

        bar=energyBar.GetComponent<EnergyBar>();
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
        lifeBar.fillAmount = hp / maxHP;
        
    }

    
    void Update()
    {
        lifeBar.fillAmount = hp / maxHP;
        if (gyroEnable)
        {
            x = Input.gyro.rotationRate.x;
            y = Input.gyro.rotationRate.y;
            float xFiltered = FilerGyroValue(x);
            transform.RotateAround(transform.position, transform.right, -xFiltered * sensivity * Time.deltaTime);
            float yFiltered = FilerGyroValue(y);
            transform.RotateAround(transform.position, transform.up, -yFiltered * sensivity * Time.deltaTime);
            //Walk(x);
            //Rotar(y);
        }
        Walk(transform.localEulerAngles.x);
        Rotar(transform.localEulerAngles.y);/**/
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefabBullet, new Vector3(weapon.position.x, weapon.position.y, weapon.position.z), Quaternion.identity.normalized);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
           
            if (bar.ReLoad())
            {
                
                Instantiate(energyBall, new Vector3(weapon.position.x, weapon.position.y, weapon.position.z), Quaternion.identity.normalized);
            }


        }
    }
    public void Damage()
    {
        hp -= 30;
        if (hp==0)
        {
            /*Código para reiniciar Juego*/
        }
    }
    private void Walk(float x2)
    {
        if (x2 >= 20f && x2 <= 50f)
        {
            player.transform.Translate(0, 0, 1f * Time.deltaTime);
        }
    }
    private void Rotar(float x2)
    {
        if (x2 >= 345f && x2 <= 355f)
        {
            float rotationTime = 5f;
            player.transform.Rotate(Vector3.down * (rotationTime * Time.deltaTime));
        }
        else if (x2 >= 5f && x2 <= 15f)
        {
            float rotationTime = 5f;
            player.transform.Rotate(Vector3.up * (rotationTime * Time.deltaTime));
        }
    }

    private float FilerGyroValue(float axis)
    {
        if (axis < -0.1f || axis > 0.1f)
        {
            return axis;
        }
        else
        {
            return 0;
        }
    }
}
