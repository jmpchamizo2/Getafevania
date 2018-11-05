using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoscaScript : MonoBehaviour {
    bool haciaDerecha = false;
    int velocidad = 1;
    [SerializeField] Transform limiteDerecho;
    [SerializeField] Transform limiteIzquierdo;

    private void Start() {
        transform.position = limiteDerecho.position;
    }

    void Update() {
        if (haciaDerecha) {
            this.transform.Translate(Vector2.right * Time.deltaTime * 1);
            if (transform.position.x > limiteDerecho.position.x) {
                haciaDerecha = false;
                CambiarOrientacion();
            }
        } else {
            this.transform.Translate(Vector2.left * Time.deltaTime * 1);
            if (transform.position.x < limiteIzquierdo.position.x) {
                haciaDerecha = true;
                CambiarOrientacion();
            }
        }
    }

    void CambiarOrientacion() {
        int cambio = (haciaDerecha) ?-1 : 1;
        this.transform.localScale = new Vector2(cambio, 1);
    }

    private void OnTriggerEnter(Collider other) {
        print("****************************************mosca" + other.gameObject.name);
        if (other.gameObject.name == "Player") {
            print("if mosca" + other.gameObject.name);
            other.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(100, 100));
            other.GetComponent<Player>().modificarVidas(false);
        }
    }
}
