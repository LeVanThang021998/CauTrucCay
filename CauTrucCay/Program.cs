using Microsoft.VisualBasic;

namespace CauTrucCay
{ 
    //Dinh nghia truc cua cay
    class TNode 
    {
        public int Info;
        public TNode Left;
        public TNode Right;
        public TNode(int x)
        {
            Info = x;
            Left = null;
            Right = null;
        }
    }
    //Dinh nghia cay nhi phan
    class SearchBinaryTree
    {
        public TNode Root;
        public SearchBinaryTree() 
        {
            Root = null;
        }
        //Thao tac duyet cay
        //Duyet theo thu tu truoc
        public void NLR(TNode root)
        {
            if (root!=null)
            {
                Console.Write($"{root.Info} -> ");
                NLR(root.Left);
                NLR(root.Right);
            }
        }       
        //Duyet theo thu tu giua
        public void LNR(TNode root)
        {
            if (root!=null)
            {
                LNR(root.Left);
                Console.Write($"{root.Info} -> ");
                LNR(root.Right);
            }
        }
        //Duyet theo thu tu sau
        public void LRN(TNode root)
        {
            if (root != null)
            {
                LRN(root.Left);
                Console.Write($"{root.Info} -> ");
                LRN(root.Right);
            }
        }
        //Thao tac them nut vao cay nhi phan tim kiem
        public void ThemNode(ref TNode root, int x)
        {
            if (root == null)
            {
                TNode p = new TNode(x);
                root = p;
            }
            else if (root.Info > x)
                ThemNode(ref root.Left, x);
            else if (root.Info < x)
                ThemNode(ref root.Right, x);
        }
        //Phuong thuc tao cay
        public void TaoCay()
        {
            Console.Write("Cho biet so nut trong cay: ");
            int n = int.Parse(Console.ReadLine());
            for (int i=1; i<=n; i++)
            {
                Console.Write("Nhap gia tri node thu " + i + ": ");
                    int x = int.Parse(Console.ReadLine());
                ThemNode(ref Root, x);
            }
        }
        //Phuong thuc tinh gia tri x tren cay nhi phan tim kiem
        public TNode TimKiem(TNode root, int x)
        {
            TNode kq = null;
            if (root != null);
            {
                if (root.Info == x)
                    kq = root;
                else if (x < root.Info)
                    kq = TimKiem(root.Left, x);
                else
                    kq = TimKiem(root.Right, x);             
            }
            return kq;
        }      
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SearchBinaryTree tree = new SearchBinaryTree();
            tree.TaoCay();
            Console.WriteLine("Ket qua duyet cay: ");
            Console.Write("\nNRL: ");
            tree.NLR(tree.Root);
            Console.Write("\nLNG: ");
            tree.LNR(tree.Root);
            Console.Write("\nLRN: ");
            tree.LRN(tree.Root);
            Console.Write("Nhap gia tri nut can tim: ");
            int x = int.Parse(Console.ReadLine());
            TNode kq = tree.TimKiem(tree.Root, x);
            if(kq ==null)
            {
                Console.WriteLine($"{x} khong xuat hien trong cay");
            }
            else
            {
                Console.WriteLine($"{x} co xuat hien trong cay");
            }
            Console.ReadLine();
        }
    }
}
