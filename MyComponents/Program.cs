namespace MyComponents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pulumi.Experimental.Provider.ComponentProviderHost.Serve(args);
        }
    }
}
