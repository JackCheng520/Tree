using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：JBTPrecondition  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/25 13:45:22
// ================================
namespace Assets.JackCheng.TREE.Condition
{
    public abstract class JBTPrecondition : JBTTreeNode
    {
        public JBTPrecondition() { }
        public abstract bool IsTrue(JBTWorkingData data);
    }
}
