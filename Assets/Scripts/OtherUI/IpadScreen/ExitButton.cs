using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExitButton : MonoBehaviour
{
    EventSystem eventSystem;
    
    // Start is called before the first frame update
    void Start() {
        eventSystem = EventSystem.current;
    }

    public void SelectNoButton() {
        eventSystem.SetSelectedGameObject(null);
    }
}
