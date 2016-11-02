using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：JBTPreconditionBinarycs  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/25 14:30:13
// ================================
namespace Assets.JackCheng.TREE.Condition
{
    public abstract class JBTPreconditionBinary : JBTPrecondition
    {
        public JBTPreconditionBinary(JBTPrecondition lp, JBTPrecondition rp)
        {
            AddChild(lp);
            AddChild(rp);
        }
        
    }
}
