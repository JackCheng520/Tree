using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：JBTFalse  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/25 14:32:31
// ================================
namespace Assets.JackCheng.TREE.Condition
{
    public class JBTFalse : JBTPreconditionLeaf
    {
        public override bool IsTrue(JBTWorkingData data)
        {
            return false;
        }
    }
}
