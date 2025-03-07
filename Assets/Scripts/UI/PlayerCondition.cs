using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;
    public PlayerController player;

    Condition health { get { return uiCondition.health; } }
    Condition stamina { get { return uiCondition.stamina; } }
    Condition speed { get { return uiCondition.speed; } }
    
    void Update()
    {
        // 체력은 일정
        // 스태미나는 움직이면 줄어듬. 원래는 증가.
        // 스피드는 최대~최소 사이
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        speed.Speed(player.Speed());
    }
}
