
public class Node
{
    public string data; //데이터: inputField에 들어오는 값은 모두 string
    public Node next; //다음을 가리키는 노드
    public Node(string data) //생성자
    {
        this.data = data;
        next = null;
    }
}
