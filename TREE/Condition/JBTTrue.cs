using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：JBTTrue  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/25 14:31:38
// ================================
namespace Assets.JackCheng.TREE.Condition
{
    public class JBTTrue : JBTPreconditionLeaf
    {
        public override bool IsTrue(JBTWorkingData data)
        {
            return true;
        }
    }
}
