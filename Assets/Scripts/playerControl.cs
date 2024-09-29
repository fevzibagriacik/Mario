using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    Rigidbody2D rbPlayer;
    Animator animPlayer;
    public Transform groundCheckPosition;
    public LayerMask groundCheckLayer;

    public float moveSpeed = 1f;
    public float jumpSpeed = 1f, nextJumpTime, jumpFrequency;
    public float groundCheckRadius = 1f;

    public bool facingRight = true;
    public bool isGrounded = false;
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
    }
    void Update()
    {
        HorizontalMove();

        onGroundControl();

        FlipFaceControl();

        JumpControl();
    }

    void HorizontalMove()
    {
        rbPlayer.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rbPlayer.velocity.y);

        animPlayer.SetFloat("playerSpeed", Mathf.Abs(rbPlayer.velocity.x));
    }

    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void FlipFaceControl()
    {
        if(rbPlayer.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }
        else if(rbPlayer.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }
    }

    void Jump()
    {
        rbPlayer.AddForce(new Vector2(0, jumpSpeed));
    }

    void JumpControl()
    {
        if(Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;

            Jump();
        }
    }

    void onGroundControl()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);

        animPlayer.SetBool("isGroundedAnim", isGrounded);
    }





}
