using Pulumi;

namespace MyComponents;

public class MyStorageAccountResourceArgs : Pulumi.ResourceArgs
{
    public Input<string> Location { get; set; } = null!;
    public Input<string> ResourceGroupName { get; set; } = null!;
}
