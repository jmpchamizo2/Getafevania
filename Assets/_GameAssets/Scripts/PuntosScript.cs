using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Player")) {
            collision.GetComponent<Player>().aumentarPuntacion();
            Destroy(this.gameObject);
        }
    }
}
