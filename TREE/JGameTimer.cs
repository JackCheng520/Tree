using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：GameTimer  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/25 15:50:07
// ================================
namespace Assets.JackCheng.TREE
{
    class JGameTimer:JSington<JGameTimer>
    {
        public float gameTime
        {
            private set;
            get;
        }
        public float deltaTime
        {
            private set;
            get;
        }
        public float timeScale
        {
            get
            {
                return Time.timeScale;
            }
        }
        public void Init()
        {
            gameTime = 0f;
            deltaTime = 0f;
        }
        public void UpdateTime()
        {
            deltaTime = Time.deltaTime * Time.timeScale;
            gameTime += deltaTime;
        }
    }
}
