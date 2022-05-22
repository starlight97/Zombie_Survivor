using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Image FrontBar;
    [SerializeField] protected Image BackBar;

    [SerializeField] protected Vector2 CustomPosition;  //������Ʈ�� ������ ũ�⿡ �����ϱ� ���� Ŀ���� ������.

    protected RectTransform rectTransform;

    Vector3 BarChanger;
    float BarFloat;

    private void Awake()
    {
        FrontBar.rectTransform.localScale = Vector3.one;
        BackBar.rectTransform.localScale = Vector3.one;
        BarChanger = new Vector3(1f, 1f, 1f);

        rectTransform = GetComponent<RectTransform>();
        rectTransform.localPosition = CustomPosition;

    }

    /// <summary>
    /// HealthBar�� ������Ʈ ���ִ� �Լ�.
    /// </summary>
    /// <param name="MaxValue"></param>
    /// <param name="CurrentValue"></param>
    public void EditBar(float MaxValue, float CurrentValue)
    {
        //Debug.Log(MaxValue + " " + CurrentValue);

        BarFloat = (1f / (float)MaxValue) * (float)CurrentValue;
        BarChanger.x = BarFloat;
        FrontBar.rectTransform.localScale = BarChanger;

    }

}
