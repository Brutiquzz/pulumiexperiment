using Pulumi;
using Pulumi.AzureNative.Storage;
using AzureNative = Pulumi.AzureNative;

namespace MyComponents;

public class MyStorageAccount : ComponentResource
{
    [Output("storageAccountId")]
    public Output<string> StorageAccountId { get; set; }
    public MyStorageAccount(string name, MyStorageAccountResourceArgs args, ComponentResourceOptions opts)
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
            Location = args.Location,
        };

        var storageAccount = new StorageAccount(name, storageAccountArgs);

        StorageAccountId = storageAccount.Id;

        this.RegisterOutputs(new Dictionary<string, object?>
        {
            ["storageAccount"] = storageAccount.Name,
        });
    }
}
