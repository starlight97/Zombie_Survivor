using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private int currentHp;
    private SpriteRenderer spriteRenderer;
    private float hitDelay = 1f;
    private float currentTime = 0f;
    private bool isHit = false;

    public int CurrentHp
    {
        get => currentHp;
        set => currentHp = value;
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    private void Update()
    {
        if(isHit)
        {
            HitDelay();
        }        
    }
    public void TakeDamage(int damage)
    {
        if (!isHit)
        {
            isHit = true;
            currentHp = currentHp - damage;

            StopCoroutine("HitAlphaAnimation");
            StartCoroutine("HitAlphaAnimation");           
        }
    }

    private IEnumerator HitAlphaAnimation()
    {
        // 현재 플레이어의 색상을 color 변수에 저장
        Color color = spriteRenderer.color;

        // 플레이어의 투명도를 40%로 설정
        color.a = 0.4f;
        spriteRenderer.color = color;
        // 0.5f초 대기
        yield return new WaitForSeconds(0.5f);

        // 플레이어의 투명도를 100%로 설정
        color.a = 1.0f;
        spriteRenderer.color = color;
    }

    private void HitDelay()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= hitDelay)
        {
            isHit = false;
            currentTime = 0;
        }
    }

}
