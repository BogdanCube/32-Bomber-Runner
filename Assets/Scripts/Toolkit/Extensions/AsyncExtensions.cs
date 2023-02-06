using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Toolkit.Extensions
{
    public static class AsyncExtensions 
    {
        public static async Task SetAsyncTrigger(this Animator animator,string name)
        {
            animator.SetTrigger(name);
            var length = animator.GetCurrentAnimatorClipInfo(0).Length;
            await Task.Delay(TimeSpan.FromSeconds(length));
        }  
        public static async Task SetAsyncTrigger(this Animator animator,int index)
        {
            animator.SetTrigger(index);
            var length = animator.GetCurrentAnimatorClipInfo(0).Length;
            await Task.Delay(TimeSpan.FromSeconds(length));
        }
    }
}