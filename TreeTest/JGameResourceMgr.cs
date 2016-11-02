using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：JGameResourceMgr  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/25 15:24:48
// ================================
namespace Assets.JackCheng.TreeTest
{
    public class JGameResourceMgr : JSington<JGameResourceMgr>
    {
        public JGameResourceMgr() { objLoop = new Dictionary<string, GameObject>(); }

        private Dictionary<string, GameObject> objLoop;
        public GameObject LoadResource(string path)
        {

            if (!objLoop.ContainsKey(path))
            {
                objLoop[path] = Resources.Load(path) as GameObject;
            }
            if (objLoop[path] == null)
                return null;
            
            return GameObject.Instantiate(objLoop[path],Vector3.zero,Quaternion.identity) as GameObject;
        }
    }
}
