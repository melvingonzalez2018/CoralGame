using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralPutDownTarget : MonoBehaviour
{
    CoralPlaceableArea area;
    public void SetArea(CoralPlaceableArea area) {
        this.area = area;
    }
    public CoralPlaceableArea GetArea() {
        return area;
    }
}
