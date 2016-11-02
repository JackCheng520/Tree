using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.JackCheng.TREE;
using UnityEngine;

// ================================
//* 功能描述：MoveToState  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/25 15:02:41
// ================================
namespace Assets.JackCheng.TreeTest.Actions
{
    public class MoveToState : JBTActionLeaf 
    {
        protected override void OnEnter(JBTWorkingData data)
        {
            AIEntityWorkingData wData = data.AS<AIEntityWorkingData>();
            //Debug.Log("--MoveToState -- OnEnter --");
        }

        protected override int OnExcute(JBTWorkingData data)
        {
            //Debug.Log("--MoveToState -- OnExcute --");
            AIEntityWorkingData wData = data.AS<AIEntityWorkingData>();
            Vector3 targetPos = JBTMathfUtil.Vector3ZeroY(wData.entity.GetBlackboardData<Vector3>(AIEntity.nextMovingTarget, Vector3.zero));
            Vector3 currentPos = JBTMathfUtil.Vector3ZeroY(wData.transEntity.position);
            float distToTarget = JBTMathfUtil.GetDistance2D(targetPos, currentPos);
            if (distToTarget < 1f)
            {
                wData.transEntity.position = targetPos;
                return JBTRunningStatus.FINISHED;
            }
            else
            {
                int ret = JBTRunningStatus.EXECUTING;
                Vector3 toTarget = JBTMathfUtil.GetDirection2D(targetPos, currentPos);
                float movingStep = 2f * wData.deltaTime;
                if (movingStep > distToTarget)
                {
                    movingStep = distToTarget;
                    ret = JBTRunningStatus.FINISHED;
                }
                wData.transEntity.position = wData.transEntity.position + toTarget * movingStep;
                return ret;
            }
        }

        protected override void OnExit(JBTWorkingData data, int statue)
        {
            //Debug.Log("--MoveToState -- OnExit --");
            AIEntityWorkingData wData = data.AS<AIEntityWorkingData>();
            
        }
    }
}
