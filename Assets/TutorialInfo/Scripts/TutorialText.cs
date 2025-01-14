using UnityEngine;
using System.Collections;
using TMPro; 

public class TutorialText : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]TMP_Text text; 
    [SerializeField] string stringToEdit;
    ScaleWobble scaleWobble;
     
    void Start(){
        scaleWobble = GetComponent<ScaleWobble>();
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player" && !scaleWobble.EffectActive()) {
            // Make a text field that modifies stringToEdit.
            text.text = stringToEdit;
            scaleWobble.ActivateWobble();
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        //if (collision.gameObject.tag == "Player")
        //{
        //// Make a text field that modifies stringToEdit.
        //text.text = stringToEdit;
        //}
    }
}