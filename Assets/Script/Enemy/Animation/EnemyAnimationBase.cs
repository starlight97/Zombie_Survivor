using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationBase : MonoBehaviour
{

    //����, �̵�, ���

    [SerializeField] protected Animator animator;

    //ID������ ó���ϴ°��� �ƴ� ��� �Ϲ� �� ���ϸ����Ϳ���
    //���������� ����� �� �ְ�.
    //Animator���� ����ϴ� ������ ��� �����Ѵ�.

    protected void Awake()
    {
        Initialize();
    }

    /// <summary>
    /// �ʱ�ȭ
    /// </summary>
    protected void Initialize()
    {
        //�ν����ͻ󿡼� ������� �ʾ��� ���
        if(animator == null)
            animator = GetComponent<Animator>();
        SetStateDefualt();
        SetStateMove();
    }

    public void SetStateMove()
    {
        SetStateDefualt();
        animator.SetBool("Move", true);
    }

    public void SetStateAttack()
    {
        //Debug.Log("Attack Animation ABLE");
        SetStateDefualt();
        animator.SetTrigger("AttackTrg");
        animator.SetBool("Attack", true);
    }

    public void SetStateDead()
    {
        SetStateDefualt();
        animator.SetBool("Dead", true);
    }

    /// <summary>
    /// ��� ���� �ʱ�ȭ.
    /// </summary>
    public void SetStateDefualt()
    {
        animator.SetBool("Move", false);
        animator.SetBool("Attack", false);
        animator.ResetTrigger("AttackTrg");
        animator.SetBool("Dead", false);

    }

}
