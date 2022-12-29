using System;
/// <summary>
/// 단순 연결 리스트 구현해보기
/// 2022.12.21 ~ 2022.12.26
/// Author: 최희연
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
    /// 값으로 추가, 삭제, 탐색, 출력 하기
    /// </summary>
    /// <param name="data"></param>
    //노드 추가하기 기능
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
    //노드 삭제하기 
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
    //노드 전체 삭제하기 
    public void DeleteAll()
    {
        head = null;
        tail = null;
        count = 0;
    }
    //노드 탐색하기 -> 조건이 주어졌을 때, 알맞은 값 맨 앞에 있는 하나만 반환하기
    public T Search(Predicate<T> data)
    {
        for (Node<T> node = head; node != null; node = node.next)
        {
            if (data(node.data))
                return node.data;
        }
        return default(T);
    }
    //노드 탐색하기 (인덱스)
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
    //마지막 노드(tail) 가져오기
    public Node<T> GetLastNode()
    {
        if (tail == null)
            return head;
        return tail;
    }
    //리스트 개수 구하기
    public int Count()
    {
        return count;
    }
    //노드 삭제하기 (인덱스)
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
    //전체 노드 출력
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
