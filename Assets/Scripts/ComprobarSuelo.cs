using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobarSuelo : MonoBehaviour
{
    public static bool isGrounded;
    private Collider2D collider;
    private void Update()
    {
        collider = GetComponent<Collider2D>();
        if (collider.IsTouchingLayers(LayerMask.GetMask("Terreno")))
        {
            isGrounded = true;
            MovimientoPersonaje.animator.SetBool("isGrounded", true);
        }
        else
        {
            isGrounded = false;
            MovimientoPersonaje.animator.SetBool("isGrounded", false);
        }
    }
}
