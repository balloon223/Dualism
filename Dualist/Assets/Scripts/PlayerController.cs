using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;
    private Vector2 moveDirection;

    private bool facingRight = true;

    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    public bool isJumping;

    public Animator anim;

    ActivateWorlds activateWorlds;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        activateWorlds = FindObjectOfType<ActivateWorlds>();
    }


    void Update()
    {
        if (activateWorlds.realWorldIsActive == 1) //when real world is active
        {
            Physics2D.gravity = new Vector2(0, -9.8f);
            moveInput = Input.GetAxisRaw("Horizontal");
            //rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            transform.position += new Vector3(moveInput, 0, 0) * Time.deltaTime * speed;

            if (facingRight == false && moveInput > 0)
            {
                Flip();
            }
            else if (facingRight == true && moveInput < 0)
            {
                Flip();
            }

            isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

            if (isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow))
            {
                //   anim.SetTrigger("takeOff");
                isJumping = true;
                jumpTimeCounter = jumpTime;
                rb.velocity = Vector2.up * jumpForce;
            }

            /*if(isJumping == false){
                    if(Input.GetKey(KeyCode.Space)){
                        if(jumpTimeCounter > 0){

                            rb.velocity = Vector2.up * jumpForce;
                            jumpTimeCounter -= Time.deltaTime;
                        } else {

                        }
                    }
                }*/
            if (isGrounded == true)
            {
                anim.SetBool("isJumping", false);
            }
            else
            {
                anim.SetBool("isJumping", true);
            }

            if (!Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
            {
                isJumping = false;
            }

            if (moveInput == 0)
            {
                anim.SetBool("isRunning", false);
            }
            else
            {
                anim.SetBool("isRunning", true);
            }
        }
        else //when real world is inactive
        {
            Physics2D.gravity = new Vector2(0, 6.8f);
            moveInput = Input.GetAxisRaw("Horizontal");

            transform.position += new Vector3(moveInput, 0, 0) * Time.deltaTime * speed;

            if (facingRight == false && moveInput > 0)
            {
                Flip();
            }
            else if (facingRight == true && moveInput < 0)
            {
                Flip();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                //   anim.SetTrigger("takeOff");
                isJumping = true;
                jumpTimeCounter = jumpTime;
                rb.velocity = Vector2.down * jumpForce;
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
