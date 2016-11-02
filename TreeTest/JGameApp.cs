using Assets.JackCheng.TREE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
// ================================
//* 功能描述：JGameApp  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/25 16:05:14
// ================================
namespace Assets.JackCheng.TreeTest
{
    public class JGameApp : MonoBehaviour
    {
        private JAIEntityManager.JAIEntityUpdateDelegate aiUpdate;
        private JAIEntityManager.JAIEntityUpdateDelegate requestUpdate;
        private JAIEntityManager.JAIEntityUpdateDelegate behaviorUpdate;
        void Awake()
        {
            aiUpdate = delegate(AIEntity _e, float _gameTime, float _deltaTime)
            {
                return _e.UpdateAI(_gameTime, _deltaTime);
            };

            requestUpdate = delegate(AIEntity _e, float _gameTime, float _deltaTime)
            {
                return _e.UpdateRequest(_gameTime, _deltaTime);
            };

            behaviorUpdate = delegate(AIEntity _e, float _gameTime, float _deltaTime)
            {
                return _e.UpdateBehavior(_gameTime, _deltaTime);
            };
        }
        float _gameTime;
        float _deltaTime;
        void Update()
        {
            JGameTimer.Ins.UpdateTime();
            _gameTime = JGameTimer.Ins.gameTime;
            _deltaTime = JGameTimer.Ins.deltaTime;

            JAIEntityManager.Ins.Update(aiUpdate, _gameTime, _deltaTime);
            JAIEntityManager.Ins.Update(requestUpdate, _gameTime, _deltaTime);
            JAIEntityManager.Ins.Update(behaviorUpdate, _gameTime, _deltaTime);

        }
        void OnGUI()
        {
            //speed up/slow down
            Time.timeScale = GUILayout.HorizontalSlider(Time.timeScale, 0, 2);
            //add unity
            if (GUILayout.Button("Add Entity"))
            {
                GameObject go = JGameResourceMgr.Ins.LoadResource("entity");
                if (go != null)
                {
                    JAIEntityManager.Ins.AddEntity(go.AddComponent<AIEntity>().Init());
                }
            }
        }
    }

}
