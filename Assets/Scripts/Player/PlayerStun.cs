using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStun : MonoBehaviour {
    [SerializeField] Renderer render;
    [SerializeField] Animator anim;
    [SerializeField] Color stunColor;
    public UnityEvent OnLoseOxygen = new UnityEvent();
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
    }

    public bool IsStunned() {
        return timer > 0;
    }
    public void StunPlayer(float duration) {
        render.material.color = stunColor;
        timer = duration;
        anim.SetTrigger("Hurt");
    }
    public void ReduceOxygen(float amount) {
        oxygen.ReduceOxygen(amount);
        anim.SetTrigger("Hurt");
        OnLoseOxygen.Invoke();
    }
}
