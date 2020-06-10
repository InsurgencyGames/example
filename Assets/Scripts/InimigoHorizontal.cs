using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoHorizontal : MonoBehaviour
{
    private bool colidde = false;

    private float move = -2;
    
    void Start()
    {
    }

    void Update()
    {
      Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
      
      SpriteRenderer spriterenderer = GetComponent<SpriteRenderer>();

        rigidbody.velocity = new Vector2(move, rigidbody.velocity.y);
        if (colidde)
        {
            Flip();
        }
    }

    private void Flip()
    {
      move *= -1;
        spriterenderer.flipX = !spriterenderer.flipX;
        colidde = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Plataforma"))
        {
            colidde = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Plataforma"))
        {
           colidde = false;
        }
   }
}
