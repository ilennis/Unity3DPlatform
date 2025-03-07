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
        // ü���� ����
        // ���¹̳��� �����̸� �پ��. ������ ����.
        // ���ǵ�� �ִ�~�ּ� ����
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        speed.Speed(player.Speed());
    }
}
