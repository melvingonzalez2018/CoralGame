using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public struct StoredCoralData {
    public int modelIndex;

    public StoredCoralData(int modelIndex) {
        this.modelIndex = modelIndex;
    }
}



public class CoralStorage : MonoBehaviour {
    [SerializeField] GameObject juvenilePutDown;
    [SerializeField] GameObject fragmentPutDown;
    [SerializeField] GameObject coralTarget;
    public Queue<StoredCoralData> fragmentCoral = new Queue<StoredCoralData>();
    public UnityEvent OnGainFragment = new UnityEvent();
    public UnityEvent OnUseFragment = new UnityEvent();
    public Queue<StoredCoralData> juvenileCoral = new Queue<StoredCoralData>();
    public UnityEvent OnGainJuvenile = new UnityEvent();
    public UnityEvent OnUseJuvenile = new UnityEvent();

    GameObject player;

    private void Start() {
        player = FindObjectOfType<PlayerMovementController>().gameObject;
    }

    public void AddJuvenile(StoredCoralData coralData) {
        OnGainJuvenile.Invoke();
        juvenileCoral.Enqueue(coralData);
    }

    public void AddFragment(StoredCoralData coralData) {
        OnGainFragment.Invoke();
        fragmentCoral.Enqueue(coralData);
    }

    public int GetFragmentCount() {
        return fragmentCoral.Count;
    }

    public int GetJuvenileCount() {
        return juvenileCoral.Count;
    }

    // Trying to place an object in 
    public bool TryPlaceCoral(CoralPlaceableArea area, Vector3 pos) {
        // Checking position
        if (!area.PositionWithinBounds(pos)) {
            return false;
        }
        if(!area.CanPlaceCoral()) {
            return false;
        }

        switch (area.areaType) {
            case AreaType.REEF:
                if (GetJuvenileCount() > 0) {
                    StoredCoralData coralData = juvenileCoral.Dequeue();

                    // Setting up putdown pickup
                    GameObject coralPickupInstance = Instantiate(juvenilePutDown, player.transform.position, player.transform.rotation);

                    // Initalizing and positioning target
                    area.FindClosestPoint(pos, out RaycastHit hit);
                    GameObject coralPutDownTarget = Instantiate(coralTarget, pos, Quaternion.identity);
                    coralPutDownTarget.GetComponent<CoralPutDownTarget>().SetArea(area);
                    coralPutDownTarget.transform.up = hit.normal;

                    // Initalizing Pickup
                    CoralPutDown pickup = coralPickupInstance.GetComponent<CoralPutDown>();
                    pickup.InitalizeCoral(coralData.modelIndex);
                    pickup.AttractToPlacement(coralData.modelIndex, coralPutDownTarget);

                    area.AddCoralCount();

                    // Event Trigger
                    OnUseJuvenile.Invoke();
                    return true;
                }
                break;
            case AreaType.NURSERY:
                if (GetFragmentCount() > 0) {
                    StoredCoralData coralData = fragmentCoral.Dequeue();

                    // Setting up putdown pickup
                    GameObject coralPickupInstance = Instantiate(fragmentPutDown, player.transform.position, player.transform.rotation);

                    // Initalizing and positioning target
                    area.FindClosestPoint(pos, out RaycastHit hit);
                    GameObject coralPutDownTarget = Instantiate(coralTarget, pos, Quaternion.identity);
                    coralPutDownTarget.GetComponent<CoralPutDownTarget>().SetArea(area);
                    coralPutDownTarget.transform.up = hit.normal;
                    

                    // Initalizing Pickup
                    CoralPutDown pickup = coralPickupInstance.GetComponent<CoralPutDown>();
                    pickup.InitalizeCoral(coralData.modelIndex);
                    pickup.AttractToPlacement(coralData.modelIndex, coralPutDownTarget);
                    
                    area.AddCoralCount();

                    // Event Trigger
                    OnUseFragment.Invoke();
                    return true;
                }
                break;
        }
        return false;
    }
}
