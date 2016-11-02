using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// ================================
//* 功能描述：JBTConst  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/5/23 16:26:37
// ================================
namespace Assets.JackCheng.TREE
{
    public class JBTRunningStatus
    {
        //状态
        public const int EXECUTING = 0;
        public const int FINISHED = 1;
        public const int TRANSITION = 2;

        //User running status
        //100-999, reserved user executing status
        public const int USER_EXECUTING = 100;
        //>=1000, reserved user finished status
        public const int USER_FINISHED = 1000;
        //-------------------------------------------------------
        static public bool IsOK(int runningStatus)
        {
            return runningStatus == JBTRunningStatus.FINISHED ||
                   runningStatus >= JBTRunningStatus.USER_FINISHED;
        }
        static public bool IsError(int runningStatus)
        {
            return runningStatus < 0;
        }
        static public bool IsFinished(int runningStatus)
        {
            return IsOK(runningStatus) || IsError(runningStatus);
        }
        static public bool IsExecuting(int runningStatus)
        {
            return !IsFinished(runningStatus);
        }
    }
}
