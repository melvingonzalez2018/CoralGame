using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStun : MonoBehaviour {
    float timer = 0;

    private void Update() {
        if(IsStunned()) {
            timer -= Time.deltaTime;
        }
    }

    public bool IsStunned() {
        return timer > 0;
    }
    public void StunPlayer(float duration) {
        timer = duration;
    }
}
