using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PufferFish : MonoBehaviour
{
    [SerializeField] float oxygenDamage; // The reduction in oxygen on collision
    [SerializeField] float stunDuration = 0.25f;
    [SerializeField] string playerTag;
    [SerializeField] float collisionCooldown;
    [SerializeField] List<AudioClip> clips;
    [SerializeField] AudioSource playerPop;
    [HideInInspector] public UnityEvent OnCollide = new UnityEvent();
    float collisionTimer = 0;
    PlayerStun playerStun;
    ScaleWobble puffEffect;
    SpeedEffect speedEffect;
    ParticleSystem bubbleEffect;

    private void Start() {
        playerStun = FindObjectOfType<PlayerStun>();
        puffEffect = GetComponent<ScaleWobble>();
        speedEffect = GetComponent<SpeedEffect>();
        bubbleEffect = GetComponentInChildren<ParticleSystem>();
    }
    private void Update() {
        collisionTimer = Mathf.Min(collisionTimer+Time.deltaTime, collisionCooldown);
    }
    public void ReduceOxygen() {
        if(playerStun != null && collisionTimer >= collisionCooldown) {
            FindObjectOfType<StatTracking>().IteratePufferCollision();
            PlayPop();
            playerStun.ReduceOxygen(oxygenDamage, transform.position, true);
            collisionTimer = 0f;
        }
    }

    private void PlayPop() {
        playerPop.Stop();
        playerPop.clip = clips[Mathf.FloorToInt(Random.value * clips.Count)];
        playerPop.Play();
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == playerTag) {
            ReduceOxygen();
            if (!puffEffect.EffectActive()) {
                puffEffect.ActivateWobble();
                bubbleEffect.Play();
            }
            if(!speedEffect.IsActive()) {
                speedEffect.ActivateEffect();
            }
        }
    }
}
