using UnityEngine;
using UnityEngine.UI;


public class Manager : MonoBehaviour
{
    [Header("-----------------Node-------------------")]
    public GameObject nodePrefab;
    public Transform parentObj; // node prefab을 붙일 부모 오브젝트의 트랜스폼


    [Header("--------------InputField----------------")]
    [SerializeField] private InputField createInputField;
    [SerializeField] private InputField deleteInputField;
    [SerializeField] private InputField searchInputField;


    [Header("--------각 버튼 클릭 시 팝업 되는 창--------")]
     public GameObject clickCreate;
     public GameObject clickDelete;
     public GameObject clickSearch;
     public GameObject clickPrint;

    [Header("-------------팝업 창의 확인 버튼--------------")]
    public GameObject clickCreateOK;
    public GameObject clickDeleteOK;
    public GameObject clickSearchOK;
    public GameObject clickPrintOK;

    [Header("-------------확인 버튼 누른 후 팝업 창--------------")]
    public GameObject clickCreate1;
    public GameObject clickDelete1;
    public GameObject clickSearch1;

    [Header("--------확인 버튼 누른 후 팝업 창의 확인 버튼--------")]
    public GameObject clickCreateOK1;
    public GameObject clickDeleteOK1;
    public GameObject clickSearchOK1;


    [Header("--------확인 버튼 누른 후 팝업 창의 텍스트 ---------")]
    public Text printText;
    public Text deleteText;
    public Text createText;
    public Text searchText;



    //Linked List -> 직렬화 불가능
    public static LinkedList list;

    private void Awake()
    {
        list = new LinkedList();
    }
    

    //창을 닫기 위해 x 버튼을 누를 경우
    public void clickX()
    {
        clickCreate.SetActive(false);
        clickDelete.SetActive(false);
        clickSearch.SetActive(false);
        clickPrint.SetActive(false);
    }

    //팝업창 닫기
    public void clickPanelX()
    {
        clickCreate1.SetActive(false);
        clickDelete1.SetActive(false);
        clickSearch1.SetActive(false);
    }


    /// <summary>
    /// 각 버튼(Create, Delete, Search, Print)를 누를 경우, 인풋 필드가 있는 '팝업 창'이 나오도록 하기
    /// </summary>
    #region
    //Create Button을 누를 경우
    public void clickCreateButton()
    {
        clickCreate.SetActive(true);
    }
    //Delete Button을 누를 경우
    public void clickDeleteButton()
    {
        clickDelete.SetActive(true);
    }
    //Search Button을 누를 경우
    public void clickSearchButton()
    {
        clickSearch.SetActive(true);
    }
    //Print Button을 누를 경우
    public void clickPrintButton()
    {
        clickPrint.SetActive(true);
    }
    #endregion

    /// <summary>
    /// 각 인풋 필드에 값을 입력 후 팝업 창을 닫고 작업 실행하기
    /// </summary>
    #region
    //Create 하고 확인Button을 누를 경우
    public void clickCreateOKButton()
    {
        string newData = createInputField.text;
        if(newData == null)
        {
            createText.text = newData + "입력되지 않았습니다!!!";
            return;
        }
        //링크드 리스트에 추가하기
        list.InsertNode(newData);
        //노드 생성하기
        GameObject obj =  Instantiate(nodePrefab, parentObj);
        //입력받은 텍스트를 노드의 텍스트에 작성
        Text newText = obj.GetComponentInChildren<Text>();
        newText.text = newData;
        createText.text = newData+" 입력을 성공했습니다!(^3^)";
        Debug.Log(newData + "가 입력되었습니다! ");
        //인풋필드 초기화
        createInputField.text = "";
        clickCreate.SetActive(false);
        clickCreate1.SetActive(true);
        list.Print();
        printText.text = LinkedList.forPrintText;

    }

    //Delete 하고 확인Button을 누를 경우
    public void clickDeleteOKButton()
    {
        string newData = deleteInputField.text;
        //링크드 리스트에서 삭제하기
        list.DeleteNode(newData);
        //노드 제거하기
        int numOfChild = parentObj.childCount;
        for(int i=0; i<numOfChild; i++)
        {
            if(parentObj.GetChild(i).gameObject.transform.GetComponentInChildren<Text>().text == newData)
            {
                Destroy(parentObj.GetChild(i).gameObject);
                break;
            }
        }
             
        clickDelete.SetActive(false);
        clickDelete1.SetActive(true);
        deleteText.text = LinkedList.forDeleteText;
        deleteInputField.text = "";
        list.Print();
        printText.text = LinkedList.forPrintText;

    }
    //Search 하고 확인Button을 누를 경우
    public void clickSearchOKButton()
    {
        string newData = searchInputField.text;
        list.SearchNode(newData);
        clickSearch.SetActive(false);
        clickSearch1.SetActive(true);
        searchText.text = LinkedList.forSearchText;
        searchInputField.text = "";
    }
    //Print 하고 확인Button을 누를 경우
    public void clickPrintOKButton()
    {
             
        clickPrint.SetActive(false);
    }
    #endregion

}
