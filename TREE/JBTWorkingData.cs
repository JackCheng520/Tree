using Assets.JackCheng.ToolKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：JTBWorkingData  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/23 16:06:25
// ================================
namespace Assets.JackCheng.TREE
{
    public class JBTWorkingData : JTAny
    {
        internal Dictionary<int, JBTActionContext> dicContext;

        public JBTWorkingData()
        {
            dicContext = new Dictionary<int, JBTActionContext>();
        }
        ~JBTWorkingData()
        {
            dicContext = null;
        }
    }
}
