using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：JBTActionLeaf  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/23 17:36:36
// ================================
namespace Assets.JackCheng.TREE
{
    public abstract class JBTActionLeaf : JBTAction
    {
        private const int ACTION_READY = 0;
        private const int ACTION_RUNNING = 1;
        private const int ACTION_FINISHED = 2;
        class JBTActionLeafContext : JBTActionContext
        {
            internal int status;
            internal bool needExit;

            private object userData;

            public T GetUserData<T>() where T : class ,new()
            {
                if (userData == null)
                {
                    userData = new T();
                }
                return (T)userData;
            }
            public JBTActionLeafContext()
            {
                status = JBTActionLeaf.ACTION_READY;
                needExit = false;
                userData = null;
            }
        }

        public JBTActionLeaf()
        {

        }
        ~JBTActionLeaf()
        {

        }

        protected T GetUserData<T>(JBTWorkingData data) where T : class ,new()
        {
            return GetContext<JBTActionLeafContext>(data).GetUserData<T>();
        }

        protected sealed override int OnUpdate(JBTWorkingData data)
        {
            //UnityEngine.Debug.Log(" -- JBTActionLeaf -- OnUpdate -- ");
            int runningStatus = JBTRunningStatus.FINISHED;
            JBTActionLeafContext context = GetContext<JBTActionLeafContext>(data);
            if (context.status == JBTActionLeaf.ACTION_READY)
            {
                OnEnter(data);
                context.status = JBTActionLeaf.ACTION_RUNNING;
                context.needExit = true;
            }
            else if (context.status == JBTActionLeaf.ACTION_RUNNING)
            {
                runningStatus = OnExcute(data);
                if (JBTRunningStatus.IsFinished(runningStatus))
                {
                    context.status = JBTActionLeaf.ACTION_FINISHED;
                }
            }
            if (context.status == JBTActionLeaf.ACTION_FINISHED)
            {
                if (context.needExit)
                {
                    OnExit(data, runningStatus);
                }
                context.status = JBTActionLeaf.ACTION_READY;
                context.needExit = false;
            }
            return runningStatus;
        }

        protected sealed override void OnTransition(JBTWorkingData data)
        {
            JBTActionLeafContext context = GetContext<JBTActionLeafContext>(data);
            if (context.needExit)
            {
                OnExit(data, JBTActionLeaf.ACTION_FINISHED);
            }
            context.status = JBTActionLeaf.ACTION_READY;
            context.needExit = false;
        }


        //------------------------------------------
        protected virtual void OnEnter(JBTWorkingData data) { }

        protected virtual int OnExcute(JBTWorkingData data) { return 0; }

        protected virtual void OnExit(JBTWorkingData data, int statue) { }
    }
}
