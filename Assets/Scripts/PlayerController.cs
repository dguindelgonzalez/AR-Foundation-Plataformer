using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Private Fields

    Rigidbody2D myRB;
    SpriteRenderer myRenderer;
    Animator myAnim;
    bool facingRight = true;
    bool grounded = false;
    bool canMove = true;
    float groundCheckRadius = 0.2f;

    #endregion

    #region Public Properties
    
    public float MaxSpeed;
    public float JumpPower;
    public LayerMask GroundLayer;
    public Transform GroundCheck;

    #endregion

    #region Unity3D Methods

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D >();
        myRenderer = GetComponent<SpriteRenderer>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove && grounded && Input.GetAxis("Jump") > 0)
	    {
            myAnim.SetBool("IsGrounded", false);
            myRB.velocity = new Vector2(myRB.velocity.x, 0f);
            myRB.AddForce(new Vector2(myRB.velocity.x, JumpPower), ForceMode2D.Impulse);
            grounded = false;
    	}

        grounded = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, GroundLayer);
        myAnim.SetBool("IsGrounded", grounded);

        var move = Input.GetAxis("Horizontal");

        if (canMove)
	    {   
            if (move > 0 && !facingRight)
	            Flip();
            else if(move<0 && facingRight)
                Flip();

            myRB.velocity =new Vector2(move * MaxSpeed, myRB.velocity.y);
            myAnim.SetFloat("MoveSpeed",Mathf.Abs(move));
	    }
        else
        {
            myRB.velocity =new Vector2(0, myRB.velocity.y);
            myAnim.SetFloat("MoveSpeed",0);
        }
    }

    #endregion

    #region Public Methods

    public void ToogleCanMove()
    {
        canMove = !canMove;
    }

    #endregion

    #region Private Methods
    private void Flip()
    {
        facingRight = !facingRight;
        myRenderer.flipX = !myRenderer.flipX;
    }
    #endregion
}
