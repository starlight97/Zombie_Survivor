using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBase : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rigidbody2D;
    protected Vector2 mDirection;   //ź�� ���ư� ����
    protected Vector3 SpawnPosition;    // �Ѿ��� ������ ���
    protected Vector2 Length;   //�Ѿ��� ���ƿ� �Ÿ� ���.

    [SerializeField] protected float fSpeed;     //ź�� �ӵ�
    [SerializeField] protected float fDamage;    //ź�� ������
    [SerializeField] protected float fRange;     //ź�� ��Ÿ�

    protected WaitForSeconds waitTime;

    protected virtual void Awake()
    {
        Initialize();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        SpawnPosition = this.transform.position;

        StartCoroutine(CorFuncRemoveThisBullet());
    }

    protected virtual void Initialize()
    {
        mDirection = new Vector2();
        Length = new Vector2();

        rigidbody2D = GetComponent<Rigidbody2D>();
        waitTime = new WaitForSeconds(0.1f);

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    protected virtual void FixedUpdate()
    {

    }

    /// <summary>
    /// �Ѿ��� �߻縦 �õ��޴� �Լ�
    /// </summary>
    public virtual void CallFire()
    {

    }
    /// <summary>
    /// �Ѿ��� �߻�� ���ÿ� �ʱ�ȭ�� �޴� �Լ�
    /// </summary>
    public virtual void CallFire(float speed, float damage, float range, Vector2 Direction)
    {
        //�ɹ� ���� �ʱ�ȭ
        fSpeed = speed;
        fDamage = damage;
        fRange = range;
        mDirection = Direction;

        //�ӵ� �ʱ�ȭ
        mDirection *= fSpeed;
        rigidbody2D.velocity = mDirection;


    }

    /// <summary>
    /// ���������� �Ѿ��� �߻�Ǵ� �Լ�.
    /// </summary>
    protected virtual void DoFire()
    {
        //�̵� ����
        rigidbody2D.velocity = mDirection;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

        //������ ������ �ο�
        Debug.Log("dddddddd : " + collision);

        //�ǰ��� ���� �ش� ������Ʈ ��Ȱ��ȭ Ȥ�� �ı� Ȥ�� ������Ʈ Ǯ�� �ε�
        OnHit();

    }

    /// <summary>
    /// ���� �ǰ������� �ҷ������� �Լ�.
    /// </summary>
    protected virtual void OnHit()
    {
        BulletAfterEffect();

        Destroy(this.gameObject);
    }

    /// <summary>
    /// ź�� ���� �ǰ��� �ڿ� �� �ļ� ȿ��.
    /// �Ѿ� -> ������ �ο� , ��ź -> ���ĵ�..
    /// ��ӹ��� ���� class���� ����.
    /// </summary>
    protected virtual void BulletAfterEffect()
    {
        
    }

    /// <summary>
    /// �̵��� �Ÿ��� ���� �ش� ������Ʈ�� ����� �Լ�
    /// </summary>
    protected virtual void RemoveThisBulelt()
    {
        Length = SpawnPosition - this.transform.position;

        if (Length.magnitude > fRange)
        {
            OnHit();
        }

    }

    protected virtual IEnumerator CorFuncRemoveThisBullet()
    {
        while(true)
        {
            RemoveThisBulelt();

            yield return waitTime;
        }
    }

}
