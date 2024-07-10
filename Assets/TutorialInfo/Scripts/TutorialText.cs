using UnityEngine;
using System.Collections;

public class TutorialText : MonoBehaviour
{
    Rigidbody rb;
    string stringToEdit; 
    void Start(){
 
    rb = GetComponent<Rigidbody>();
    }  
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
        // Make a text field that modifies stringToEdit.
        stringToEdit = GUI.TextField(new Rect(10, 10, 200, 20), stringToEdit, 25);
        }
    }
}