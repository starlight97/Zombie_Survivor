using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �� �ٵ� ���� ���̽��Դϴ�.
/// �̰������� ���� ü��, 
/// </summary>
//[RequireComponent(typeof(EnemyBodyDataBase))]
public class EnemyBodyBase : MonoBehaviour
{
    //���� ������
    [SerializeField] protected EnemyBodyDataBase bodydata;
    [SerializeField] protected EnemyAIBase EnemyAI;
    [SerializeField] protected EnemyAttackBase EnemyAttack;
    //�� ���ϸ��̼� ��ũ��Ʈ.
    [SerializeField] protected EnemyAnimationBase EnemyAnimation;

    //�� ����ġ ������Ʈ Ǯ
    [SerializeField] public DropItemObjectPool ObjectPool;

    [SerializeField] protected HealthBar healthBar;

    [SerializeField] protected int MaxHealth;   //�ִ� ä��.
    protected int CurrentHealth;                //���� ä��.
    protected bool isAlive;

    protected IEnumerator corDotDamage; //�������� ��Ʈ�������� �ֱ� ���� corDotDamage...
    [Tooltip("DotDamage�� ����Ǵ� �� ������ ���͹� ���Դϴ�.")]
    [SerializeField] protected float fDotWaitTime;
    protected WaitForSeconds DotWaitTime;
    protected IEnumerator corSpeededit;
    protected IEnumerator corMaxhealthReduction;

    //�ִ� ä�� �������� ����� ����
    protected int circulateDamage;

    //�ӽú���
    public float TestFloat;
    //�ӽú���

    protected virtual void Awake()
    {
        Initialize();
    }

    /// <summary>
    /// �ʱ�ȭ�� �Լ�.
    /// </summary>
    protected virtual void Initialize()
    {
        //ä�� �ʱ�ȭ
        MaxHealth = bodydata.MAXHEALTH;
        CurrentHealth = MaxHealth;
        isAlive = true;

        //�ӵ� ����
        EnemyAI.SetUp(bodydata.SPEED, bodydata.RADIUS);
        EnemyAttack.SetUp(bodydata.DAMAGE, bodydata.RADIUS, bodydata.COOLTIME);
        DotWaitTime = new WaitForSeconds(fDotWaitTime);
        if (EnemyAnimation == null) //�� ���ϸ��̼� ��ũ��Ʈ�� �޷����� ������ ��� �õ�.
        {
            EnemyAnimation = GetComponent<EnemyAnimationBase>();
#if UNITY_EDITOR
            Debug.LogError("This Object has not EnemyAnimationBase\nTry Get Component...");
#endif
        }
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetDotDamaged(10, 3, 10);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetDotDamaged(10, 3, 10,0.1f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetSpeedEditEffect(0.5f, 3);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GetMaxHealthPerDamage(TestFloat);
        }
    }
    protected virtual void FixedUpdate()
    {

    }

    /// <summary>
    /// �ش� ������Ʈ�� Ÿ�ݽÿ� �θ� �Լ�.
    /// Damage�� �����Ѵ�.
    /// </summary>
    /// <param name="Damage"></param>
    public virtual void GetDamaged(int Damage)
    {
        if (isAlive)
        {
            if (0 < CurrentHealth - Damage)
            {
                CurrentHealth -= Damage;
            }
            else
            {
                CurrentHealth = 0;
                isAlive = false;
                Debug.Log("Dead!!");
                DeadThisUnit();
            }

            //�ｺ�� ������Ʈ.
            UpdateHealthBar();
        }
    }

    /// <summary>
    /// �ǰݽ� ������, Ÿ�Ը� ����.
    /// </summary>
    /// <param name="Damage"></param>
    /// <param name="Type"></param>
    public virtual void GetDamaged(int Damage, Debuff Type)
    {
        //�⺻ �ǰ� ������...
        GetDamaged(Damage);



    }

