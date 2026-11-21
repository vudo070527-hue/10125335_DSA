namespace Buoi02_List
{
    // Một nút của danh sách liên kết đơn
    class Node
    {
        public int Data;
        public Node? Link;

        public Node(int giaTri)
        {
            Data = giaTri;
            Link = null;
        }
    }
}