using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �� ���Ÿ� ���� ������Ʈ ( ź���� ���� )
/// </summary>
public class EnemyLangeObj : MonoBehaviour
{

    [SerializeField] protected float fSpeed;    //�� ź�� ���ư� �ӵ�.
    [SerializeField] protected float OnAbleTime;//�� ������Ʈ�� Ȱ��ȭ �Ǿ����� �ð�.
    [SerializeField] protected int objDamage;   //�� ź�� ������.
    [SerializeField] protected Rigidbody2D rigidbody;   //�������� ���� �ÿ� ���� �Ҵ��Ͽ�����.

    protected Vector3 tmpVec3;

    // Start is called before the first frame update
    void Start()
    {
        tmpVec3 = new Vector3();
#if UNITY_EDITOR
        if (rigidbody == null)
            Debug.LogError("Rigidbody is NULL!!");

#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �� ������Ʈ�� ���ÿ� �ʱ�ȭ�� �Ͽ� ���.
    /// </summary>
    /// <param name="mSpeed"></param>
    /// <param name="mDamage"></param>
    public void SetUp(float mSpeed, float mLifeTime, int mDamage)
    {
        fSpeed = mSpeed;
        OnAbleTime = mLifeTime;
        objDamage = mDamage;
    }

    
    /// <summary>
    /// �� ������Ʈ�� �߻��� ��.
    /// </summary>
    public void OnFire(Vector3 getPosition)
    {
        //���ư�.
        tmpVec3 = getPosition - this.transform.position;
        tmpVec3 = tmpVec3.normalized * fSpeed;
        rigidbody.velocity = tmpVec3;

        StartCoroutine(CorFuncDestroySelf());
    }

    //�ش� ������Ʈ�� ������ �����ϱ� ���� �ڷ�ƾ.
    protected IEnumerator CorFuncDestroySelf()
    {
        yield return new WaitForSeconds(OnAbleTime);

        DestroyThisObj();
    }

    /// <summary>
    /// �ش� ������Ʈ�� �ı�.
    /// </summary>
    protected void DestroyThisObj()
    {
        Destroy(this.gameObject);
    }

    /// <summary>
    /// �÷��̾�� Trigger �浹��
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Enemy Lange Attack Hit!!");
            StopAllCoroutines();
            DestroyThisObj();
        }
    }

}
