using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuvenileCoral : Coral {
    [SerializeField] AudioSource takeAudio;
    [SerializeField] GameObject adultCoralPrefab;
    [SerializeField] public float hammerTime;
    [SerializeField] float hammerPerClick;
    [HideInInspector] public float hammerTimer = 0;

    public override void Interact() {
        if (area != null) {
            switch (area.areaType) {
                case AreaType.NURSERY:
                    PickUp();
                    break;
                case AreaType.REEF:
                    HammerUpdate();
                    break;
                case AreaType.NULL:
                    PickUp();
                    break;
            }
        }
    }

    public override void DiveStartUpdate() {
        if(IsOnReef() && IsHammeredIn()) {
            FindObjectOfType<StatTracking>().IterateCoralGrown();

            GameObject currentCoral = Instantiate(adultCoralPrefab);
            currentCoral.GetComponent<Coral>().InitalizeOnArea(area, transform.position); // Setting area
            area.MinusCoralCount();
            Destroy(gameObject);
        }
    }

    private void HammerUpdate() {
        if (!IsHammeredIn()) {
            hammerTimer += hammerPerClick;
            if (IsHammeredIn()) {
                FindObjectOfType<StatTracking>().IterateCoralHammered();
            }
        }
    }

    public bool IsOnReef() {
        Debug.Assert(area != null);
        return area.areaType == AreaType.REEF;
    }

    public bool IsHammeredIn() {
        return hammerTimer >= hammerTime;
    }

    public void PickUp() {
        takeAudio.Play();
        FindObjectOfType<StatTracking>().IterateCoralPickup();
        FindAnyObjectByType<CoralStorage>().AddJuvenile();
        Destroy(gameObject);
    }
}
