using System;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
 
    GameObject nodePrefab;
    Transform parentObj; // node prefab을 붙일 부모 오브젝트의 트랜스폼
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
    /// Button(확인)을 누를 경우
    /// 1. input 데이터를 받아오기
    /// 2. create, delete, search, print ? 
    /// 3. 각 함수 실행
    /// </summary>
    /// 
    public void ClickOK(int index)
    {
        data = inputField.text;
        if(index == 0) { //삽입
            list.Insert(data);
        }
        else if(index == 1) {  //삭제
            list.Delete(data);
        }
        else if(index == 2) { //인덱스로 삭제
            data2 = inputFieldForIndex.text;
            num = int.Parse(data2);
            list.DeleteIndex(num);       
        }
        else if(index == 3) { //전체 삭제
            list.DeleteAll();
        }
        else if(index == 4) { //탐색
            if (list.Search(x => x == data) != null)
            {
                printText.text = data + "가 존재합니다!";
                observePanel.SetActive(true);
            }
            else
            {
                printText.text = data + "가 존재하지 않습니다!";
                observePanel.SetActive(true);
            }
        }
        else if(index == 5) { //출력
            printText.text = list.PrintIndex();
            observePanel.SetActive(true);
        }

        RefreshNodes();
    }

    //노드 재배치
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

    //Button(Observe 패널의 확인)을 누를 경우
    public void ClickOK2()
    {
        observePanel.SetActive(false);
    }

}
