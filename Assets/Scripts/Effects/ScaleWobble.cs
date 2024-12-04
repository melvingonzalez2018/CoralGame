using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ScaleWobble : MonoBehaviour
{
    [SerializeField] float scaleMag = 0.5f;
    [SerializeField] float duration = 1f;
    [SerializeField] float decay = 5f;
    public UnityEvent OnCompleteEffect = new UnityEvent();

    Vector3 initalScale;
    bool effectActive = false;
    float timer = 0f;

    private void Start() {
        initalScale = transform.localScale;
    }

    public void ActivateWobble(UnityAction onComplete = null) {
        timer = 0f;
        effectActive = true;

        if (onComplete != null) {
            OnCompleteEffect.AddListener(onComplete);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (effectActive) {
            // Timer + effective scale
            timer = Mathf.Min(duration, timer + Time.deltaTime);
            float calcScale = scaleMag * decaySinWave(timer / duration);
            transform.localScale = new Vector3(initalScale.x + scaleMag * -calcScale, initalScale.y + scaleMag * calcScale, initalScale.z + scaleMag * -calcScale);

            if(timer >= duration) {
                transform.localScale = initalScale;
                effectActive = false;
                OnCompleteEffect.Invoke();
                OnCompleteEffect.RemoveAllListeners();
            }
        }
    }

    // Decaying Ocilation between approx [-1,1]
    float decaySinWave(float t) {
        const float c4 = (2 * Mathf.PI) / 3;

        return t == 0 ? 0 :
            t == 1 ? 1 :
            Mathf.Pow(2, -decay * t) * Mathf.Sin((t* 10f) * c4);
    }
}
