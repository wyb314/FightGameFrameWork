/*
***********************************************************************************************************
* CLR version ：4.0.30319.34209
* Machine name ：ZT-2204397
* Creation time ：2015/6/3 17:04:29
* Author ：wyb
* Version number : 1.0
***********************************************************************************************************
*/

using System;
using System.Collections.Generic;

namespace StateMachine.Core
{
    public class BaseState<T> : State<T>
    {

        protected bool exited = false;

        public override void Exit(T entity)
        {
            this.exited = true;
        }

    }
}
