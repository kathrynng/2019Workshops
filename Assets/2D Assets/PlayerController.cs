using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
	[HideInInspector] public bool facingRight = false;
	public float walkSpeed = 1;

	private Rigidbody2D rb2d;
	Animator animator;

	//Animation flags
	bool _isFalling = false;
	private bool _isGrounded = true;

	const int STATE_IDLE = 0;
	const int STATE_WALK = 1;
	const int STATE_FALL = 2;

	string _currentDirection = "left";
	int _currentAnimationState = STATE_IDLE;

	// Use this for initialization
	void Awake () 
	{
		rb2d = GetComponent<Rigidbody2D>();
		animator = this.GetComponent<Animator>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		

		if (Input.GetKey ("right") )
        {
            if(_isGrounded)
            changeState(STATE_WALK);
 
            changeDirection("right");
            transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
 
        }
        else if (Input.GetKey ("left"))
        {
            if(_isGrounded)
            changeState(STATE_WALK);

            changeDirection ("left");
            transform.Translate(Vector3.left * walkSpeed * Time.deltaTime); 
 
        }
        else
        {
			if(rb2d.velocity.y < -0.1){
				_isGrounded = false;
            	changeState(STATE_FALL);
			}else{
				_isGrounded = true;
			}

            if(_isGrounded)
            changeState(STATE_IDLE);
        }

	}

	void changeState(int state){
 
        if (_currentAnimationState == state)
        return;
 
        switch (state) {
 
        case STATE_WALK:
            animator.SetInteger ("state", STATE_WALK);
            break;
  
        case STATE_IDLE:
            animator.SetInteger ("state", STATE_IDLE);
            break;
 
        case STATE_FALL:
            animator.SetInteger ("state", STATE_FALL);
            break;
 
        }
 
        _currentAnimationState = state;
    }

	void changeDirection(string direction)
     {
 
         if (_currentDirection != direction)
         {
             if (direction == "right")
             {
             transform.Rotate (0, -180, 0);
             _currentDirection = "right";
             }
             else if (direction == "left")
             {
             transform.Rotate (0, 180, 0);
             _currentDirection = "left";
             }
         }
 
     }
		
}