using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    protected float fHealth;    //���� ä��
    [SerializeField] protected float fMaxHealth;    //�ִ� ä��

    [SerializeField] protected HealthBar healthBar;

    private void Awake()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        fHealth = fMaxHealth;
        //Cost����. Inspector���� �ʱ�ȭ ���ִ� ��������.
        //healthBar = GetComponentInChildren<HealthBar>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �ش� ������Ʈ�� �ǰݽÿ� �ҷ��� �Լ�
    /// </summary>
    public void HitThisObjet(float Damage)
    {
        if (fHealth - Damage > 0f)
        {
            fHealth -= Damage;
        }
        else
        {
            fHealth = 0f;
            KilledTHisObj();
        }

        UpdateHealthBar();
    }

    /// <summary>
    /// ä�¹� ������Ʈ
    /// </summary>
    public void UpdateHealthBar()
    {
        healthBar.EditBar(fMaxHealth, fHealth);
    }

    /// <summary>
    /// �ش� ������Ʈ�� ��� ������ �޾����ÿ� �ҷ����� �Լ�.
    /// </summary>
    protected virtual void KilledTHisObj()
    {
        //������ ����ÿ� �ش� ������Ʈ�� ����⸸ ��.
        Destroy(this.gameObject);
    }

}
