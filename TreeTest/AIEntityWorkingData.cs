using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.JackCheng.TREE;
using UnityEngine;

// ================================
//* 功能描述：AIEntityWorkingData  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/25 13:55:16
// ================================
namespace Assets.JackCheng.TreeTest
{
    public class AIEntityWorkingData : JBTWorkingData
    {
        public AIEntity entity { set; get; }

        public Transform transEntity { set; get; }

        public float gameTime { set; get; }

        public float deltaTime { set; get; }

        public float angle { set; get; }

        public bool canChangePos { set; get; }
    }
}
