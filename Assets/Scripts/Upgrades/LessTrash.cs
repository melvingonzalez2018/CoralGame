using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessTrash : Upgrade
{
    /// <summary>
    /// Randomly picking up trash based on the percentage set, rounded up
    /// </summary>

    [SerializeField] [Range(0f,1f)] float percentDecrease;
    public override void UpgradeTrigger() {
        Debug.Log("Trash upgrade");

        Trash[] trash = FindObjectsOfType<Trash>();
        int amount = Mathf.CeilToInt(trash.Length * percentDecrease);

        for(int i = 0; i < amount; i++) {
            trash = FindObjectsOfType<Trash>();
            trash[Mathf.FloorToInt(Random.value * trash.Length)].ContactPlayer(); // picking up random trash
        }
    }
}
