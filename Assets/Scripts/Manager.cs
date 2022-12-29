using System;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
 
    GameObject nodePrefab;
    Transform parentObj; // node prefab�� ���� �θ� ������Ʈ�� Ʈ������
    Text inputField;
    Text inputFieldForIndex;
    GameObject observePanel;
    Text printText;
    LinkedList<string> list;
    string data="";
    string data2 = "";
    int num = 0;



    private void Awake()
    {
        nodePrefab = Resources.Load<GameObject>("nodePrefab");
        parentObj = GameObject.FindGameObjectWithTag("Content").transform;
        inputField= GameObject.FindGameObjectWithTag("InputField").GetComponentInChildren<Text>();
        inputFieldForIndex = GameObject.FindGameObjectWithTag("inputFieldForIndex").GetComponentInChildren<Text>();  
        observePanel = GameObject.Find("Main").transform.Find("ObservePanel").gameObject;
        printText = observePanel.GetComponentInChildren<Text>();     
        list= new LinkedList<string>();    
    }

    /// <summary>
    /// Button(Ȯ��)�� ���� ���
    /// 1. input �����͸� �޾ƿ���
    /// 2. create, delete, search, print ? 
    /// 3. �� �Լ� ����
    /// </summary>
    /// 
    public void ClickOK(int index)
    {
        data = inputField.text;
        if(index == 0) { //����
            list.Insert(data);
        }
        else if(index == 1) {  //����
            list.Delete(data);
        }
        else if(index == 2) { //�ε����� ����
            data2 = inputFieldForIndex.text;
            num = int.Parse(data2);
            list.DeleteIndex(num);       
        }
        else if(index == 3) { //��ü ����
            list.DeleteAll();
        }
        else if(index == 4) { //Ž��
            if (list.Search(x => x == data) != null)
            {
                printText.text = data + "�� �����մϴ�!";
                observePanel.SetActive(true);
            }
            else
            {
                printText.text = data + "�� �������� �ʽ��ϴ�!";
                observePanel.SetActive(true);
            }
        }
        else if(index == 5) { //���
            printText.text = list.PrintIndex();
            observePanel.SetActive(true);
        }

        RefreshNodes();
    }

    //��� ���ġ
    public void RefreshNodes()
    {
        for(int i=0; i< parentObj.childCount; i++)
        {
            Destroy(parentObj.GetChild(i).gameObject);      
        }
        int numOfChild = list.Count();       
        for (int i = 0; i < numOfChild; i++)
        {
            GameObject obj = Instantiate(nodePrefab, parentObj);
            string str = list.SearchIndex(i).ToString();
            Text temp = obj.GetComponentInChildren<Text>();
            temp.text = str;
        }
    }

    //Button(Observe �г��� Ȯ��)�� ���� ���
    public void ClickOK2()
    {
        observePanel.SetActive(false);
    }

}
