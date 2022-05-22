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
    

    private float inputX;
    private float inputY;

    private float h;
    private float v;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        PlayerRotation();
    }

    private void FixedUpdate()
    {        
        Move();
    }

    private void Move()
    {
        Vector2 moveVec = new Vector2(h, v);
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

    private void GetInput()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }

    private void PlayerRotation()
    {
        // 좌측 회전
        if (h == 1)
        {
            spriteRenderer.sprite = spriteList.left;
            //transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        // 우측 회전
        else if (h == -1)
        {
            spriteRenderer.sprite = spriteList.right;
            //transform.localEulerAngles = new Vector3(0, 0, -180);
        }

        // 상단 회전
        if (v == 1)
        {
            spriteRenderer.sprite = spriteList.top;
            //transform.localEulerAngles = new Vector3(0, 0, 90);
        }
        // 하단 회전
        else if (v == -1)
        {
            spriteRenderer.sprite = spriteList.bottom;
            //transform.localEulerAngles = new Vector3(0, 0, -90);
        }

        // 좌상단 회전
        if (h == -1 && v == 1)
        {
            spriteRenderer.sprite = spriteList.leftTop;
            //transform.localEulerAngles = new Vector3(0, 0, 135);
        }
        // 우상단 회전
        else if (h == 1 && v == 1)
        {
            spriteRenderer.sprite = spriteList.rightTop;
            //transform.localEulerAngles = new Vector3(0, 0, 45);
        }
        // 좌하단 회전
        else if (h == -1 && v == -1)
        {
            spriteRenderer.sprite = spriteList.leftbottom;
            //transform.localEulerAngles = new Vector3(0, 0, -135);
        }
        // 우하단 회전
        else if (h == 1 && v == -1)
        {
            spriteRenderer.sprite = spriteList.rightBottom;
            //transform.localEulerAngles = new Vector3(0, 0, -45);
        }

    }
}
