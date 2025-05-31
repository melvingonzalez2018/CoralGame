using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class AttractTo : MonoBehaviour {
    [Header("Universal Variables")]
    float destoryDist = 0.1f;
    GameObject target;
    bool canAttract = false;
    public UnityEvent OnCompleteEffect = new UnityEvent();

    [Header("Acceleration")]
    [SerializeField] float acceleration = 3f;
    [SerializeField] float initalSpeed = 0f;
    float speed = 0f;

    [Header("Time Based")]
    [SerializeField] float maxTime = 1f;
    Vector3 initalPos = Vector3.zero;
    float timer = 0;

    public void Activate(GameObject target, UnityAction completeAction = null) {
        this.target = target;
        canAttract = true;

        TimeBasedStart();

        if (completeAction != null) {
            OnCompleteEffect.AddListener(completeAction);
        }
    }

    // Update is called once per frame
    void Update() {
        if (canAttract) {
            if (TimeBasedUpdate()) {
                canAttract = false;
                OnCompleteEffect.Invoke();
            }
        }
    }

    private void AccelerationStart() {
        // Acceleartion Based
        speed = initalSpeed;
    }
    private void AccelerationBasedUpdate() {
        Vector3 differentToTarget = target.transform.position - transform.position;
        speed += acceleration * Time.deltaTime;
        transform.position += differentToTarget.normalized * speed * Time.deltaTime;
    }

    private void TimeBasedStart() {
        // Time Based
        timer = 0f;
        initalPos = transform.position;
    }

    private bool TimeBasedUpdate() {
        // Time Based
        timer += Time.deltaTime;
        float percentMaxTime = timer / maxTime;
        transform.position = Vector3.LerpUnclamped(initalPos, target.transform.position, EaseInExpo(Mathf.Min(timer / maxTime, 1)));
        transform.rotation = Quaternion.LerpUnclamped(transform.rotation, target.transform.rotation, EaseInExpo(Mathf.Min(timer / maxTime, 1)));

        return percentMaxTime >= 1f;
    }

    public float OverShootIn(float x) {
        float c1 = 1.70158f;
        float c3 = c1 + 1f;

        return c3 * x * x * x - c1 * x * x;
    }

    public float EaseInExpo(float x) {
        return x == 0 ? 0 : Mathf.Pow(2, 10 * x - 10);
    }
}
