using Pulumi;
using Pulumi.AzureNative.Storage;

namespace MyComponents
{
    public sealed class MyStorageAccountResourceArgs : Pulumi.ResourceArgs
    {
        [Input("location", required: true)]
        public Input<string> Location { get; set; } 
    }
}
