using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：JTAny  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/23 16:12:53
// ================================
namespace Assets.JackCheng.ToolKit
{
    public class JTAny
    {
        public T AS<T>() where T : JTAny
        {
            return (T)this;
        }
    }
}
