using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPractice
{
    public class SyncWorker
    {
        public int DoWork(int data)
        {
            Thread.Sleep(data * 1000);
            return data;
        }
    }
}
