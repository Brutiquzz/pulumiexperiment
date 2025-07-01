using Pulumi;
using Pulumi.AzureNative.Storage;
using AzureNative = Pulumi.AzureNative;

namespace MyComponents;

public class MyStorageAccount : ComponentResource
{
    public StorageAccount StorageAccount { get; set; }
    public MyStorageAccount(string name, ComponentResourceOptions opts, CustomResourceOptions? customResourceOptions = null)
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
            Location = "West Europe",
        };

        StorageAccount = new StorageAccount(name, storageAccountArgs, customResourceOptions);

    }
}
