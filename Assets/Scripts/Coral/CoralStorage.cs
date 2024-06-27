using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralStorage : MonoBehaviour
{
    List<Coral> corals = new List<Coral>();
    public void AddCoral(Coral coral) {
        corals.Add(coral);
    }
}
