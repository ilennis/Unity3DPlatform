using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float curValue;
    public float startValue;
    public float maxValue;
    public float passiveValue;
    public Image uiBar;
    // Start is called before the first frame update
    void Start()
    {
        curValue = startValue; // �� ����
    }

    // Update is called once per frame
    void Update()
    {
        uiBar.fillAmount = GetPercentage();
    }
    float GetPercentage()
    {
        return curValue / maxValue; // 0~1���̴� Bar Horizontal Fill �뵵�� ���
    }
    public void Add(float value)
    {
        curValue = Mathf.Min(curValue + value, 100);
    }
    public void Subtract(float value)
    {
        curValue = Mathf.Max(curValue - value, 0);
    }
    public void Speed(float value)
    {
        curValue = value;
    }
}
