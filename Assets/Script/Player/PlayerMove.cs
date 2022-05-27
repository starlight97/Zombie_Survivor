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

        //�ִ� �ӵ� ����
        moveVec = rigidbody.velocity;

        if (rigidbody.velocity.x > maxSpeed)
            moveVec.x = maxSpeed;
        else if (rigidbody.velocity.x < (maxSpeed * -1f))
            moveVec.x = maxSpeed * -1f;

        if (rigidbody.velocity.y > maxSpeed)
            moveVec.y = maxSpeed;
        else if (rigidbody.velocity.y < (maxSpeed * -1f))
            moveVec.y = maxSpeed * -1f;

        //������ ����
        rigidbody.velocity = moveVec;
    }

    private void PlayerRotation()
    {
        // ���� ȸ��
        if (horizontal == 1)
        {
            spriteRenderer.sprite = spriteList.left;
        }
        // ���� ȸ��
        else if (horizontal == -1)
        {
            spriteRenderer.sprite = spriteList.right;
        }

        // ��� ȸ��
        if (vertical == 1)
        {
            spriteRenderer.sprite = spriteList.top;
        }
        // �ϴ� ȸ��
        else if (vertical == -1)
        {
            spriteRenderer.sprite = spriteList.bottom;
        }

        // �»�� ȸ��
        if (horizontal == -1 && vertical == 1)
        {
            spriteRenderer.sprite = spriteList.leftTop;
        }
        // ���� ȸ��
        else if (horizontal == 1 && vertical == 1)
        {
            spriteRenderer.sprite = spriteList.rightTop;
        }
        // ���ϴ� ȸ��
        else if (horizontal == -1 && vertical == -1)
        {
            spriteRenderer.sprite = spriteList.leftbottom;
        }
        // ���ϴ� ȸ��
        else if (horizontal == 1 && vertical == -1)
        {
            spriteRenderer.sprite = spriteList.rightBottom;
        }

    }
}
