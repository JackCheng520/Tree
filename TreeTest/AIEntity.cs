using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.JackCheng.TREE;
using UnityEngine;
// ================================
//* 功能描述：AIEntity  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/25 13:57:13
// ================================
namespace Assets.JackCheng.TreeTest
{
    public class AIEntity : MonoBehaviour
    {
        public const string nextMovingTarget = "nextMovingTarget";

        private JBTAction btree;
        private AIEntityWorkingData btreeWorkingData;
        private JBTBlackboard btreeBlackboard;

        private AIBehaviorRequest currentRequest;
        private AIBehaviorRequest nextRequest;

        private GameObject target;


        public AIEntity Init()
        {
            btree = AIEntityFactory.CreateEntity();

            btreeWorkingData = new AIEntityWorkingData();
            btreeWorkingData.entity = this;
            btreeWorkingData.transEntity = transform;
            btreeWorkingData.canChangePos = true;

            btreeBlackboard = new JBTBlackboard();

            target = JGameResourceMgr.Ins.LoadResource("target");

            return this;
        }

        public T GetBlackboardData<T>(string _key, T _defaultValue)
        {
            return btreeBlackboard.GetValue<T>(_key, _defaultValue);
        }

        public int UpdateAI(float _gameTime, float _deltaTime)
        {
            //Debug.Log("UpdateAI -- " + _gameTime + " -- " + _deltaTime);
            if (btreeWorkingData != null && btreeWorkingData.canChangePos)
            {
                btreeWorkingData.canChangePos = false;
                //timeDuration = _gameTime + 20 + UnityEngine.Random.Range(-5, 5);
                nextRequest = new AIBehaviorRequest
                    (
                    _gameTime,
                    new Vector3(UnityEngine.Random.Range(-15f, 15f), 0, UnityEngine.Random.Range(-15f, 15f))
                    );
            }
            return 0;
        }

        public int UpdateRequest(float _gameTime, float _deltaTime)
        {
            if (currentRequest != nextRequest)
            {
                btree.Transition(btreeWorkingData);
                currentRequest = nextRequest;

                Vector3 targetPos = currentRequest.nextMovingTarget
                    + JBTMathfUtil.GetDirection2D(currentRequest.nextMovingTarget, transform.position) * 0.2f;

                Vector3 startPos = new Vector3(targetPos.x, -1.4f, targetPos.z);
                target.transform.position = startPos;
                LeanTween.move(target, targetPos, 1f);
            }

            return 0;
        }

        public int UpdateBehavior(float _gameTime, float _deltaTime)
        {
            if (currentRequest == null)
                return 0;

            btreeWorkingData.gameTime = JGameTimer.Ins.gameTime;
            btreeWorkingData.deltaTime = JGameTimer.Ins.deltaTime;

            btreeBlackboard.SetValue(nextMovingTarget, currentRequest.nextMovingTarget);

            if (btree.Evaluate(btreeWorkingData))
            {
                btree.Update(btreeWorkingData);
            }
            else
            {
                btree.Transition(btreeWorkingData);
            }

            return 0;
        }
    }
}
