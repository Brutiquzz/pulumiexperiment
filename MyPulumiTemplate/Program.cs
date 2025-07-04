using Brutiquzz.MyComponents;
using System.Collections.Generic;

return await Pulumi.Deployment.RunAsync(() =>
{
    var args = new MyStorageAccountResourceArgs()
    {
        Location = "West Europe",
    };

    var storageAccount = new MyStorageAccount("someName", null, null);

    // Export the primary key of the Storage Account
    return new Dictionary<string, object?>
    {
        ["storageAccountName"] = storageAccount.GetResourceName(),
    };
});