    /// <summary>
    /// �ǰݽ� ������, Ÿ��, ��Ʈ�������� ����.
    /// </summary>
    /// <param name="Damage"></param>
    /// <param name="Type"></param>
    /// <param name="DotDamage"></param>
    public virtual void GetDamaged(int Damage, Debuff Type, int DotDamage, int HoldTime )
    {
        //�⺻ �ǰ� ������ ����...
        GetDamaged(Damage);

        //DotDamage�Ͻ�.
        //DotDamage �ο� �ǽ�..
        switch (Type)
        {
            case Debuff.Normal:
                break;
            case Debuff.Slow:
                break;
            case Debuff.MaxHealthDown:
                break;

                //���ӵ�����
            case Debuff.DotDamage:
                if (corDotDamage != null)
                {
                    StopCoroutine(corDotDamage);
                }
                corDotDamage = CorFuncDotDamage(DotDamage, HoldTime);
                StartCoroutine(corDotDamage);
                break;
            default:
                break;
        }

    }
    public virtual void GetDamaged(int Damage, Debuff Type, int DotDamage, int HoldTime, float Interval)
    {
        //�⺻ �ǰ� ������ ����...
        GetDamaged(Damage);
        //DotDamage�Ͻ�.
        //DotDamage �ο� �ǽ�..
        switch (Type)
        {
            case Debuff.Normal:
                break;
            case Debuff.Slow:
                break;
            case Debuff.MaxHealthDown:
                break;

            //���ӵ�����
            case Debuff.DotDamage:
                if (corDotDamage != null)
                {
                    StopCoroutine(corDotDamage);
                }
                corDotDamage = CorFuncDotDamage(DotDamage, HoldTime, Interval);
                StartCoroutine(corDotDamage);
                break;
            default:
                break;
        }

    }

    //��Ʈ������ ����
    /// <summary>
    /// ��Ʈ �������� �ο��� �� ����ϴ� �Լ��̴�.
    /// Damage�� �ǰݽÿ� ��� ������� ����ȴ�.
    /// DotDamage�� ��Ʈ �������̴�.
    /// HoldCyle�� ������ ȸ���̴�. �⺻ ������ ȸ���� 1�ʴ�.
    /// Interval�� �� ȸ���� �ð� ������ ���̴� �κ��̴�.
    /// </summary>
    /// <param name="Damage"></param>
    /// <param name="DotDamage"></param>
    /// <param name="HoldCycle"></param>
    /// <param name="Interval"></param>
    public virtual void GetDotDamaged(int Damage, int DotDamage, int HoldCycle, float Interval = 1f)
    {
        GetDamaged(Damage);             //��� ������ ����.
        if (corDotDamage != null)
        {
            StopCoroutine(corDotDamage);
        }
        if (Mathf.Approximately(Interval, 1f))  //�⺻���� Interval�� ������ 1f���� �ƴ� �ٸ� ���� ������ ���..
            corDotDamage = CorFuncDotDamage(DotDamage, HoldCycle);  //1f �ϰ��
        else
            corDotDamage = CorFuncDotDamage(DotDamage, HoldCycle, Interval);    //1f�� �ƴҰ��
        StartCoroutine(corDotDamage);   //����.
    }

    //���ο� ����
    /// <summary>
    /// Slow Effect.
    /// per�� ������ �ӵ��� ������ ���Դϴ�.
    /// HoldTime�� ������ �ð��Դϴ�. int�� ����ؼ� �� ������ ���մϴ�.
    /// </summary>
    /// <param name="per"></param>
    /// <param name="HoldTime"></param>
    public virtual void GetSpeedEditEffect(float per, int HoldTime)
    {
        if (corSpeededit != null)
            StopCoroutine(corSpeededit);
        corSpeededit = CorFuncSpeedEdit(per, HoldTime);
        StartCoroutine(corSpeededit);

    }
    protected IEnumerator CorFuncSpeedEdit(float per,int HoldTime)
    {
        //�ӵ� ���� ����
        EnemyAI.ModifydeSpeed(per);
        EnemyAttack.ModifydeAttackCooltime(per);
        for (int i = 0; i < HoldTime; i++)
        {
            yield return DotWaitTime;
        }
        //�ӵ� ���� �ǵ�����.
        EnemyAI.UndoSpeed();
        EnemyAttack.UndoAttackCooltime();
    }

