using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 적 AI에 대한 Base Class
/// 플레이어의 위치와 속도에 대한 정보를 가지고 있어야 한다.
/// </summary>
public class EnemyAIBase : MonoBehaviour
{
    //임시로 사용할 플레이어 트렌스폼.
    public Transform playerTransform;
    protected Rigidbody2D rigidbody;
    protected float Speed;          //디폴트로 지정된 스피드.
    protected float CurrentSpeed;   //현제 실질적으로 적용되는 속도.
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
        NormalVec *= CurrentSpeed;  //속도에 관련된 부분.
        NormalVec *= Time.deltaTime;

        if (ModifiedAttackRadius < moveVec.magnitude)
        {
            this.transform.position += NormalVec;
        }

    }
}
