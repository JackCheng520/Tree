using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：JBTSequence  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/23 17:13:29
// ================================
namespace Assets.JackCheng.TREE
{
    public class JBTActionSequence : JBTAction
    {
        protected class JBTActionSequenceContext : JBTActionContext
        {
            internal int curSelectIndex;
            public JBTActionSequenceContext()
            {
                curSelectIndex = -1;
            }
        }

        //-------------------------------------------------------
        private bool _continueIfErrorOccors;
        //-------------------------------------------------------
        public JBTActionSequence()
        {
            _continueIfErrorOccors = false;
        }
        public JBTActionSequence SetContinueIfErrorOccors(bool v)
        {
            _continueIfErrorOccors = v;
            return this;
        }

        protected override bool OnEvaluate(JBTWorkingData data)
        {
            //UnityEngine.Debug.Log(" -- JBTActionSequence -- OnEvaluate -- ");
            JBTActionSequenceContext context = GetContext<JBTActionSequenceContext>(data);
            int checkIndex = -1;
            if (IsIndexValid(context.curSelectIndex))
            {
                checkIndex = context.curSelectIndex;
            }
            else
            {
                checkIndex = 0;
            }

            if (IsIndexValid(checkIndex))
            {
                JBTAction node = GetChild<JBTAction>(checkIndex);
                if (node.Evaluate(data))
                {
                    context.curSelectIndex = checkIndex;
                    return true;
                }
            }
            return false;
        }

        protected override int OnUpdate(JBTWorkingData data)
        {
            //UnityEngine.Debug.Log(" -- JBTActionSequence -- OnUpdate -- ");
            JBTActionSequenceContext context = GetContext<JBTActionSequenceContext>(data);
            int runningStatus = JBTRunningStatus.FINISHED;
            JBTAction node = GetChild<JBTAction>(context.curSelectIndex);
            runningStatus = node.Update(data);
            if (_continueIfErrorOccors == false && JBTRunningStatus.IsError(runningStatus))
            {
                context.curSelectIndex = -1;
                return runningStatus;
            }
           
            if (JBTRunningStatus.IsFinished(runningStatus))
            {
                context.curSelectIndex++;
                if (IsIndexValid(runningStatus))
                {
                    runningStatus = JBTRunningStatus.EXECUTING;
                }
                else
                {
                    context.curSelectIndex = -1;
                }
            }
            return runningStatus;
        }

        protected override void OnTransition(JBTWorkingData data)
        {
            JBTActionSequenceContext context = GetContext<JBTActionSequenceContext>(data);
            if (IsIndexValid(context.curSelectIndex))
            {
                JBTAction node = GetChild<JBTAction>(context.curSelectIndex);
                node.Transition(data);
            }
            context.curSelectIndex = -1;
        }
    }
}
