using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlCont : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    Rigidbody2D rigid;

    [SerializeField] float jumpPower;

    bool ontheGround;
    public Transform groundPo;
    public LayerMask groundLayer;

    bool doubleJump;
    public float recoilDuration,recoilPower;
    float recoilCounter;
    bool sideisRight;

    Animator anima;

    public float DjumpPower;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
    }

    private void Update()
    {
        if(recoilCounter <= 0)
        {
            moveeFunc();
            jumpFunc();
            rotationSideFunc();
        } else
        {
            recoilCounter -= Time.deltaTime;

            if(sideisRight)
            {
                rigid.velocity = new Vector2(-recoilPower, rigid.velocity.y);
            }else
            {
                rigid.velocity = new Vector2(recoilPower, rigid.velocity.y);
            }
        }

        anima.SetFloat("movementSpeed", Mathf.Abs(rigid.velocity.x));
        anima.SetBool("ontheGround", ontheGround);

    }


    void moveeFunc()
    {
        float h = Input.GetAxis("Horizontal");
        float speed = h * movementSpeed;

        rigid.velocity = new Vector2(speed, rigid.velocity.y);
    }


    void jumpFunc()
    {
        ontheGround = Physics2D.OverlapCircle(groundPo.position, .2f, groundLayer);

        if(ontheGround)
        {
            doubleJump = true;
        }

        if(Input.GetButtonDown("Jump"))
        {
            if(ontheGround)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
            }else
            {
                if(doubleJump)
                {
                    rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
                    doubleJump = false;                }
                
            }
            
        }

        
    }


    void rotationSideFunc()
    {
        Vector2 tempScale = transform.localScale;

        if(rigid.velocity.x > 0)
        {
            sideisRight = true;
            tempScale.x = 1f;

        } else if(rigid.velocity.x<0)
        {
            sideisRight = false;
            tempScale.x = -1f;
        }

        transform.localScale = tempScale;
    }

    public void recoilFunc()
    {
        recoilCounter = recoilDuration;
        rigid.velocity = new Vector2(0, rigid.velocity.y);

        anima.SetTrigger("damage");
    }

    public void DJumpFunc()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, DjumpPower);
    }
}
