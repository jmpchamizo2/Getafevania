using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortadaScript : MonoBehaviour {
    [SerializeField] RectTransform[] rt = new RectTransform[3];
    [SerializeField] RectTransform rtFondo;
    float velocidad = 100f;

    public void StartGame() {
        SceneManager.LoadScene(1);
    }


    private void Update() {
        float xPos;
        foreach (RectTransform r in rt) {
            xPos = 1 * Time.deltaTime * velocidad;
            if (r.position.x - (r.rect.width / 2) > rtFondo.rect.width) {
                xPos = 0 - r.rect.width - rtFondo.rect.width;
            }
            r.Translate(xPos, 0, 0);
        }
        
        
    }
}
