using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DevControls : MonoBehaviour
{
    [SerializeField] Animator ipad;
    CoralStorage storage;
    // Start is called before the first frame update
    void Start()
    {
        storage = FindAnyObjectByType<CoralStorage>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            ipad.SetTrigger("TransitionIn");
            storage.AddFragment(new StoredCoralData(0));
            storage.AddJuvenile(new StoredCoralData(0));
        }
    }
}
