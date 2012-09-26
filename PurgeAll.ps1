"Emptying all message queues"
[Reflection.Assembly]::LoadWithPartialName("System.Messaging")
[System.Messaging.MessageQueue]::GetPrivateQueuesByMachine(".") | % { $_.Purge(); }
"Wiping out raven db data"
remove-item **\bin\*\Data -recurse -force