using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;


public class UpgradeDisplay : MonoBehaviour {
    [SerializeField] float duration;
    [SerializeField] float distance;
    [SerializeField] TMP_Text text;
    float timer;


    private void Start() {
        timer = duration;
    }

    private void Update() {

        // Lifetime
        timer -= Time.deltaTime;
        if (timer <= 0) {
            Destroy(gameObject);
        }

        // Effect
        text.color = new Color(text.color.r, text.color.g, text.color.b, timer / duration);
        gameObject.transform.position += transform.up * distance;
    }
}
