using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet01 : MonoBehaviour
{
    private GameObject exprosive;   // �Ѿ� �ǰݽ� ����ó���� ���� ������Ʈ
    private MoveMent2D movement2D;
    private int damage;             // ���� ������
    private Vector3 direction;      // �Ѿ��� ���ư� ����
    private WaitForSeconds waitExprosiveTime;   // �������� �ð�

    private float currentTime = 0f;

    /// <summary>
    /// �Ѿ� ���� �Լ�
    /// Weapon01 ������ �Ѿ�
    /// </summary>
    public void Setup(int damage, int exprosiveRange, Vector3 direction, float exprosiveTime)
    {
        movement2D = GetComponent<MoveMent2D>();
        this.waitExprosiveTime = new WaitForSeconds(exprosiveTime);
        exprosive = transform.GetChild(0).gameObject;
        this.damage = damage;                              // ���Ⱑ �������� ���ݷ�
        this.direction = direction;
    }

    private void Update()
    {
        // �߻�ü�� ������ �������� �̵�
        movement2D.MoveTo(direction);

        // �ӽ� 5���Ŀ� �Ѿ� ����
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
    /// �� �ݶ��̴��� �Ѿ��� ������ÿ� �������� ����Ǵ� �κ�
    /// </summary>
    private void OnCollisionEnemy(Collider2D collision)
    {
        //������ ����Ǵ� �κ�
        //������ ������ ����
        EnemyBodyBase enemyBodyBase;

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
    /// ���� �ڷ�ƾ
    /// </summary>
    private IEnumerator ExprosiveTime()
    {
        yield return waitExprosiveTime;
        Destroy(this.gameObject);
    }
}
