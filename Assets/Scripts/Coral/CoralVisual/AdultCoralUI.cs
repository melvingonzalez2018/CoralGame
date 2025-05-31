using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdultCoralUI : CoralUI
{
    [SerializeField] AdultCoral owner;
    protected override bool IconCondition() {
        return owner.GetFragmentAvailable();
    }
}
