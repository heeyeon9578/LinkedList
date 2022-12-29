using System;
/// <summary>
/// �ܼ� ���� ����Ʈ �����غ���
/// 2022.12.21 ~ 2022.12.26
/// Author: ����
/// </summary>
/// <typeparam name="T"></typeparam>
/// 
public class Node<T>
{
    public T data;
    public Node<T> next;

    public Node(T data)
    {
        this.data = data;
        next = null;
    }

}
public class LinkedList<T>
{

    Node<T> head;
    Node<T> tail;
    int count = 0;

    /// <summary>
    /// ������ �߰�, ����, Ž��, ��� �ϱ�
    /// </summary>
    /// <param name="data"></param>
    //��� �߰��ϱ� ���
    public void Insert(T data)
    {
        Node<T> node = new Node<T>(data);
        if (head == null)
        {
            head = node;
        }
        else
        {
            Node<T> lastNode = GetLastNode();
            lastNode.next = node;
            tail = node;
        }

        count++;

    }
    //��� �����ϱ� 
    public bool Delete(T data)
    {
        Node<T> prev = null;
        Node<T> cur = head;

        if (cur == null)
            return false;

        while (cur != null)
        {
            if (cur.data.Equals(data))
            {
                if (prev == null)
                {
                    head = head.next;
                }
                else if (cur.next == null)
                {
                    prev.next = cur.next;
                    tail = prev;
                }
                else
                {
                    prev.next = cur.next;
                }
                count--;
                return true;
            }
            prev = cur;
            cur = cur.next;
        }
        return false;
    }
    //��� ��ü �����ϱ� 
    public void DeleteAll()
    {
        head = null;
        tail = null;
        count = 0;
    }
    //��� Ž���ϱ� -> ������ �־����� ��, �˸��� �� �� �տ� �ִ� �ϳ��� ��ȯ�ϱ�
    public T Search(Predicate<T> data)
    {
        for (Node<T> node = head; node != null; node = node.next)
        {
            if (data(node.data))
                return node.data;
        }
        return default(T);
    }
    //��� Ž���ϱ� (�ε���)
    public T SearchIndex(int index)
    {
        int num = 0;
        for (Node<T> node = head; node != null; node = node.next)
        {
            if (index == num)
                return node.data;
            else
                num++;
        }
        return default(T);
    }
    //������ ���(tail) ��������
    public Node<T> GetLastNode()
    {
        if (tail == null)
            return head;
        return tail;
    }
    //����Ʈ ���� ���ϱ�
    public int Count()
    {
        return count;
    }
    //��� �����ϱ� (�ε���)
    public bool DeleteIndex(int index)
    {
        Node<T> prev = null;
        Node<T> cur = head;
        int num = 0;

        if (cur == null)
            return false;

        while (cur != null)
        {
            if (num == index)
            {
                if (prev == null)
                {
                    head = head.next;
                }
                else if (cur.next == null)
                {
                    prev.next = cur.next;
                    tail = prev;
                }
                else
                {
                    prev.next = cur.next;
                }
                count--;
                return true;
            }
            prev = cur;
            cur = cur.next;
            num++;
        }
        return false;
    }
    //��ü ��� ���
    public string PrintIndex()
    {
        string str = "";
        int num = 0;
        for (Node<T> node = head; node != null; node = node.next)
        {
            str += "{ index= " + num + "   data= " + node.data + " }  ->  ";
            num++;
        }
        return str;
    }
}
