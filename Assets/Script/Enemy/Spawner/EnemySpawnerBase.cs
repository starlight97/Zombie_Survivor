using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBase : MonoBehaviour
{

    //스포너의 On Off 를 구별할 bool 변수
    [SerializeField] protected bool bTurnOn;

    //스포너에 들어갈 좀비 리스트
    [SerializeField] protected List<EnemyAIBase> EnemyList;
    //우선 테스트용으로 사용하는 단일 EnemyAIBase를 가진 EnemyObject...
    [SerializeField] protected EnemyAIBase EnemyObject;
    //좀비를 스폰시키고 가지고 있을 Stack.
    [SerializeField] protected Stack<EnemyAIBase> ObjectStorage;
    protected EnemyAIBase tmpObj;
    //스폰 간격
    [SerializeField] protected float fInterval;
    protected WaitForSeconds WaitTime;

    //테스트 코드
    public GameObject TestPlayer;
    public DropItemObjectPool DropItemPool;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    protected void Initialize()
    {
#if UNITY_EDITOR
        if (EnemyList == null)
            Debug.LogError("ENEMY LIST IS NULL!!");
#endif
        WaitTime = new WaitForSeconds(fInterval);
        ObjectStorage = new Stack<EnemyAIBase>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region ObjectPool

    private void GenerateObject()
    {
        tmpObj = Instantiate(EnemyObject);
        tmpObj.transform.position = this.transform.position;
        tmpObj.GetParrent(this);
        tmpObj.gameObject.SetActive(false);
        ObjectStorage.Push(tmpObj);
    }
    private void UseObject(int Amount = 1)
    {
        ReAllocateObject(Amount);
        for (int i = 0; i < Amount; i++)
        {
            tmpObj = ObjectStorage.Pop();
            tmpObj.GetParrent(this);
            tmpObj.gameObject.SetActive(true);
            //TestCode
            tmpObj.playerTransform = TestPlayer.transform;
            tmpObj.GetComponent<EnemyBodyBase>().ObjectPool = DropItemPool;
        }

    }
    private void ReAllocateObject(int Amount)
    {
        for (int i = 0; i < Amount; i++)
        {
            if (ObjectStorage.Count < Amount)
            {
                GenerateObject();
            }
        }
    }

    public void Push(EnemyAIBase getObj)
    {
        ObjectStorage.Push(getObj);
        //getObj.gameObject.SetActive(false);
    }




    #endregion

    /// <summary>
    /// 플레이어가 지정된 범위에 접근했을시.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SpawnerTurnOn();
            StartCoroutine(SpawnerProcess());
        }
    }
    /// <summary>
    /// 플레이어가 지정된 범위에서 나갔을시.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SpawnerTurnOff();
            StopCoroutine(SpawnerProcess());
        }

    }

    private void SpawnerTurnOn()
    {
        bTurnOn = true;
    }
    private void SpawnerTurnOff()
    {
        bTurnOn = false;
    }

    /// <summary>
    /// 활성화 된다면 실행되는...
    /// </summary>
    /// <returns></returns>
    protected IEnumerator SpawnerProcess()
    {
        //정지 전까지 무한 실행...
        while (true)
        {
            UseObject();

            yield return WaitTime;

        }
    }

}
