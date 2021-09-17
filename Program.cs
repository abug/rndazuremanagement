using System;
using System.Threading.Tasks;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace rndazuremanagement
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var subscriptionId = "1adf569c-4af2-478c-b41b-c82a132fa7d3";
            var webAppName = "warndazmgt";
            var rgName = "rgrndazmgt";

            var azure = Azure.Authenticate("my.azureauth").WithSubscription(subscriptionId);
            await azure.WebApps.Define(webAppName)
                .WithRegion(Region.EuropeWest)
                .WithNewResourceGroup(rgName)
                .WithNewLinuxPlan(PricingTier.BasicB1)
                .WithBuiltInImage(RuntimeStack.NETCore_V3_1).CreateAsync();

            await azure.WebApps.DeleteByResourceGroupAsync(rgName, webAppName, true, true);
            await azure.AppServices.AppServicePlans.DeleteByResourceGroupAsync(rgName, "warndazmgtplancc0893550ab99");
            await azure.ResourceGroups.DeleteByNameAsync(rgName);
        }
    }
}
