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
        //�÷��̾� ������ �ӵ� ����
        //rigidbody.velocity = playerMove;
        rigidbody.AddForce(playerMove);
        //�ִ� �ӵ� ����
        playerMove = rigidbody.velocity;

        if(rigidbody.velocity.x > playerMaxSpeed)
            playerMove.x = playerMaxSpeed;
        else if(rigidbody.velocity.x < (playerMaxSpeed * -1f ) )
            playerMove.x = playerMaxSpeed * -1f;

        if (rigidbody.velocity.y > playerMaxSpeed)
            playerMove.y = playerMaxSpeed;
        else if (rigidbody.velocity.y < (playerMaxSpeed * -1f))
            playerMove.y = playerMaxSpeed * -1f;

        //������ ����
        rigidbody.velocity = playerMove;



        //�÷��̾��� ���� ��ġ�� ����
        playerNowPos = this.transform.position;
        //�÷��̾��� ��ġ�� ������� ȸ�� ���
        playerNowPos -= playerBeforePos;

        if ((playerAxis.x > 0.5f || playerAxis.x < -0.5f) || (playerAxis.y > 0.5f || playerAxis.y < -0.5f))
        {

            //�÷��̾��� ȸ���� ���
            playerRotation = Quaternion.LookRotation(playerNowPos.normalized);
            if (playerAxis.x > 0.01f)
                playerRotation.z = playerRotation.x * -1f;
            else
                playerRotation.z = playerRotation.x;
            playerRotation.x = 0f;
            playerRotation.y = 0f;
            this.transform.rotation = playerRotation;

        }


        //�÷��̾� ���� ��ġ�� ����.
        playerBeforePos = this.transform.position;


    }

}
