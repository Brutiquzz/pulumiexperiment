using Pulumi;
using Pulumi.AzureNative.Storage;
using AzureNative = Pulumi.AzureNative;

namespace MyComponents;

public class MyStorageAccount : ComponentResource
{
    public MyStorageAccount(string name, MyStorageAccountResourceArgs resourceArgs, ComponentResourceOptions opts)
        : base("mycomponents:index:MyStorageAccount", name, opts)
    {
        var storageAccountArgs = new StorageAccountArgs 
        {
            AccountName = name.ToLower(),
            EnableHttpsTrafficOnly = true,
            ResourceGroupName = "SomeResourceGroupp",
            Sku = new AzureNative.Storage.Inputs.SkuArgs
            {
                Name = SkuName.Standard_LRS,
            },
            Kind = Kind.StorageV2,
            Location = resourceArgs.Location,
        };

        var storageAccount = new StorageAccount(name, storageAccountArgs);

        this.RegisterOutputs(new Dictionary<string, object?>
        {
            ["storageAccount"] = storageAccount.Name,
        });

    }
}
