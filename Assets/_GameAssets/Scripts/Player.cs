using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    [SerializeField] int numVidas = 1;
    [SerializeField] int vidasMaximas = 3;
    [SerializeField] int puntuacion = 0;
    [SerializeField] Text txtPuntos;
    [SerializeField] Text txtVidas;
    [SerializeField] int fuerzaSalto = 1;
    [SerializeField] Transform posicionPies;
    Animator playerAnimator;
    Rigidbody2D rb;
    float speed = 10;
    bool saltando = false;


    void Start() {
        rb = this.GetComponent<Rigidbody2D>();
        txtPuntos.text = "Puntuación: " + puntuacion.ToString();
        txtVidas.text = "Vidas: " + numVidas.ToString();
        playerAnimator = this.GetComponent<Animator>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            saltando = true;
        }
    }

    private void FixedUpdate() {
        float xPos = Input.GetAxis("Horizontal");
        if (Mathf.Abs(xPos) > 0.01f) {
            playerAnimator.SetBool("andando", true);
        }else{
            playerAnimator.SetBool("andando", false);
        }

        if (xPos > 0f) {
            this.transform.localScale = new Vector2(1,1);
        }
        if (xPos < 0f) {
            this.transform.localScale = new Vector2(-1, 1);
        }
        float ySpeedActual = rb.velocity.y;

        if (saltando && EstaEnSuelo()) {
            rb.velocity = new Vector2(xPos * speed, fuerzaSalto);
            saltando = false;
        } else {
            rb.velocity = new Vector2(xPos * speed, ySpeedActual);
        }


    }


    public void aumentarPuntacion() {
        puntuacion++;
        txtPuntos.text = "Puntuación: " + puntuacion.ToString();


    }

    public void modificarVidas(bool aumentar) {

        if (numVidas <= vidasMaximas && numVidas > 0) {
            numVidas = (aumentar) ? numVidas + 1 : numVidas - 1;
        }
        if (numVidas == 0) {
            Morir();
        }
        if (numVidas >= vidasMaximas) {
            numVidas = vidasMaximas;
        }
        txtVidas.text = "Vidas: " + numVidas.ToString();

    }

    public void Morir() {
        SceneManager.LoadScene(1);
    }

    private bool EstaEnSuelo() {
        bool enSuelo = false;
        float radio = 0.1f;
        Collider2D col = Physics2D.OverlapCircle(posicionPies.position, radio);
        print("antes del if: " + col.gameObject.name);

        if (col != null && !col.gameObject.tag.Equals("Player")) {
            print(col.gameObject.name);
            enSuelo = true;
        }

        return enSuelo;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        print("Player: " + collision.gameObject.name);
    }
}
