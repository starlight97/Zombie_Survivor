using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationBase : MonoBehaviour
{

    //공격, 이동, 사망

    [SerializeField] protected Animator animator;

    //ID값으로 처리하는것이 아닌 모든 일반 적 에니메이터에서
    //범용적으로 사용할 수 있게.
    //Animator에서 사용하는 변수도 모두 통일한다.

    protected void Awake()
    {
        Initialize();
    }

    /// <summary>
    /// 초기화
    /// </summary>
    protected void Initialize()
    {
        //인스팩터상에서 집어넣지 않았을 경우
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
    /// 모든 변수 초기화.
    /// </summary>
    public void SetStateDefualt()
    {
        animator.SetBool("Move", false);
        animator.SetBool("Attack", false);
        animator.ResetTrigger("AttackTrg");
        animator.SetBool("Dead", false);

    }

}
