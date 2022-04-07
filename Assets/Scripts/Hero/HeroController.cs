using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public float speed;                //Floating point variable to store the player's movement speed.
    private float attackTime = .25f;
    private float attackCounter = .25f;
    private bool isAttack;
    //public Camera cam;
    private Animator myAnim;
    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private Vector2 veloctiy;
    //Vector2 mousePos;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void Update()
    {
        //Use the two store floats to create a new Vector2 variable movement.
        rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;
        myAnim.SetFloat("moveX", rb2d.velocity.x);
        myAnim.SetFloat("moveY", rb2d.velocity.y);
        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat(("LastMoveX"), Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat(("LastMoveY"), Input.GetAxisRaw("Vertical"));
        }
        if (isAttack)
        {
            rb2d.velocity = Vector2.zero;
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                myAnim.SetBool("IsAttack", false);
                isAttack = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attackCounter = attackTime;
            myAnim.SetBool("IsAttack", true);
            isAttack = true;
        }
    }
    void FixedUpdate()
    {
        //Vector2 lookDir = mousePos - rb2d.position;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //rb2d.rotation = angle;

    }
}
