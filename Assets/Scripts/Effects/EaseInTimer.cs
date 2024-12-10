using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaseInTimer
{
    float timer = 0;
    float maxTime = 0;


    public void TimeUpdate(float deltaTime) {
        timer += deltaTime;
    }
}
