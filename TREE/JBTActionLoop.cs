using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：JBTActionLoop  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/26 10:22:39
// ================================
namespace Assets.JackCheng.TREE
{
    public class JBTActionLoop :JBTAction
    {
        public const int INFINITY = -1;
        //--------------------------------------------------------
        protected class JTBActionLoopContext : JBTActionContext
        {
            internal int currentCount;

            public JTBActionLoopContext()
            {
                currentCount = 0;
            }
        }
        //--------------------------------------------------------
        private int _loopCount;
        //--------------------------------------------------------
        public JBTActionLoop()
        {
            _loopCount = INFINITY;
        }
        public JBTActionLoop SetLoopCount(int count)
        {
            _loopCount = count;
            return this;
        }
        //-------------------------------------------------------
        protected override bool OnEvaluate(JBTWorkingData wData)
        {
            JTBActionLoopContext thisContext = GetContext<JTBActionLoopContext>(wData);
            bool checkLoopCount = (_loopCount == INFINITY || thisContext.currentCount < _loopCount);
            if (checkLoopCount == false) {
                return false;
            }
            if (IsIndexValid(0)) 
            {
                JBTAction node = GetChild<JBTAction>(0);
                return node.Evaluate(wData);
            }
            return false;
        }
        protected override int OnUpdate(JBTWorkingData wData)
        {
            JTBActionLoopContext thisContext = GetContext<JTBActionLoopContext>(wData);
            int runningStatus = JBTRunningStatus.FINISHED;
            if (IsIndexValid(0)) {
                JBTAction node = GetChild<JBTAction>(0);
                runningStatus = node.Update(wData);
                if (JBTRunningStatus.IsFinished(runningStatus))
                {
                    thisContext.currentCount++;
                    if (thisContext.currentCount < _loopCount || _loopCount == INFINITY) {
                        runningStatus = JBTRunningStatus.EXECUTING;
                    }
                }
            }
            return runningStatus;
        }
        protected override void OnTransition(JBTWorkingData wData)
        {
            JTBActionLoopContext thisContext = GetContext<JTBActionLoopContext>(wData);
            if (IsIndexValid(0)) 
            {
                JBTAction node = GetChild<JBTAction>(0);
                node.Transition(wData);
            }
            thisContext.currentCount = 0;
        }
    }
}
