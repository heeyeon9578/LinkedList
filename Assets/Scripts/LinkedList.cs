using System;
using UnityEngine;
public class LinkedList
{
    public static bool has;
    public static bool has2;
    public static string forDeleteText;
    public static string forSearchText;
    public static string forPrintText;


    Node head; //첫 번째 노드를 가리키는 head
    
    //노드 추가하기
    public void InsertNode(string data)
    {
        Node node = new Node(data);
        if(head == null)
        {
            head = node;
            
        }
        else
        {
            Node lastNode = GetLastNode();
            lastNode.next = node;
        }
        
        Debug.Log(data + "가 링크드 리스트에 추가되었습니다~~~~~");

    }
    //마지막 노드 가져오기
    public Node GetLastNode()
    {
        Node temp = head;
        while(temp.next != null)
        {
            temp = temp.next;
        }
        return temp;
    }

    //노드 삭제하기 
    //하나 전의 노드의 주소를 저장하여 삭제할 노드를 찾았을 때, 
    //하나 전 노드의 next 포인터를 삭제할 노드의 next 포인터의 값으로 바꾼 후 노드를 제거합니다.
    public void DeleteNode(string data)
    {
   
        Node temp = head;
        Node prev = null; 
        has= false;
        forDeleteText = "";
        //data가 없을 경우
        if (temp==null)
        {
            forDeleteText = "데이터가 존재하지 않습니다!";
            Debug.Log("데이터가 존재하지 않습니다!");
            return;
        }
        //head data일 경우
        if (head.data == data)
        {
            head = head.next;
            forDeleteText = data + "가 링크드 리스트에서 삭제되었습니다^3^";
            Debug.Log(data + "가 링크드 리스트에서 삭제되었습니다^3^");
            return;
        }

        for (Node node = head; node != null; node = node.next)
        {
            
            prev = temp;
            temp = temp.next;

            if (temp != head && temp.data == data)
            {
                
                prev.next = temp.next;
                has = true;
                forDeleteText = data + "가 링크드 리스트에서 삭제되었습니다^3^";
                Debug.Log(data + "가 링크드 리스트에서 삭제되었습니다^3^");
                return;
            }
        }

        if (has == false)
        {
            forDeleteText = "값이 존재하지 않습니다!";
            Debug.Log("값이 존재하지 않습니다!");
        }


    }

    //노드 탐색하기
    public void SearchNode(string data)
    {
        int count = 0;
        has2 = false;
        forSearchText = "";
        for (Node node = head; node != null; node = node.next)
        {
            count++;
            if(node.data == data)
            {
                forSearchText = count + "번 째에 있습니다!";
                has2 = true;
                break;
            }         
        }
        if (has2==false)
        {
            forSearchText="존재하지 않습니다!";
        }
        
    }

    //노드 출력하기
    public void Print()
    {
        forPrintText = "";
        int count=0;
        for (Node node = head; node != null; node = node.next)
        {

            forPrintText += node.data + " -> ";
            count++;
        }

        forPrintText += '\n';
        forPrintText += "총 개수: " +count;
    }
}
