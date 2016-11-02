using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：JBTNot  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/25 14:34:08
// ================================
namespace Assets.JackCheng.TREE.Condition
{
    public class JBTNot : JBTPreconditionUnary
    {
        public JBTNot(JBTPrecondition lp)
            : base(lp)
        {

        }
        public override bool IsTrue(JBTWorkingData data)
        {
            return !GetChild<JBTPrecondition>(0).IsTrue(data);
        }
    }
}
