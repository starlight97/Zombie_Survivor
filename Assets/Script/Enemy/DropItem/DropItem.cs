using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    //�ʱ⿡ �����ؾ� �ϴ� ��.
    [Tooltip("�ش� ������Ʈ�� Ÿ���Դϴ�.")]
    [SerializeField] protected DropType dropType;
    [Tooltip("�ش� ������Ʈ�� ��(Amount) Ȥ�� Ư¡(ID)�� �Դϴ�.")]
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
    /// �ش� ������Ʈ�� Ǯ�� ��ȯ
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