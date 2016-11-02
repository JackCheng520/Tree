using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.JackCheng.TREE.Condition;
using Assets.JackCheng.TREE;
using UnityEngine;
// ================================
//* 功能描述：AICondition  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/25 16:23:22
// ================================
namespace Assets.JackCheng.TreeTest
{
    public class CON_BeReachedTarget : JBTPreconditionLeaf
    {
        public override bool IsTrue(JBTWorkingData data)
        {
            AIEntityWorkingData wData = data.AS<AIEntityWorkingData>();
            Vector3 targetPos = JBTMathfUtil.Vector3ZeroY(wData.entity.GetBlackboardData<Vector3>(AIEntity.nextMovingTarget, Vector3.zero));
            Vector3 currentPos = JBTMathfUtil.Vector3ZeroY(wData.transEntity.position);

            return JBTMathfUtil.GetDistance2D(targetPos, currentPos) < 1f;
        }
    }

    public class CON_RotateOver : JBTPreconditionLeaf
    {
        public override bool IsTrue(JBTWorkingData data)
        {
            AIEntityWorkingData wData = data.AS<AIEntityWorkingData>();
           

            return wData.angle > 360;
        }
    }
}
