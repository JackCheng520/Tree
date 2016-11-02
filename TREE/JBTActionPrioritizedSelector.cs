using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：JTBActionPrioritizedSelector  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/23 16:00:00
// ================================
namespace Assets.JackCheng.TREE
{
    public class JBTActionPrioritizedSelector : JBTAction
    {
        protected class JTBActionPrioritizedSelectorContext : JBTActionContext
        {
            internal int curSelectIndex;
            internal int lastSelectIndex;

            public JTBActionPrioritizedSelectorContext()
            {
                curSelectIndex = -1;
                lastSelectIndex = -1;
            }
        }

        public JBTActionPrioritizedSelector()
        {

        }

        protected override bool OnEvaluate(JBTWorkingData data)
        {
            JTBActionPrioritizedSelectorContext context = GetContext<JTBActionPrioritizedSelectorContext>(data);
            context.curSelectIndex = -1;
            for (int i = 0, len = ChildCount; i < len; ++i)
            {
                JBTAction node = GetChild<JBTAction>(i);
                if (node.Evaluate(data))
                {
                    context.curSelectIndex = i;
                    return true;
                }
            }
            return false;
        }

        protected override int OnUpdate(JBTWorkingData data)
        {
            //UnityEngine.Debug.Log(" -- JBTActionPrioritizedSelector -- OnUpdate -- ");
            JTBActionPrioritizedSelectorContext context = GetContext<JTBActionPrioritizedSelectorContext>(data);
            int runningStatus = JBTRunningStatus.FINISHED;
            if (context.curSelectIndex != context.lastSelectIndex)
            {
                if (IsIndexValid(context.lastSelectIndex))
                {
                    JBTAction node = GetChild<JBTAction>(context.lastSelectIndex);
                    node.Transition(data);
                }
                context.lastSelectIndex = context.curSelectIndex;
            }
            if (IsIndexValid(context.lastSelectIndex))
            {
                JBTAction node = GetChild<JBTAction>(context.lastSelectIndex);
                runningStatus = node.Update(data);
                if (JBTRunningStatus.IsFinished(runningStatus))
                {
                    context.lastSelectIndex = -1;
                }
                
            }
            return 0;
        }

        protected override void OnTransition(JBTWorkingData data)
        {
            JTBActionPrioritizedSelectorContext context = GetContext<JTBActionPrioritizedSelectorContext>(data);
            if (IsIndexValid(context.lastSelectIndex))
            {
                JBTAction node = GetChild<JBTAction>(context.lastSelectIndex);
                if (node != null)
                {
                    node.Transition(data);
                }
                context.lastSelectIndex = -1;
            }
        }

    }
}
