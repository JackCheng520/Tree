using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.JackCheng.TREE;
using Assets.JackCheng.TREE.Condition;
using Assets.JackCheng.TreeTest.Actions;
// ================================
//* 功能描述：AIEntityFactory  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/25 13:56:43
// ================================
namespace Assets.JackCheng.TreeTest
{
    public class AIEntityFactory
    {
        private static JBTAction action = null;

        public static JBTAction CreateEntity()
        {
            if (action != null)
            {
                return action;
            }
            else
            {
                action = new JBTActionPrioritizedSelector();
                action.AddChild
                    (
                    //new JBTActionLoop().SetLoopCount(3)
                    new JBTActionSequence()
                    .SetPrecondition(new JBTNot(new CON_BeReachedTarget()))
                    .AddChild(new MoveToState())
                    );
                action.AddChild(
                    new JBTActionSequence()
                    .SetPrecondition(new JBTNot(new CON_RotateOver()))
                    .AddChild(new RotateState())
                    );
              
            }

            return action;
        }
    }
}
