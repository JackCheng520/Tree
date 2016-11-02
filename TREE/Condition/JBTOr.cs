using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：JBTOr  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/25 14:38:34
// ================================
namespace Assets.JackCheng.TREE.Condition
{
    public class JBTOr : JBTPreconditionBinary
    {
        public JBTOr(JBTPrecondition lp, JBTPrecondition rp)
            : base(lp, rp)
        {
        }
        public override bool IsTrue(JBTWorkingData data)
        {
            return GetChild<JBTPrecondition>(0).IsTrue(data) ||
                   GetChild<JBTPrecondition>(1).IsTrue(data);
        }
    }
}
