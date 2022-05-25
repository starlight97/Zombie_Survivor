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
    }

    public void SetStateMove()
    {
        SetStateDefualt();
        animator.SetBool("Move", false);
    }

    public void SetStateAttack()
    {
        SetStateDefualt();
        animator.SetTrigger("Attack");
        animator.SetBool("Attack", true);
    }

    public void SetStateDead()
    {
        SetStateDefualt();
        animator.SetTrigger("Dead");
    }

    public void SetStateDefualt()
    {
        animator.SetBool("Move", false);
        animator.SetBool("Attack", false);
        animator.ResetTrigger("AttackTrg");
        animator.SetBool("Dead", false);

    }

}
