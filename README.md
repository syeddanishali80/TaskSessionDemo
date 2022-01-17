## Asynchronous & Parallel Programming

### SyncWorker
Synced work time taken: `2015`

### AsyncWorker with Task.WaitAll()
Worker1Status: WaitingForActivation
Worker2Status: WaitingForActivation
Worker1Status after WaitAll: RanToCompletion
Worker2Status after WaitAll: RanToCompletion
Asynced work time taken: `1010`

### AsyncWorker with simple await
Asynced work time taken: `2010` 

### AsyncWorker with Task.WhenAll()
Worker5Status: WaitingForActivation
Worker6Status: WaitingForActivation
WhenAllTask Status: WaitingForActivation
Worker5Status after WhenAll: WaitingForActivation
Worker6Status after WhenAll: WaitingForActivation
WhenAllTaskStatus after await: RanToCompletion
Worker5Status after await WhenAll: RanToCompletion
Worker6Status after await WhenAll: RanToCompletion
Asynced work time taken: `1012`

### AsyncWorker with Task.WhenAny()
WhenAnyTaskStatus: RanToCompletion
WhenAnyTaskStatus after await: RanToCompletion
WhenAnyTaskStatus of return from await: RanToCompletion