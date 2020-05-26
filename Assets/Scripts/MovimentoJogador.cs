using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimentoJogador : MonoBehaviour
{
    public float forcaPulo;
    public float velocidadeMaxima;

    public int vida;
    public int gemas;

    public Text textLives;
    public Text textGemas;

    public bool isGrounded;

    void Start()
    {
        textLives.text = vida.ToString();
        textGemas.text = gemas.ToString();
    }

    void FixedUpdate()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        Animator anima = GetComponent<Animator>();

        SpriteRenderer spriterender = GetComponent<SpriteRenderer>();

        float movimento = Input.GetAxis("Horizontal");

        rigidbody.velocity = new Vector2(movimento * velocidadeMaxima, rigidbody.velocity.y);

        if (movimento < 0){
            spriterender.flipX = true;
        }else if (movimento > 0){
            spriterender.flipX = false;
        }

        if(movimento < 0 || movimento > 0){
            anima.SetBool("animacao", true);
        }else{
            anima.SetBool("animacao", false);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rigidbody.AddForce(new Vector2(0, forcaPulo));
            GetComponent<AudioSource>().Play();
        }

        if (isGrounded)
        {
            anima.SetBool("Pulo", false);
        }
        else{
            anima.SetBool("Pulo", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Coins"))
        {
            Destroy(collision2D.gameObject);
            gemas++;
            textGemas.text = gemas.ToString();
        }

        if(collision2D.gameObject.CompareTag("Checkpoint")){
            Debug.Log("Colidiu com " + collision2D.gameObject.name);
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Inimigos")){
            //logica
        }

        if (collision2D.gameObject.CompareTag("Plataforma")){
            isGrounded = true;
        }

    if(collision2D.gameObject.CompareTag("Trampolim")){
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f);
    }
    }

    void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Plataforma")){
            isGrounded = false;
        }
    }
    
}
