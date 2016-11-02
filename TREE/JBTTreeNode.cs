using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：JBTTreeNode  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/23 14:33:56
// ================================
namespace Assets.JackCheng.TREE
{
    public class JBTTreeNode
    {
        public List<JBTTreeNode> listChild;
        public JBTTreeNode()
        {
            if (listChild == null)
                listChild = new List<JBTTreeNode>();
        }

        ~JBTTreeNode()
        {
            listChild = null;
        }

        public int ChildCount
        {
            get
            {
                return listChild.Count;
            }
        }

        public JBTTreeNode AddChild(JBTTreeNode _child)
        {
            if (!listChild.Contains(_child))
                listChild.Add(_child);
            return this;
        }

        public bool IsIndexValid(int index)
        {
            return index >= 0 && index < listChild.Count;
        }

        public T GetChild<T>(int index) where T : JBTTreeNode
        {
            if (!IsIndexValid(index))
                return null;
            return listChild[index] as T;
        }
    }
}
