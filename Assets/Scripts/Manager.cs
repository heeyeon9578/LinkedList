using UnityEngine;
using UnityEngine.UI;


public class Manager : MonoBehaviour
{
    [Header("-----------------Node-------------------")]
    public GameObject nodePrefab;
    public Transform parentObj; // node prefab�� ���� �θ� ������Ʈ�� Ʈ������


    [Header("--------------InputField----------------")]
    [SerializeField] private InputField createInputField;
    [SerializeField] private InputField deleteInputField;
    [SerializeField] private InputField searchInputField;


    [Header("--------�� ��ư Ŭ�� �� �˾� �Ǵ� â--------")]
     public GameObject clickCreate;
     public GameObject clickDelete;
     public GameObject clickSearch;
     public GameObject clickPrint;

    [Header("-------------�˾� â�� Ȯ�� ��ư--------------")]
    public GameObject clickCreateOK;
    public GameObject clickDeleteOK;
    public GameObject clickSearchOK;
    public GameObject clickPrintOK;

    [Header("-------------Ȯ�� ��ư ���� �� �˾� â--------------")]
    public GameObject clickCreate1;
    public GameObject clickDelete1;
    public GameObject clickSearch1;

    [Header("--------Ȯ�� ��ư ���� �� �˾� â�� Ȯ�� ��ư--------")]
    public GameObject clickCreateOK1;
    public GameObject clickDeleteOK1;
    public GameObject clickSearchOK1;


    [Header("--------Ȯ�� ��ư ���� �� �˾� â�� �ؽ�Ʈ ---------")]
    public Text printText;
    public Text deleteText;
    public Text createText;
    public Text searchText;



    //Linked List -> ����ȭ �Ұ���
    public static LinkedList list;

    private void Awake()
    {
        list = new LinkedList();
    }
    

    //â�� �ݱ� ���� x ��ư�� ���� ���
    public void clickX()
    {
        clickCreate.SetActive(false);
        clickDelete.SetActive(false);
        clickSearch.SetActive(false);
        clickPrint.SetActive(false);
    }

    //�˾�â �ݱ�
    public void clickPanelX()
    {
        clickCreate1.SetActive(false);
        clickDelete1.SetActive(false);
        clickSearch1.SetActive(false);
    }


    /// <summary>
    /// �� ��ư(Create, Delete, Search, Print)�� ���� ���, ��ǲ �ʵ尡 �ִ� '�˾� â'�� �������� �ϱ�
    /// </summary>
    #region
    //Create Button�� ���� ���
    public void clickCreateButton()
    {
        clickCreate.SetActive(true);
    }
    //Delete Button�� ���� ���
    public void clickDeleteButton()
    {
        clickDelete.SetActive(true);
    }
    //Search Button�� ���� ���
    public void clickSearchButton()
    {
        clickSearch.SetActive(true);
    }
    //Print Button�� ���� ���
    public void clickPrintButton()
    {
        clickPrint.SetActive(true);
    }
    #endregion

    /// <summary>
    /// �� ��ǲ �ʵ忡 ���� �Է� �� �˾� â�� �ݰ� �۾� �����ϱ�
    /// </summary>
    #region
    //Create �ϰ� Ȯ��Button�� ���� ���
    public void clickCreateOKButton()
    {
        string newData = createInputField.text;
        if(newData == null)
        {
            createText.text = newData + "�Էµ��� �ʾҽ��ϴ�!!!";
            return;
        }
        //��ũ�� ����Ʈ�� �߰��ϱ�
        list.InsertNode(newData);
        //��� �����ϱ�
        GameObject obj =  Instantiate(nodePrefab, parentObj);
        //�Է¹��� �ؽ�Ʈ�� ����� �ؽ�Ʈ�� �ۼ�
        Text newText = obj.GetComponentInChildren<Text>();
        newText.text = newData;
        createText.text = newData+" �Է��� �����߽��ϴ�!(^3^)";
        Debug.Log(newData + "�� �ԷµǾ����ϴ�! ");
        //��ǲ�ʵ� �ʱ�ȭ
        createInputField.text = "";
        clickCreate.SetActive(false);
        clickCreate1.SetActive(true);
        list.Print();
        printText.text = LinkedList.forPrintText;

    }

    //Delete �ϰ� Ȯ��Button�� ���� ���
    public void clickDeleteOKButton()
    {
        string newData = deleteInputField.text;
        //��ũ�� ����Ʈ���� �����ϱ�
        list.DeleteNode(newData);
        //��� �����ϱ�
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
    //Search �ϰ� Ȯ��Button�� ���� ���
    public void clickSearchOKButton()
    {
        string newData = searchInputField.text;
        list.SearchNode(newData);
        clickSearch.SetActive(false);
        clickSearch1.SetActive(true);
        searchText.text = LinkedList.forSearchText;
        searchInputField.text = "";
    }
    //Print �ϰ� Ȯ��Button�� ���� ���
    public void clickPrintOKButton()
    {
             
        clickPrint.SetActive(false);
    }
    #endregion

}
