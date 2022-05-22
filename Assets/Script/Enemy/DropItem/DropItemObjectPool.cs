using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemObjectPool : MonoBehaviour
{
    [SerializeField] private DropItem BaseItem;

    [SerializeField] private Stack<DropItem> ObjectStorage;  //������Ʈ â��
    [SerializeField] private List<DropItem> ObjectUseAble;

    [SerializeField] private int allocateCount;     //������Ʈ�� ���� ���� - �ʱ�����
    [SerializeField] private int ReAllocateCount;   //������Ʈ ��������� �����Ǵ� �⺻ ��.

    private DropItem tmpObj;

    private void Start()
    {
        Initialize();

    }

    private void Initialize()
    {
        ObjectStorage = new Stack<DropItem>();
        ObjectUseAble = new List<DropItem>();

        for (int i = 0; i < allocateCount; i++)
        {
            GenerateObject();
        }

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CallFunc_DropEXP(this.gameObject.transform, 1);
        }
    }

    private void GenerateObject()
    {
        tmpObj = Instantiate(BaseItem);
        tmpObj.transform.position = this.transform.position;
        tmpObj.GetParrent(this);
        tmpObj.gameObject.SetActive(false);
        ObjectStorage.Push(tmpObj);
    }

    private void UseObject(int Amount = 1)
    {
        for (int i = 0; i < Amount; i++)
        {
            if(ObjectStorage.Count < Amount)
            {
                ReAllocateObject();
            }
            ObjectUseAble.Add(ObjectStorage.Pop());
        }
    }

    private void ReAllocateObject()
    {
        if (ReAllocateCount < 1)
            ReAllocateCount = 1;
        for (int i = 0; i < ReAllocateCount; i++)
        {
            GenerateObject();
        }
    }

    public void Push(DropItem getObj)
    {
        ObjectStorage.Push(getObj);
    }

    public void CallFunc_DropEXP(Transform transform, int Amount)
    {
        UseObject();
        ObjectUseAble[0].gameObject.SetActive(true);
        ObjectUseAble[0].SetUpEXP(Amount);
        ObjectUseAble[0].transform.position = transform.position;
        ObjectUseAble.Clear();
        //SetUp
    }

    public void CallFunc_DropMoney(Transform transform, int Amount)
    {
        UseObject();
        ObjectUseAble[0].gameObject.SetActive(true);
        ObjectUseAble[0].SetUpMoney(Amount);
        ObjectUseAble[0].transform.position = transform.position;
        ObjectUseAble.Clear();
    }

}
