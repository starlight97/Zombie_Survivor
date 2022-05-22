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

        EnemyHealth enemyHealth;    //�� ü�� �ӽ�.
        collision.TryGetComponent<EnemyHealth>(out enemyHealth);  //�� ü�� ��ũ��Ʈ ��� �õ�.
        if (enemyHealth != null)    //������ ������ �ο�
            enemyHealth.HitThisObjet(fDamage);

        Destroy(this.gameObject);

        //����Ʈ ���

    }

}
