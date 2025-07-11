using Pulumi;

namespace MyComponents;

public class MyStorageAccountResourceArgs : Pulumi.ResourceArgs
{
    [Input("location", required: true)]
    public Input<string> Location { get; set; } = null!;

    [Input("resourceGroupName", required: true)]
    public Input<string> ResourceGroupName { get; set; } = null!;
}
