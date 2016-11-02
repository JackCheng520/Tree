using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：JBTAnd  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/25 14:36:48
// ================================
namespace Assets.JackCheng.TREE.Condition
{
    public class JBTAnd : JBTPreconditionBinary
    {
        public JBTAnd(JBTPrecondition lp, JBTPrecondition rp)
            : base(lp, rp)
        {

        }
        public override bool IsTrue(Assets.JackCheng.TREE.JBTWorkingData data)
        {
            return GetChild<JBTPrecondition>(0).IsTrue(data) &&
                   GetChild<JBTPrecondition>(1).IsTrue(data);
        }
    }
}
