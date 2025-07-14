using Brutiquzz.Pulumicomponents;
using Pulumi;

public class MyStack : Pulumi.Stack
{
    public MyStack()
    {
        var config = new Pulumi.Config();
        var region = config.Require("region");

        var args = new MyStorageAccountArgs()
        {
            Location = region,
            ResourceGroupName = "brutiquzz1234"
        };

        var storageAccount = new MyStorageAccount("brutiquzz1234", args, null);

        this.StorageAccountId = storageAccount.StorageAccountId;
    }

    [Output("storageAccountId")] public Output<string> StorageAccountId { get; set; }
}