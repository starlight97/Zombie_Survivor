using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet01 : MonoBehaviour
{
    private GameObject exprosive;
    private MoveMent2D movement2D;
    private int damage;
    private int exprosiveRange;      // 폭발 범위
    private Vector3 direction;
    private CircleCollider2D circleCollider;
    private WaitForSeconds waitExprosiveTime;

    private float currentTime = 0f;

    /// <summary>
    /// 총알 셋팅 함수
    /// Weapon01 무기의 총알
    /// </summary>
    public void Setup(int damage, int exprosiveRange, Vector3 direction, float exprosiveTime)
    {
        movement2D = GetComponent<MoveMent2D>();
        this.circleCollider = GetComponent<CircleCollider2D>();
        this.waitExprosiveTime = new WaitForSeconds(exprosiveTime);
        exprosive = transform.GetChild(0).gameObject;
        this.damage = damage;                              // 무기가 설정해준 공격력
        this.direction = direction;
        this.exprosiveRange = exprosiveRange;       // 폭발 범위
    }

    private void Update()
    {
        // 발사체를 포구의 방향으로 이동
        movement2D.MoveTo(direction);

        // 임시 5초후에 총알 삭제
        currentTime += Time.deltaTime;
        if(currentTime > 5f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            OnCollisionEnemy(collision);
        }            
    }

    /// <summary>
    /// 적 콜라이더에 총알이 닿았을시에 데미지가 적용되는 부분
    /// </summary>
    private void OnCollisionEnemy(Collider2D collision)
    {
        //공격이 적용되는 부분
        //공격의 데미지 적용
        EnemyBodyBase enemyBodyBase;
        circleCollider.radius = 1.5f;

        collision.gameObject.TryGetComponent<EnemyBodyBase>(out enemyBodyBase);
        if (enemyBodyBase != null)
        {
            movement2D.MoveStop();
            exprosive.SetActive(true);
            enemyBodyBase.GetDamaged(damage);
            StartCoroutine("ExprosiveTime");
        }
    }

    /// <summary>
    /// 폭발 코루틴
    /// </summary>
    private IEnumerator ExprosiveTime()
    {
        yield return waitExprosiveTime;
        Destroy(this.gameObject);
    }
}
