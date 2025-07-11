using Brutiquzz.MyComponents;
using System;
using System.Collections.Generic;

return await Pulumi.Deployment.RunAsync(() =>
{
    var config = new Pulumi.Config();
    var region = config.Require("region");

    var args = new MyStorageAccountArgs()
    {
        Location = region,
    };

    var storageAccount = new MyStorageAccount($"{Guid.NewGuid()}", args, null);

    // Export the primary key of the Storage Account
    return new Dictionary<string, object?>
    {
        ["storageAccountId"] = storageAccount.StorageAccountId,
    };
});