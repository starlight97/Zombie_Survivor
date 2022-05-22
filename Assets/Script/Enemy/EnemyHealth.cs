using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    protected float fHealth;    //현제 채력
    [SerializeField] protected float fMaxHealth;    //최대 채력

    [SerializeField] protected HealthBar healthBar;

    private void Awake()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        fHealth = fMaxHealth;
        //Cost낭비. Inspector에서 초기화 해주는 방향으로.
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
    /// 해당 오브젝트가 피격시에 불려질 함수
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
    /// 채력바 업데이트
    /// </summary>
    public void UpdateHealthBar()
    {
        healthBar.EditBar(fMaxHealth, fHealth);
    }

    /// <summary>
    /// 해당 오브젝트가 사망 판정을 받았을시에 불려지는 함수.
    /// </summary>
    protected virtual void KilledTHisObj()
    {
        //현제는 사망시에 해당 오브젝트를 지우기만 함.
        Destroy(this.gameObject);
    }

}
