using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlHealthCont : MonoBehaviour
{
    public int  maxHealth, instantHealth;

    UICont uiController;

    [SerializeField] GameObject deathEfect;

    public float duratioN;
    float counteR;

    SpriteRenderer sr;

    PlCont plCont;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        uiController = Object.FindObjectOfType<UICont>();
        plCont = Object.FindObjectOfType<PlCont>();
    }


    private void Start()
    {
        instantHealth = maxHealth;
    }

    private void Update()
    {
        counteR -= Time.deltaTime;
        if(counteR <= 0)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        }
    }

    public void takeDamageFunc()
    {
        if(counteR <=0)
        {
            instantHealth--;

            if (instantHealth <= 0)
            {
                instantHealth = 0;
                gameObject.SetActive(false);
                Instantiate(deathEfect, transform.position, transform.rotation);

            }
            else
            {
                counteR = duratioN;
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);

                plCont.recoilFunc();
            }

            uiController.updatingHealth();
        }
        

    }

    public void incHealthFunc()
    {
        instantHealth++;

        if(instantHealth >= maxHealth)
        {
            instantHealth = maxHealth;
        }
        uiController.updatingHealth();
    }

}
