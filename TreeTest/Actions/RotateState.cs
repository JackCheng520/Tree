using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.JackCheng.TREE;
using UnityEngine;
// ================================
//* 功能描述：RotateState  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/25 17:57:35
// ================================
namespace Assets.JackCheng.TreeTest.Actions
{
    public class RotateState : JBTActionLeaf
    {
        protected override void OnEnter(JBTWorkingData data)
        {

        }
        protected override int OnExcute(JBTWorkingData data)
        {
            AIEntityWorkingData wData = data.AS<AIEntityWorkingData>();
            Vector3 targetPos = JBTMathfUtil.Vector3ZeroY(wData.entity.GetBlackboardData<Vector3>(AIEntity.nextMovingTarget, Vector3.zero));
            wData.angle += wData.deltaTime * 50f;
            wData.entity.transform.RotateAround(targetPos, Vector3.up, wData.deltaTime * 50f);
            if (wData.angle > 360)
                return JBTRunningStatus.FINISHED;
            return JBTRunningStatus.EXECUTING;
        }

        protected override void OnExit(JBTWorkingData data, int statue)
        {
            AIEntityWorkingData wData = data.AS<AIEntityWorkingData>();
            wData.angle = 0;
            wData.canChangePos = true;
        }
    }
}
