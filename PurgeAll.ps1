[Reflection.Assembly]::LoadWithPartialName("System.Messaging")

[System.Messaging.MessageQueue]::GetPrivateQueuesByMachine(".") | % { $_.Purge(); }