    //�ִ� ü�� ��� ������
    /// <summary>
    /// �ִ� ü�� ��� ������.
    /// </summary>
    /// <param name="per"></param>
    public virtual void GetMaxHealthPerDamage(float per)
    {
        circulateDamage = (int)((float)MaxHealth * per);
        GetDamaged(circulateDamage);
    }

    //�ִ� ä�� ���� ����
    /// <summary>
    /// �ִ� ä���� per��ŭ ���Ͽ� �ִ� ä���� ���̴� �Լ� �Դϴ�.
    /// Holdtime�� ������ �ð��Դϴ�. int�� ����Ͽ� �� ������ ���մϴ�.
    /// </summary>
    /// <param name="per"></param>
    /// <param name="HoldTime"></param>
    public virtual void GetMaxhealthReduction(float per, int HoldTime)
    {
        if (corMaxhealthReduction != null)
            StopCoroutine(corMaxhealthReduction);
        corMaxhealthReduction = CorFuncMaxhealthReduction(per, HoldTime);
        StartCoroutine(corMaxhealthReduction);
    }
    protected IEnumerator CorFuncMaxhealthReduction(float per, int HoldTime)
    {
        //ä�� ���� ����
        for (int i = 0; i < HoldTime; i++)
        {
            yield return DotWaitTime;
        }
        //ä�� ���� �ǵ�����.
    }

    /// <summary>
    /// �������� ��Ʈ�������� �ش� ������Ʈ���� �ֱ� ���� �κ�.
    /// </summary>
    /// <param name="Damage"></param>
    /// <returns></returns>
    protected virtual IEnumerator CorFuncDotDamage(int DotDamage, int HoldTime)
    {
        //HoldTime ��ŭ �ݺ�.
        //���ο� ȿ���� ���� �� �ʱ�ȭ�� �� ���� ���� ȿ���� ����ȴ�...
        for (int i = 0; i < HoldTime; i++)
        {
            //������ ����
            GetDamaged(DotDamage);
            //�޽�
            yield return DotWaitTime;
        }
    }
    protected virtual IEnumerator CorFuncDotDamage(int DotDamage, int HoldTime, float Interval)
    {
        WaitForSeconds tmpWait = new WaitForSeconds(Interval);
        //HoldTime ��ŭ �ݺ�.
        //���ο� ȿ���� ���� �� �ʱ�ȭ�� �� ���� ���� ȿ���� ����ȴ�...
        for (int i = 0; i < HoldTime; i++)
        {
            //������ ����
            GetDamaged(DotDamage);
            //�޽�
            yield return tmpWait;
        }
    }


    /// <summary>
    /// Ÿ ������Ʈ���� �ش� ������Ʈ�� ������ ������
    /// �޾ư��� ���� �Լ�
    /// </summary>
    /// <returns></returns>
    public virtual int AnotherGetDamage()
    {
        return bodydata.DAMAGE;
    }


    /// <summary>
    /// ä�¹� ������Ʈ
    /// </summary>
    public void UpdateHealthBar()
    {
        healthBar.EditBar(MaxHealth, CurrentHealth);
    }

    public void ResetHealth()
    {
        isAlive = true;
        CurrentHealth = MaxHealth;
        UpdateHealthBar();
    }

    protected virtual void DeadThisUnit()
    {
        DropLoot();

        EnemyAnimation.SetStateDead();

        //��Ȱ��ȭ ������Ʈ Ǯ���ÿ� �ش� Ǯ�� ����
        ObjectPool.CallFunc_DropEXP(this.transform, 1);
        EnemyAI.RetrunStackThis();
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// ����ǰ�� ����ϴ� �Լ�.
    /// ���� �غ�� ����ǰ ������Ʈ Ǯ���� �غ�� 
    /// ������Ʈ�� ���� ����ϵ��� �Ѵ�.
    /// </summary>
    protected virtual void DropLoot()
    {
        Debug.Log("DROP LOOT!");
    }

}
