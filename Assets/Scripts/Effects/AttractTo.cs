using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class AttractTo : MonoBehaviour
{
    [SerializeField] float destoryDist = 0.1f;
    [SerializeField] float acceleration = 3f;
    [SerializeField] float initalSpeed = 0f;
    public UnityEvent OnCompleteEffect = new UnityEvent();

    GameObject player;
    bool canAttract = false;
    float speed = 0f;

    public void Activate(UnityAction completeAction = null) {
        canAttract = true;
        speed = initalSpeed;
        player = FindAnyObjectByType<PlayerMovementController>().gameObject;

        if (completeAction != null) {
            OnCompleteEffect.AddListener(completeAction);
        }
    }

    // Update is called once per frame
    void Update() {
        if (canAttract) {
            Vector3 differentToPlayer = player.transform.position - transform.position;
            speed += acceleration * Time.deltaTime;
            transform.position += differentToPlayer.normalized * speed * Time.deltaTime;

            // Scaling and destroying itself
            if (differentToPlayer.magnitude < destoryDist) {
                canAttract = false;
                OnCompleteEffect.Invoke();
            }
        }
    }
}
