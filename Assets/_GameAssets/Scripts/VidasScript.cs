using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Player")) {
            collision.GetComponent<Player>().modificarVidas(true);
            Destroy(this.gameObject);
        }
    }
}
