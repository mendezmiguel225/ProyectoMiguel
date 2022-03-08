using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    private Rigidbody2D r;
    public static Animator animator;
    private SpriteRenderer character;
    private float jumpForce = 8;
    private float runSpeed = 3;


    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        character = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        float velocidad = Input.GetAxisRaw("Horizontal");
        r.velocity = new Vector2(velocidad * runSpeed, r.velocity.y);

        animator.SetFloat("run", Mathf.Abs(velocidad));

        if (velocidad < 0)
        {
            character.flipX = true;
        }

        else if (velocidad > 0)
        {
            character.flipX = false;
        }
        Jump();
        Fall();

    }
    private void Jump()
    {
        if (Input.GetButton("Jump")&&ComprobarSuelo.isGrounded)
        {
            r.velocity = new Vector2(r.velocity.x, jumpForce);
            animator.SetFloat("jump", r.velocity.y);
        }
    }

    private void Fall()
    {
        if (!ComprobarSuelo.isGrounded)
        {
            animator.SetFloat("jump", r.velocity.y);

        }
    }
}
