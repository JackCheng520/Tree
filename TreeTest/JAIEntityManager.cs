using Assets.JackCheng.TreeTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：JAIEntityManagercs  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/25 15:57:32
// ================================
namespace Assets.JackCheng.TreeTest
{
    public class JAIEntityManager : JSington<JAIEntityManager>
    {
        public delegate int JAIEntityUpdateDelegate(AIEntity _e, float _gameTime, float _deltaTime);

        public List<AIEntity> listEntity;

        public JAIEntityManager()
        {
            if (listEntity == null)
                listEntity = new List<AIEntity>();
        }

        public void AddEntity(AIEntity _entity)
        {
            if (!listEntity.Contains(_entity))
            {
                listEntity.Add(_entity);
            }
        }

        public void Update(JAIEntityUpdateDelegate _delgate, float _gameTime, float _deltaTime)
        {
            for (int i = 0; i < listEntity.Count; i++)
            {
                if (listEntity[i] != null)
                {
                    _delgate(listEntity[i], _gameTime, _deltaTime);
                }
            }
        }
    }
}
