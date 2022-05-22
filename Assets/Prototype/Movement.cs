using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    private Vector2 playerMove;
    private Vector2 playerAxis;
    private Vector2 playerBeforePos;
    private Vector2 playerNowPos;

    private Quaternion playerRotation;

    [SerializeField] float playerSpeed;
    [SerializeField] float playerMaxSpeed;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerMove = new Vector2();
        playerAxis = new Vector2();
        playerBeforePos = new Vector2();
        playerNowPos = new Vector2();

        playerRotation = new Quaternion();

        playerBeforePos = this.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GetInput();
    }

    private void FixedUpdate()
    {
        //PlayerMove();
    }

    private void GetInput()
    {
        playerAxis.x = Input.GetAxis("Horizontal");
        playerAxis.y = Input.GetAxis("Vertical");

        playerMove.x = Input.GetAxis("Horizontal") * playerSpeed;
        playerMove.y = Input.GetAxis("Vertical") * playerSpeed;
    }

    /// <summary>
    /// Run in FixedUpdate
    /// </summary>
    private void PlayerMove()
    {
        //플레이어 움직임 속도 관련
        //rigidbody.velocity = playerMove;
        rigidbody.AddForce(playerMove);
        //최대 속도 제한
        playerMove = rigidbody.velocity;

        if(rigidbody.velocity.x > playerMaxSpeed)
            playerMove.x = playerMaxSpeed;
        else if(rigidbody.velocity.x < (playerMaxSpeed * -1f ) )
            playerMove.x = playerMaxSpeed * -1f;

        if (rigidbody.velocity.y > playerMaxSpeed)
            playerMove.y = playerMaxSpeed;
        else if (rigidbody.velocity.y < (playerMaxSpeed * -1f))
            playerMove.y = playerMaxSpeed * -1f;

        //실질적 적용
        rigidbody.velocity = playerMove;



        //플레이어의 현제 위치를 저장
        playerNowPos = this.transform.position;
        //플레이어의 위치를 기반으로 회전 계산
        playerNowPos -= playerBeforePos;

        if ((playerAxis.x > 0.5f || playerAxis.x < -0.5f) || (playerAxis.y > 0.5f || playerAxis.y < -0.5f))
        {

            //플레이어의 회전을 담당
            playerRotation = Quaternion.LookRotation(playerNowPos.normalized);
            if (playerAxis.x > 0.01f)
                playerRotation.z = playerRotation.x * -1f;
            else
                playerRotation.z = playerRotation.x;
            playerRotation.x = 0f;
            playerRotation.y = 0f;
            this.transform.rotation = playerRotation;

        }


        //플레이어 이전 위치를 저장.
        playerBeforePos = this.transform.position;


    }

}
