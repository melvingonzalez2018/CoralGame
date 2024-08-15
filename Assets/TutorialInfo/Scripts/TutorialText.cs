using UnityEngine;
using System.Collections;
using TMPro; 

public class TutorialText : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]TMP_Text text; 
    [SerializeField] string stringToEdit;
     
    void Start(){
 
    rb = GetComponent<Rigidbody>();
    }  
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
        // Make a text field that modifies stringToEdit.
        text.text = stringToEdit;
        }
    }
}