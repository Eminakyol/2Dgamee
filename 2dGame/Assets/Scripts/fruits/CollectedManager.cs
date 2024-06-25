using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedManager : MonoBehaviour
{

    [SerializeField] bool isFruit, isStraw;

    [SerializeField] GameObject collectedEfect;

    bool isCollected;

    LevelManager levelManager;
    UICont uiController;
    PlHealthCont plHealthCont;
    

    private void Awake()
    {
        levelManager = Object.FindObjectOfType<LevelManager>();
        uiController = Object.FindObjectOfType<UICont>();
        plHealthCont = Object.FindObjectOfType<PlHealthCont>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !isCollected)
        {
            if(isFruit)
            {
                levelManager.collectedFruitNum++;
                isCollected = true;
                Destroy(gameObject);

                uiController.updatingFruitNum();

                Instantiate(collectedEfect, transform.position, transform.rotation);
            }

            if(isStraw)
            {
                if(plHealthCont.instantHealth != plHealthCont.maxHealth)
                {
                    
                    isCollected = true;
                    Destroy(gameObject);
                    plHealthCont.incHealthFunc();
                    Instantiate(collectedEfect, transform.position, transform.rotation);
                }
            }

            
        }
    }
}
