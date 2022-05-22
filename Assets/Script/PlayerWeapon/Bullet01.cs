using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet01 : MonoBehaviour
{
    private GameObject exprosive;
    private MoveMent2D movement2D;
    private float damage;
    private Vector3 direction;

    private float currentTime = 0f;

    public void Setup( float damage, Vector3 direction)
    {
        movement2D = GetComponent<MoveMent2D>();
        exprosive = transform.GetChild(0).gameObject;
        this.damage = damage;                              // ���Ⱑ �������� ���ݷ�
        this.direction = direction;
    }

    private void Update()
    {
        // �߻�ü�� target�� ��ġ�� �̵�
        //Vector3 direction = (target.position - transform.position).normalized;
        movement2D.MoveTo(direction);

        currentTime += Time.deltaTime;
        if(currentTime > 5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            movement2D.MoveStop();
            exprosive.SetActive(true);
        }

        /*
        if (!collision.CompareTag("Enemy")) return; // ���� �ƴ� ���� �ε�����
        if (collision.transform != target) return;   // ���� target�� ���� �ƴ� ��
        collision.GetComponent<EnemyHP>().TakeDamage(damage);
        Destroy(gameObject);
        */
    }
}
