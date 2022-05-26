using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBase : MonoBehaviour
{

    //�������� On Off �� ������ bool ����
    [SerializeField] protected bool bTurnOn;

    //�����ʿ� �� ���� ����Ʈ
    [SerializeField] protected List<EnemyAIBase> EnemyList;
    //�켱 �׽�Ʈ������ ����ϴ� ���� EnemyAIBase�� ���� EnemyObject...
    [SerializeField] protected EnemyAIBase EnemyObject;
    //���� ������Ű�� ������ ���� Stack.
    [SerializeField] protected Stack<EnemyAIBase> ObjectStorage;
    protected EnemyAIBase tmpObj;
    //���� ����
    [SerializeField] protected float fInterval;
    protected WaitForSeconds WaitTime;

    //�׽�Ʈ �ڵ�
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
    /// �÷��̾ ������ ������ ����������.
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
    /// �÷��̾ ������ �������� ��������.
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
    /// Ȱ��ȭ �ȴٸ� ����Ǵ�...
    /// </summary>
    /// <returns></returns>
    protected IEnumerator SpawnerProcess()
    {
        //���� ������ ���� ����...
        while (true)
        {
            UseObject();

            yield return WaitTime;

        }
    }

}
