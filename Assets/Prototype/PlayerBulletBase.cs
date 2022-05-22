using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBase : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rigidbody2D;
    protected Vector2 mDirection;   //탄이 날아갈 방향
    protected Vector3 SpawnPosition;    // 총알이 스폰된 장소
    protected Vector2 Length;   //총알이 날아온 거리 계산.

    [SerializeField] protected float fSpeed;     //탄의 속도
    [SerializeField] protected float fDamage;    //탄의 데미지
    [SerializeField] protected float fRange;     //탄의 사거리

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
    /// 총알의 발사를 시도받는 함수
    /// </summary>
    public virtual void CallFire()
    {

    }
    /// <summary>
    /// 총알의 발사와 동시에 초기화를 받는 함수
    /// </summary>
    public virtual void CallFire(float speed, float damage, float range, Vector2 Direction)
    {
        //맴버 변수 초기화
        fSpeed = speed;
        fDamage = damage;
        fRange = range;
        mDirection = Direction;

        //속도 초기화
        mDirection *= fSpeed;
        rigidbody2D.velocity = mDirection;


    }

    /// <summary>
    /// 실질적으로 총알이 발사되는 함수.
    /// </summary>
    protected virtual void DoFire()
    {
        //이동 적용
        rigidbody2D.velocity = mDirection;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

        //적에게 데미지 부여
        Debug.Log("dddddddd : " + collision);

        //피격을 통한 해당 오브젝트 비활성화 혹은 파괴 혹은 오브젝트 풀에 로드
        OnHit();

    }

    /// <summary>
    /// 적을 피격했을시 불러와지는 함수.
    /// </summary>
    protected virtual void OnHit()
    {
        BulletAfterEffect();

        Destroy(this.gameObject);
    }

    /// <summary>
    /// 탄이 적을 피격한 뒤에 줄 후속 효과.
    /// 총알 -> 데미지 부여 , 유탄 -> 폭파등..
    /// 상속받은 하위 class에서 구현.
    /// </summary>
    protected virtual void BulletAfterEffect()
    {
        
    }

    /// <summary>
    /// 이동한 거리에 따라 해당 오브젝트를 지우는 함수
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
