using Pulumi;
using Pulumi.AzureNative.Storage;
using AzureNative = Pulumi.AzureNative;

namespace MyPulumiComponents;

public class MyStorageAccount : Pulumi.ComponentResource
{
    public StorageAccount StorageAccount { get; set; }
    public MyStorageAccount(string name, ComponentResourceOptions opts, CustomResourceOptions? customResourceOptions = null)
        : base("pkg:index:MyComponent", name, opts)
    {
        var storageAccountArgs = new StorageAccountArgs 
        {
            AccountName = name.ToLower(),
            EnableHttpsTrafficOnly = true,
            ResourceGroupName = "SomeResourceGroupp",
            Sku = new AzureNative.Storage.Inputs.SkuArgs
            {
                Name = AzureNative.Storage.SkuName.Standard_LRS,
            },
            Kind = AzureNative.Storage.Kind.StorageV2,
            Location = "West Europe",
        };

        this.StorageAccount = new StorageAccount(name, storageAccountArgs, customResourceOptions);

    }
}
