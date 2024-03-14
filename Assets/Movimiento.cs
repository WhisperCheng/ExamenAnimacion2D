using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Rigidbody2D cuerpo;
    SpriteRenderer spriteRenderer;
    bool tocando;
    Animator animator;
    bool animacionPrincipio;
    float temporizadorPrincipio;
    bool disparando;
    public Transform cañon;
    public GameObject bala;
    GameObject balaClon;
    AudioSource FX;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cuerpo = GetComponent<Rigidbody2D>();
        FX = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animacionPrincipio = true;
    }

    // Update is called once per frame
    void Update()
    {
        temporizadorPrincipio += Time.deltaTime;

        float movH = Input.GetAxis("Horizontal");

        Vector2 velocidad = new Vector2 (movH * 2, cuerpo.velocity.y);
        cuerpo.velocity = velocidad;

        if (movH < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movH > 0)
        {
            spriteRenderer.flipX = false;
        }

        if (tocando == true && Input.GetButtonDown("Jump"))
        {
            cuerpo.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            FX.Play();
            tocando = false;
        }

        if (temporizadorPrincipio >= 1)
        {
            animacionPrincipio = false;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            disparando = true;
            balaClon = Instantiate(bala, cañon.position, Quaternion.identity);
            balaClon.GetComponent<Rigidbody2D>().AddForce(transform.right * 5, ForceMode2D.Impulse);
        }
        else
        { 
            disparando = false; 
        }
        animator.SetFloat("movimiento", velocidad.x);
        animator.SetBool("principio", animacionPrincipio);
        animator.SetBool("saltando", !tocando);
        animator.SetBool("disparando", disparando);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            tocando = true;
        }
    }
}
