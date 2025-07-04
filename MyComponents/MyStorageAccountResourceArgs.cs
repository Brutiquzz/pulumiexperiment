using Pulumi;

namespace MyComponents;

public class MyStorageAccountResourceArgs : Pulumi.ResourceArgs
{
    [Input("location", required: true)]
    public Input<string> Location { get; set; } 
}
