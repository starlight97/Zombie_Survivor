using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private PlayerCarSpriteTemplate spriteList;

    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxSpeed;

    private float horizontal;
    private float vertical;

    public float Horizontal
    {
        set => horizontal = value;
    }
    public float Vertical
    {
        set => vertical = value;
    }


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRotation();
    }

    private void FixedUpdate()
    {        
        Move();
    }

    private void Move()
    {
        Vector2 moveVec = new Vector2(horizontal, vertical);
        rigidbody.AddForce(moveVec * speed);

        //최대 속도 제한
        moveVec = rigidbody.velocity;

        if (rigidbody.velocity.x > maxSpeed)
            moveVec.x = maxSpeed;
        else if (rigidbody.velocity.x < (maxSpeed * -1f))
            moveVec.x = maxSpeed * -1f;

        if (rigidbody.velocity.y > maxSpeed)
            moveVec.y = maxSpeed;
        else if (rigidbody.velocity.y < (maxSpeed * -1f))
            moveVec.y = maxSpeed * -1f;

        //실질적 적용
        rigidbody.velocity = moveVec;
    }

    private void PlayerRotation()
    {
        // 좌측 회전
        if (horizontal == 1)
        {
            spriteRenderer.sprite = spriteList.left;
        }
        // 우측 회전
        else if (horizontal == -1)
        {
            spriteRenderer.sprite = spriteList.right;
        }

        // 상단 회전
        if (vertical == 1)
        {
            spriteRenderer.sprite = spriteList.top;
        }
        // 하단 회전
        else if (vertical == -1)
        {
            spriteRenderer.sprite = spriteList.bottom;
        }

        // 좌상단 회전
        if (horizontal == -1 && vertical == 1)
        {
            spriteRenderer.sprite = spriteList.leftTop;
        }
        // 우상단 회전
        else if (horizontal == 1 && vertical == 1)
        {
            spriteRenderer.sprite = spriteList.rightTop;
        }
        // 좌하단 회전
        else if (horizontal == -1 && vertical == -1)
        {
            spriteRenderer.sprite = spriteList.leftbottom;
        }
        // 우하단 회전
        else if (horizontal == 1 && vertical == -1)
        {
            spriteRenderer.sprite = spriteList.rightBottom;
        }

    }
}
