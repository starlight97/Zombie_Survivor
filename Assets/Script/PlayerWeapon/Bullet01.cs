using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet01 : MonoBehaviour
{
    private GameObject exprosive;   // �Ѿ� �ǰݽ� ����ó���� ���� ������Ʈ
    private MoveMent2D movement2D;
    private int damage;             // ���� ������
    private int exprosiveRange;     // ���� ����
    private Vector3 direction;      // �Ѿ��� ���ư� ����
    private WaitForSeconds waitExprosiveTime;   // �������� �ð�
    private CircleCollider2D exprosiveCircle;
    private CircleCollider2D bulletCircle;

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
        exprosive.SetActive(false);
        bulletCircle = GetComponent<CircleCollider2D>();
        this.damage = damage;                             // ���Ⱑ �������� ���ݷ�
        this.exprosiveRange = exprosiveRange;
        this.direction = direction;
        this.exprosive.transform.localScale = new Vector3(exprosiveRange, exprosiveRange, exprosiveRange);
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
            enemyBodyBase.GetDamaged(damage);
            StartCoroutine("ExprosiveAttack");
        }
    }

    /// <summary>
    /// ���� ���� �ڷ�ƾ
    /// </summary>
    private IEnumerator ExprosiveAttack()
    {
        movement2D.MoveStop();
        bulletCircle.radius = 0.5f * exprosiveRange;        
        exprosive.SetActive(true);
        yield return waitExprosiveTime;
        Destroy(this.gameObject);
    }
}
