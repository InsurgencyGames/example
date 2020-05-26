using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour {
    private Rigidbody2D rb;
    private Animator an;

    public int vida;
    public float movementSpeed = 10f;
    public float jumpForce = 400f;
    public float maxVelocityX = 4f;

    private bool Grounded;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        vida = 5;
    }

    private void OnTriggerEnter2D(Collider2D other){
        PersistentManager.dataStore.gemCollected += 1;
        if (other.gameObject.CompareTag ("Coins")){
            Destroy(other.gameObject);
        }
    }

    void FixedUpdate() {
        var force = new Vector2(0f, 0f);

        //Controle da movimentacao horizontal
        float moveHorizontal = Input.GetAxis("Horizontal");

        var absVelocityX = Mathf.Abs(rb.velocity.x);
        var absVelocityY = Mathf.Abs(rb.velocity.y);

        this.grounded(absVelocityY);
        if (absVelocityX < maxVelocityX) {
            force.x = (movementSpeed * moveHorizontal);
        }

        if (this.Grounded == true && Input.GetButton("Jump")) {
            this.Grounded = false;
            force.y = jumpForce;
            an.SetInteger("AnimState", 2);
        }

        rb.AddForce(force);
        //Controle da movimentacao Vertical
        if (moveHorizontal > 0) {
            transform.localScale = new Vector3(1, 1, 1);
            if (this.Grounded) {
                an.SetInteger("AnimState", 1);
            }
        }
        else if (moveHorizontal < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
            if (this.Grounded) {
                an.SetInteger("AnimState", 1);
            }
        }
        else {
            if (this.Grounded) {
                an.SetInteger("AnimState", 0);
            }
        }
    }

    void grounded(float ySpeed) {
        this.Grounded = false;
        if (ySpeed == 0) {
            this.Grounded = true;
        }        
    }
}
