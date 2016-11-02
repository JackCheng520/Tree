using Assets.JackCheng.TREE.Condition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：JBTAction  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/23 14:44:03
// ================================
namespace Assets.JackCheng.TREE
{

    public class JBTActionContext
    {

    }

    public abstract class JBTAction : JBTTreeNode
    {
        static private int uniqueKey = 0;
        static public int UniqueKey
        {
            get
            {
                if (uniqueKey >= int.MaxValue)
                    return 0;
                else
                {
                    uniqueKey += 1;
                    return uniqueKey;
                }
            }
        }
        /// <summary>
        /// 该节点的ID
        /// </summary>
        private int id;
        public int ID
        {
            get
            {
                return this.id;
            }
        }

        public JBTPrecondition precondition;

        public JBTAction()
        {
            id = JBTAction.UniqueKey;
        }
        ~JBTAction()
        {

        }
        /// <summary>
        /// 设置条件
        /// </summary>
        /// <returns></returns>
        public JBTAction SetPrecondition(JBTPrecondition _precondition)
        {
            this.precondition = _precondition;
            return this;
        }
        protected T GetContext<T>(JBTWorkingData data) where T : JBTActionContext, new()
        {
            T context;
            if (!data.dicContext.ContainsKey(ID))
            {
                context = new T();
                data.dicContext.Add(ID, context);
            }
            else
            {
                context = (T)data.dicContext[ID];
            }
            return context;
        }
        //-------------------------------------
        /// <summary>
        /// 评估
        /// </summary>
        /// <returns></returns>
        public bool Evaluate(JBTWorkingData data)
        {
            return (precondition == null || precondition.IsTrue(data)) && OnEvaluate(data);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <returns></returns>
        public int Update(JBTWorkingData data)
        {
            return OnUpdate(data);
        }
        /// <summary>
        /// 转换
        /// </summary>
        public void Transition(JBTWorkingData data)
        {
            OnTransition(data);
        }


        //--------------------------------------------------
        protected virtual bool OnEvaluate(JBTWorkingData data) { return true; }

        protected virtual int OnUpdate(JBTWorkingData data) { return 0; }

        protected virtual void OnTransition(JBTWorkingData data) { }
    }
}
