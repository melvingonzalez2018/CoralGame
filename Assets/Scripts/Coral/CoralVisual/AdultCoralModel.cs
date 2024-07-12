using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdultCoralModel : MonoBehaviour
{
    [SerializeField] AdultCoral owner;
    [SerializeField] [Range(0f,1f)] float thinScale;
    Vector3 intialScale;
    
    // Start is called before the first frame update
    void Start() {
        intialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(owner.GetFragmentAvailable()) {
            transform.localScale = intialScale;
        }
        else {
            transform.localScale = new Vector3(intialScale.x * thinScale, intialScale.y, intialScale.z*thinScale);
        }
    }
}
