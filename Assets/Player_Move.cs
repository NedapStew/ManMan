using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour {

    private bool face_right = false;
    private int pSpeed = 10;
    private int pJumpPower = 500;
    public float moveX;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PlayerMove();
	}

    void PlayerMove()
    {
        //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        //ANIMATION

        //PLAYER DIRECTION
        if(moveX < 0.0f && face_right == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && face_right == true)
        {
            FlipPlayer();
        }
        //PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * pSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        //JUMP CODE
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * pJumpPower);

    }

    void FlipPlayer()
    {
        face_right = !face_right;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
