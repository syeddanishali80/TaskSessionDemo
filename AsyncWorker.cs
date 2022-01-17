using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPractice
{
    public class AsyncWorker
    {
        public Task<int> DoWorkAsync(int data) {
            return Task.Delay(data * 1000).ContinueWith(t => data);
        }

    }
}
