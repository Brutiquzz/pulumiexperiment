using Pulumi;
using Pulumi.AzureNative.Storage;
using AzureNative = Pulumi.AzureNative;

namespace MyComponents;

public class MyStorageAccount : ComponentResource
{
    [Output("storageAccountId")]
    public Output<string> StorageAccountId { get; private set; }

    public MyStorageAccount(string name, MyStorageAccountResourceArgs args, ComponentResourceOptions? opts = null)
        : base("pkg:index:MyStorageAccount", name, opts)
    {
        var storageAccountArgs = new StorageAccountArgs
        {
            AccountName = name, // Ensure 'name' is valid for Azure Storagesss
            EnableHttpsTrafficOnly = true,
            ResourceGroupName = args.ResourceGroupName,
            Sku = new AzureNative.Storage.Inputs.SkuArgs
            {
                Name = SkuName.Standard_LRS,
            },
            Kind = Kind.StorageV2,
            Location = args.Location,
        };

        var storageAccount = new StorageAccount(name, storageAccountArgs);

        StorageAccountId = storageAccount.Id;

        this.RegisterOutputs(new Dictionary<string, object?>
        {
            ["storageAccountId"] = storageAccount.Id,
        });
    }
}
