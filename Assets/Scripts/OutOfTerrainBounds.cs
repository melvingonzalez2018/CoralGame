using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfTerrainBounds : MonoBehaviour
{
    [SerializeField] float terrainTileSize;

    // Checks and moves a transform looping bounds, only on the xz plane
    public void MoveCheckOutOfBounds(Transform checkTransform) {
        Vector3 compare = checkTransform.position;
        compare.y = 0;

        if(compare.magnitude > terrainTileSize) {
            checkTransform.position = new Vector3(-compare.x, checkTransform.position.y, -compare.z);
        }
    }
}
