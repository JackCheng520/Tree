using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：JBTBlackboard  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/25 13:57:52
// ================================
namespace Assets.JackCheng.TREE
{
    public class JBTBlackboard
    {
        class JBTBlackboardItem
        {
            private object value;

            public void SetValue(object o)
            {
                value = o;
            }

            public T GetValue<T>()
            {
                return (T)value;
            }
        }

        private Dictionary<string, JBTBlackboardItem> dicItems;

        public JBTBlackboard()
        {
            if (dicItems == null)
                dicItems = new Dictionary<string, JBTBlackboardItem>();
        }

        public void SetValue(string _key, object _value)
        {
            JBTBlackboardItem _item = null;
            if (dicItems.ContainsKey(_key))
            {
                _item = dicItems[_key];
            }
            else
            {
                _item = new JBTBlackboardItem();
                dicItems.Add(_key, _item);
            }
            _item.SetValue(_value);
        }

        public T GetValue<T>(string _key, T _defaultValue)
        {
            if (dicItems.ContainsKey(_key))
            {
                return dicItems[_key].GetValue<T>();
            }
            else
            {
                return _defaultValue;
            }
        }
    }
}
