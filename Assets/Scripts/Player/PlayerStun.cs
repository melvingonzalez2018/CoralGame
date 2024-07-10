using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStun : MonoBehaviour {
    [SerializeField] Renderer render;
    [SerializeField] Color stunColor;
    Color startColor;
    
    float timer = 0;

    private void Start() {
        startColor = render.material.color;
    }

    private void Update() {
        if(IsStunned()) {
            timer -= Time.deltaTime;
            if(!IsStunned()) {
                render.material.color = startColor;
            }
        }
    }

    public bool IsStunned() {
        return timer > 0;
    }
    public void StunPlayer(float duration) {
        render.material.color = stunColor;
        timer = duration;
    }
}
