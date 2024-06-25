using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duckCont : MonoBehaviour
{
    public float movementSpeed;

    public Transform leftTarget, rightTarget;

    bool rightSide;

    Rigidbody2D rigid;

    public SpriteRenderer sr;

    public float movementDuration, waitingDuration;
    float movementCounter, waitingCounter;

    Animator anima;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
    }

    private void Start()
    {
        leftTarget.parent = null;
        rightTarget.parent = null;

        rightSide = true;

        movementCounter = movementDuration;
    }

    private void Update()
    {
        if(movementCounter >0)
        {
            movementCounter -= Time.deltaTime;

            if (rightSide)
            {
                rigid.velocity = new Vector2(movementSpeed, rigid.velocity.y);

                sr.flipX = true;

                if (transform.position.x > rightTarget.position.x)
                {
                    rightSide = false;
                }
            }
            else
            {
                rigid.velocity = new Vector2(-movementSpeed, rigid.velocity.y);

                sr.flipX = false;

                if (transform.position.x < leftTarget.position.x)
                {
                    rightSide = true;
                }
            }

            if(movementCounter <= 0)
            {
                waitingCounter = Random.Range(waitingDuration * 0.8f, waitingDuration * 1.3f);

            }

            anima.SetBool("moving", true);
        } else if(waitingCounter >0 )
        {
            waitingCounter -= Time.deltaTime;
            rigid.velocity = new Vector2(0, rigid.velocity.y);

            if(waitingCounter <=0)
            {
                movementCounter = Random.Range(movementDuration * 0.8f, waitingDuration * 1.3f);
            }
            anima.SetBool("moving", false);
        }

        
    }
}
