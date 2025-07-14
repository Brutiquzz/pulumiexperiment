using System.Threading.Tasks;

public class Program
{
    private static async Task<int> Main(string[] args)
    {

        return await Pulumi.Deployment.RunAsync<MyStack>();

    }
}