using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCont : MonoBehaviour
{
    PlHealthCont plHealthCont;

    private void Awake()
    {
        plHealthCont = Object.FindObjectOfType<PlHealthCont>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            plHealthCont.takeDamageFunc();
        }
    }
}
