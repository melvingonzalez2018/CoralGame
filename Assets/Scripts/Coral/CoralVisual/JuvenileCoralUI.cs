using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuvenileCoralUI : CoralUI {
    [SerializeField] JuvenileCoral owner;
    protected override bool IconCondition() {
        return owner.OnReefAndHammerable();
    }
}
