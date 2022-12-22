using System;
using UnityEngine;
public class LinkedList
{
    public static bool has;
    public static bool has2;
    public static string forDeleteText;
    public static string forSearchText;
    public static string forPrintText;


    Node head; //ù ��° ��带 ����Ű�� head
    
    //��� �߰��ϱ�
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
        
        Debug.Log(data + "�� ��ũ�� ����Ʈ�� �߰��Ǿ����ϴ�~~~~~");

    }
    //������ ��� ��������
    public Node GetLastNode()
    {
        Node temp = head;
        while(temp.next != null)
        {
            temp = temp.next;
        }
        return temp;
    }

    //��� �����ϱ� 
    //�ϳ� ���� ����� �ּҸ� �����Ͽ� ������ ��带 ã���� ��, 
    //�ϳ� �� ����� next �����͸� ������ ����� next �������� ������ �ٲ� �� ��带 �����մϴ�.
    public void DeleteNode(string data)
    {
   
        Node temp = head;
        Node prev = null; 
        has= false;
        forDeleteText = "";
        //data�� ���� ���
        if (temp==null)
        {
            forDeleteText = "�����Ͱ� �������� �ʽ��ϴ�!";
            Debug.Log("�����Ͱ� �������� �ʽ��ϴ�!");
            return;
        }
        //head data�� ���
        if (head.data == data)
        {
            head = head.next;
            forDeleteText = data + "�� ��ũ�� ����Ʈ���� �����Ǿ����ϴ�^3^";
            Debug.Log(data + "�� ��ũ�� ����Ʈ���� �����Ǿ����ϴ�^3^");
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
                forDeleteText = data + "�� ��ũ�� ����Ʈ���� �����Ǿ����ϴ�^3^";
                Debug.Log(data + "�� ��ũ�� ����Ʈ���� �����Ǿ����ϴ�^3^");
                return;
            }
        }

        if (has == false)
        {
            forDeleteText = "���� �������� �ʽ��ϴ�!";
            Debug.Log("���� �������� �ʽ��ϴ�!");
        }


    }

    //��� Ž���ϱ�
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
                forSearchText = count + "�� °�� �ֽ��ϴ�!";
                has2 = true;
                break;
            }         
        }
        if (has2==false)
        {
            forSearchText="�������� �ʽ��ϴ�!";
        }
        
    }

    //��� ����ϱ�
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
        forPrintText += "�� ����: " +count;
    }
}
