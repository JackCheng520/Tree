using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：JBTPreconditionUnary  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/25 14:29:28
// ================================
namespace Assets.JackCheng.TREE.Condition
{
    public abstract class JBTPreconditionUnary : JBTPrecondition
    {
        public JBTPreconditionUnary(JBTPrecondition lp)
        {
            AddChild(lp);
        }
    }
}
