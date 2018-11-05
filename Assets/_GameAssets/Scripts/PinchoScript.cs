using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchoScript : MonoBehaviour {
    [SerializeField] int fuerza = 100;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Player") {
            //collision.gameObject.GetComponent<Player>().modificarVidas(false);
            collision.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-fuerza, fuerza));
        }
    }
}
