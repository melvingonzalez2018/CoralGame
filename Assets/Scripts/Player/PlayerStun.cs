using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStun : MonoBehaviour {
    [SerializeField] float invincibilityDuration = 0.5f;
    [SerializeField] Renderer render;
    [SerializeField] Animator anim;
    [SerializeField] Color stunColor;
    public UnityEvent OnLoseOxygen = new UnityEvent();
    float invincibilityTimer = 0;
    Color startColor;
    Oxygen oxygen;
    
    float timer = 0;

    private void Start() {
        startColor = render.material.color;
        oxygen = FindObjectOfType<Oxygen>();
    }

    private void Update() {
        if(IsStunned()) {
            timer -= Time.deltaTime;
            if(!IsStunned()) {
                render.material.color = startColor;
            }
        }
        invincibilityTimer = Mathf.Max(invincibilityTimer-Time.deltaTime, 0);
    }

    public bool IsStunned() {
        return timer > 0;
    }
    public bool CanDamageOxygen() {
        return invincibilityTimer <= 0;
    }

    public void StunPlayer(float duration) {
        if (!IsStunned()) {
            render.material.color = stunColor;
            timer = duration;
            anim.SetTrigger("Hurt");
        }
    }
    public void ReduceOxygen(float amount) {
        if (CanDamageOxygen()) {
            oxygen.ReduceOxygen(amount);
            invincibilityTimer = invincibilityDuration;
            anim.SetTrigger("Hurt");
            OnLoseOxygen.Invoke();
        }
    }
}
