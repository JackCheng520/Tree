using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：AIBehaviorRequest  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/25 15:17:19
// ================================
namespace Assets.JackCheng.TreeTest
{
    public class AIBehaviorRequest
    {
        public AIBehaviorRequest(float _timeStamp, Vector3 _nextMovingTarget)
        {
            this.timeStamp = _timeStamp;
            this.nextMovingTarget = _nextMovingTarget;
        }

        public float timeStamp { set; get; }
        public Vector3 nextMovingTarget { set; get; }
    }
}
