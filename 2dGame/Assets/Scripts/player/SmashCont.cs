using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashCont : MonoBehaviour
{

    [SerializeField] GameObject deathEfect;


    PlCont plCont;


    private void Awake()
    {
        plCont = Object.FindObjectOfType<PlCont>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("duck"))
        {
            other.transform.parent.gameObject.SetActive(false);
            Instantiate(deathEfect, transform.position, transform.rotation);

            plCont.DJumpFunc();
        }
        
    }
}
