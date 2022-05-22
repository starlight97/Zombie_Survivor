using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Image FrontBar;
    [SerializeField] protected Image BackBar;

    [SerializeField] protected Vector2 CustomPosition;  //오브젝트별 상이한 크기에 대응하기 위한 커스텀 포지션.

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
    /// HealthBar를 업데이트 해주는 함수.
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
