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
    protected Rigidbody2D rigidbody;
    protected float Speed;          //����Ʈ�� ������ ���ǵ�.
    protected float CurrentSpeed;   //���� ���������� ����Ǵ� �ӵ�.
    protected Vector3 moveVec;
    protected Vector3 NormalVec;

    protected Vector3 FrezeeVec;

    protected float AttackRadius;
    protected float ModifiedAttackRadius;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        moveVec = new Vector3();
        NormalVec = new Vector3();
        FrezeeVec = Vector3.zero;
    }

    public virtual void SetUp(float getSpeed, float getAttackRadius)
    {
        Speed = getSpeed;
        CurrentSpeed = Speed;
        AttackRadius = getAttackRadius;
        ModifiedAttackRadius = AttackRadius;// / 1.5f;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Movement();
    }

    protected virtual void FixedUpdate()
    {

    }

    public void ModifydeSpeed(float per)
    {
        CurrentSpeed = Speed * per;
    }

    public void UndoSpeed()
    {
        CurrentSpeed = Speed;
    }

    protected virtual void Movement()
    {
        rigidbody.velocity = FrezeeVec;

        moveVec = playerTransform.position - this.transform.position;
        NormalVec = moveVec.normalized;
        NormalVec *= CurrentSpeed;  //�ӵ��� ���õ� �κ�.
        NormalVec *= Time.deltaTime;

        if (ModifiedAttackRadius < moveVec.magnitude)
        {
            this.transform.position += NormalVec;
        }

    }
}
