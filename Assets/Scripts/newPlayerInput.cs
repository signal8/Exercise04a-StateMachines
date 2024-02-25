using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPlayerInput : MonoBehaviour
{
	public Player p;
	public Controller2D c2d;

    	// Update is called once per frame
    	void Update()
    	{
		Animator anim = GetComponentInChildren<Animator>();
		SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();

        	Vector2 directionalInput = Vector2.zero;
		directionalInput.x = Input.GetAxis("Horizontal");
		directionalInput.y = Input.GetAxis("Vertical");
		p.SetDirectionalInput(directionalInput);

		if (directionalInput.x == 0)
			anim.SetBool("isWalking", false);
		else 
		{
			anim.SetBool("isWalking", true);
			if (directionalInput.x < 0) sr.flipX = true;
			else sr.flipX = false;
		}

		if    (Input.GetKeyDown("space")) p.OnJumpInputDown();
		else if (Input.GetKeyUp("space")) p.OnJumpInputUp();

		if (c2d.collisions.below) anim.SetBool("isJumping", false);
		else anim.SetBool("isJumping", true);
    	}
}
