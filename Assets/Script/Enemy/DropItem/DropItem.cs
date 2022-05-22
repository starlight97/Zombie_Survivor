using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    //초기에 설정해야 하는 값.
    [Tooltip("해당 오브젝트의 타입입니다.")]
    [SerializeField] protected DropType dropType;
    [Tooltip("해당 오브젝트의 양(Amount) 혹은 특징(ID)값 입니다.")]
    [SerializeField] protected int Amount;

    private DropItemObjectPool basePool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (dropType)
        {
            case DropType.Experience:
                break;
            case DropType.Money:
                break;
            case DropType.Skill:
                break;
            default:
                break;
        }

        PushThis();
    }

    public void SetUpEXP(int mAmount)
    {
        dropType = DropType.Experience;
        Amount = mAmount;
    }

    public void SetUpMoney(int mAmount)
    {
        dropType = DropType.Money;
        Amount = mAmount;
    }

    public void GetParrent(DropItemObjectPool getbasePool)
    {
        basePool = getbasePool;
    }

    /// <summary>
    /// 해당 오브젝트를 풀로 반환
    /// </summary>
    private void PushThis()
    {
        basePool.Push(this);
        this.gameObject.SetActive(false);
    }


}

public enum DropType
{
    Experience,
    Money,
    Skill
}