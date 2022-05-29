using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 적 원거리 공격 오브젝트 ( 탄막의 개념 )
/// </summary>
public class EnemyLangeObj : MonoBehaviour
{

    [SerializeField] protected float fSpeed;    //이 탄이 날아갈 속도.
    [SerializeField] protected float OnAbleTime;//이 오브젝트가 활성화 되어있을 시간.
    [SerializeField] protected int objDamage;   //이 탄의 데미지.
    [SerializeField] protected Rigidbody2D rigidbody;   //프리팹을 만들 시에 값을 할당하여야함.

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
    /// 이 오브젝트를 사용시에 초기화를 하여 사용.
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
    /// 이 오브젝트를 발사할 시.
    /// </summary>
    public void OnFire(Vector3 getPosition)
    {
        //날아감.
        tmpVec3 = getPosition - this.transform.position;
        tmpVec3 = tmpVec3.normalized * fSpeed;
        rigidbody.velocity = tmpVec3;

        StartCoroutine(CorFuncDestroySelf());
    }

    //해당 오브젝트를 셀프로 제거하기 위한 코루틴.
    protected IEnumerator CorFuncDestroySelf()
    {
        yield return new WaitForSeconds(OnAbleTime);

        DestroyThisObj();
    }

    /// <summary>
    /// 해당 오브젝트를 파괴.
    /// </summary>
    protected void DestroyThisObj()
    {
        Destroy(this.gameObject);
    }

    /// <summary>
    /// 플레이어와 Trigger 충돌시
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
