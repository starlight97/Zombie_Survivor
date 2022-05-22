using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �� AI�� ���� Base Class
/// �÷��̾��� ��ġ�� �ӵ��� ���� ������ ������ �־�� �Ѵ�.
/// </summary>
public class EnemyAIBase : MonoBehaviour
{
    //�ӽ÷� ����� �÷��̾� Ʈ������.
    public Transform playerTransform;
    protected float Speed;
    protected Vector3 moveVec;
    protected Vector3 NormalVec;

    protected float AttackRadius;
    protected float ModifiedAttackRadius;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        moveVec = new Vector3();
        NormalVec = new Vector3();
    }

    public virtual void SetUp(float getSpeed, float getAttackRadius)
    {
        Speed = getSpeed;
        AttackRadius = getAttackRadius;
        ModifiedAttackRadius = AttackRadius / 2;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Movement();
    }

    protected virtual void FixedUpdate()
    {

    }

    protected virtual void Movement()
    {
        moveVec = playerTransform.position - this.transform.position;
        NormalVec = moveVec.normalized;
        NormalVec *= Speed;
        NormalVec *= Time.deltaTime;

        if (ModifiedAttackRadius < moveVec.magnitude)
        {
            this.transform.position += NormalVec;
        }

    }
}
