using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{

    [SerializeField] protected Rigidbody2D rigidbody2D;
    [SerializeField] protected CircleCollider2D circleCollider2D;

    [SerializeField] protected float fDamage;
    [SerializeField] protected float fRadius;

    public void SetObject(float damage, float Radius, Transform mtransform)
    {
        fDamage = damage;
        fRadius = Radius;

        //circleCollider2D.radius = Radius;
        this.gameObject.transform.localScale = Vector3.one * Radius;
        this.gameObject.transform.position = mtransform.position;

        Destroy(this.gameObject, 1f);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {

        EnemyHealth enemyHealth;    //적 체력 임시.
        collision.TryGetComponent<EnemyHealth>(out enemyHealth);  //적 체력 스크립트 취득 시도.
        if (enemyHealth != null)    //성공시 데미지 부여
            enemyHealth.HitThisObjet(fDamage);

        Destroy(this.gameObject);

        //이펙트 출력

    }

}
