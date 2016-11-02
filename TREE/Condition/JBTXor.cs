using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：JBTXor  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/25 14:50:22
// ================================
namespace Assets.JackCheng.TREE.Condition
{
    public class JBTXor : JBTPreconditionBinary
    {
        public JBTXor(JBTPrecondition lp, JBTPrecondition rp)
            : base(lp, rp)
        {
            AddChild(lp);
            AddChild(rp);
        }

        public override bool IsTrue(Assets.JackCheng.TREE.JBTWorkingData data)
        {
            return GetChild<JBTPrecondition>(0).IsTrue(data) ^
                   GetChild<JBTPrecondition>(1).IsTrue(data);
        }
    }
}
