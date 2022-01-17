// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using TaskPractice;

int TASK_WAIT_TIME = 1;

AsyncWorker asyncWorker1 = new();
AsyncWorker asyncWorker2 = new();
AsyncWorker asyncWorker3 = new();
AsyncWorker asyncWorker4 = new();
AsyncWorker asyncWorker5 = new();
AsyncWorker asyncWorker6 = new();

var asyncWorker1Task = asyncWorker1.DoWorkAsync(TASK_WAIT_TIME);
var asyncWorker2Task = asyncWorker2.DoWorkAsync(TASK_WAIT_TIME);
var asyncWorker3Task = asyncWorker3.DoWorkAsync(TASK_WAIT_TIME);
var asyncWorker4Task = asyncWorker4.DoWorkAsync(TASK_WAIT_TIME);
var asyncWorker5Task = asyncWorker5.DoWorkAsync(TASK_WAIT_TIME);
var asyncWorker6Task = asyncWorker6.DoWorkAsync(TASK_WAIT_TIME);

IEnumerable<Task> Tasks = new List<Task>() { asyncWorker1Task, asyncWorker2Task, asyncWorker3Task, asyncWorker4Task, asyncWorker5Task, asyncWorker6Task};

DoSyncWork();

Console.WriteLine("");

await AsyncTasksWithWaitAll();

Console.WriteLine("");

await AsyncWorkWithSimpleAwait();

Console.WriteLine("");

await AsyncWorkWithWhenAll();

Console.WriteLine("");

await AsyncWorkWithWhenAny(Tasks);

Console.WriteLine("");


async Task AsyncWorkWithWhenAny(IEnumerable<Task> tasks)
{
    var whenAnyTask = Task.WhenAny(tasks);

    Console.WriteLine($"WhenAnyTaskStatus: {whenAnyTask.Status}");

    var whenAnyTask2 = await whenAnyTask;

    Console.WriteLine($"WhenAnyTaskStatus after await: {whenAnyTask.Status}");
    Console.WriteLine($"WhenAnyTaskStatus of return from await: {whenAnyTask2.Status}");

}

async Task AsyncTasksWithWaitAll()
{
    Console.WriteLine("AsyncWorker with Task.WaitAll()");

    Stopwatch asyncStopWatch = new();

    asyncStopWatch.Start();

    var asyncWorker1Task = asyncWorker1.DoWorkAsync(TASK_WAIT_TIME);
    var asyncWorker2Task = asyncWorker2.DoWorkAsync(TASK_WAIT_TIME);

    Console.WriteLine($"Worker1Status: {asyncWorker1Task.Status}");
    Console.WriteLine($"Worker2Status: {asyncWorker2Task.Status}");

    Task.WaitAll(asyncWorker1Task, asyncWorker2Task);

    Console.WriteLine($"Worker1Status after WaitAll: {asyncWorker1Task.Status}");
    Console.WriteLine($"Worker2Status after WaitAll: {asyncWorker2Task.Status}");

    var worker1Result = await asyncWorker1Task;
    var worker2Result = await asyncWorker2Task;

    asyncStopWatch.Stop();

    Console.WriteLine($"Asynced work time taken: {asyncStopWatch.ElapsedMilliseconds}");
}

void DoSyncWork()
{
    Console.WriteLine("SyncWorker");

    SyncWorker syncWorker1 = new();
    SyncWorker syncWorker2 = new();

    Stopwatch syncStopWatch = new();

    syncStopWatch.Start();

    syncWorker1.DoWork(TASK_WAIT_TIME);
    syncWorker2.DoWork(TASK_WAIT_TIME);

    syncStopWatch.Stop();
    Console.WriteLine($"Synced work time taken: {syncStopWatch.ElapsedMilliseconds}");

}

async Task AsyncWorkWithSimpleAwait()
{
    Console.WriteLine("AsyncWorker with simple await");

    Stopwatch asyncStopWatch1 = new();

    asyncStopWatch1.Start();

    var worker3TaskResult = await asyncWorker3.DoWorkAsync(TASK_WAIT_TIME);
    var worker4TaskResult = await asyncWorker4.DoWorkAsync(TASK_WAIT_TIME);

    asyncStopWatch1.Stop();

    Console.WriteLine($"Asynced work time taken: {asyncStopWatch1.ElapsedMilliseconds}");
}

async Task AsyncWorkWithWhenAll()
{
    Console.WriteLine("AsyncWorker with Task.WhenAll()");

    Stopwatch asyncStopWatch2 = new();

    asyncStopWatch2.Start();

    var asyncWorker5Task = asyncWorker5.DoWorkAsync(1);
    var asyncWorker6Task = asyncWorker6.DoWorkAsync(1);

    Console.WriteLine($"Worker5Status: {asyncWorker5Task.Status}");
    Console.WriteLine($"Worker6Status: {asyncWorker6Task.Status}");

    var workerTask = Task.WhenAll(asyncWorker5Task, asyncWorker6Task);

    Console.WriteLine($"WhenAllTask Status: {workerTask.Status}");

    Console.WriteLine($"Worker5Status after WhenAll: {asyncWorker5Task.Status}");
    Console.WriteLine($"Worker6Status after WhenAll: {asyncWorker6Task.Status}");

    //var worker5Result = await worker5Task;
    //var worker6Result = await worker6Task;

    var result = await workerTask;

    Console.WriteLine($"WhenAllTaskStatus after await: {workerTask.Status}");

    Console.WriteLine($"Worker5Status after await WhenAll: {asyncWorker5Task.Status}");
    Console.WriteLine($"Worker6Status after await WhenAll: {asyncWorker6Task.Status}");

    asyncStopWatch2.Stop();

    Console.WriteLine($"Asynced work time taken: {asyncStopWatch2.ElapsedMilliseconds}");
}