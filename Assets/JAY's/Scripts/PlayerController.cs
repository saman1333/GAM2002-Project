using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    public float maxSpeed;

    bool grounded = false;
    float groundcheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight;

    public Transform gunTip;
    public GameObject bullet;
    private float fireRate = 0.5f;
    private float nextFire = 0f;

    private bool canHide = false;
    private bool hiding = false;
    public SpriteRenderer rend;

    void Start () {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;

	}

    void Update() {


        if (CrossPlatformInputManager.GetAxis("shoot") > 0) { 
        shootBullet(); }
        

        hideMe();
        dontHideMe();

        if (CrossPlatformInputManager.GetAxis("Jump") > 0)
        {
            JumpMe();
        }



    }

    void FixedUpdate () {

        moveLeft();
        moveRight();

	}

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

   public void fireBullet()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if(facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }else if (!facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            if(transform.position.y>other.transform.position.y+1)
            transform.SetParent(other.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
            transform.SetParent(null);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("box"))
        {
            canHide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("box"))
        {
            canHide = false;
        }
    }

    public void hideMe()
    {
        if (CrossPlatformInputManager.GetAxis("interact") >0)
        {
            if (canHide)
            {
                Physics2D.IgnoreLayerCollision(10, 11, true);
                rend.sortingOrder = 0;
                hiding = true;
            }
           
           
        }
    }

    public void dontHideMe()
    {
        if (!canHide)
        {
            Physics2D.IgnoreLayerCollision(10, 11, false);
            rend.sortingOrder = 2;
            hiding = false;
        }
    }

   public void JumpMe()
    {
        if (grounded)
        {
            grounded = false;
            myAnim.SetBool("IsGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));
        }
    }

    public void shootBullet()
    {
        if (CrossPlatformInputManager.GetAxis("shoot") > 0)
        {
            print("Fire Axis: " + CrossPlatformInputManager.GetAxis("Fire1"));
            fireBullet();
        }
    }

    public void moveLeft()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundcheckRadius, groundLayer);
        myAnim.SetBool("IsGrounded", grounded);

        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

        float move = CrossPlatformInputManager.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));

        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

    }

    public void moveRight()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundcheckRadius, groundLayer);
        myAnim.SetBool("IsGrounded", grounded);

        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

        float move = CrossPlatformInputManager.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));

        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }
    }

}
