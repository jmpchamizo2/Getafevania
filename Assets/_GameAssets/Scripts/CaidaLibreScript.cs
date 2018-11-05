using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaLibreScript : MonoBehaviour {
    

    private void OnTriggerEnter2D(Collider2D collision) {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        if (collision.tag.Equals("Player")) {
            collision.GetComponent<Player>().modificarVidas(false);
            collision.GetComponent<Transform>().position = new Vector3(-6.3f, -1.43f, 0);
        }
    }
}
