using Amazon.CDK;
using Amazon.CDK.AWS.EC2;
using Constructs;

namespace TechSpace
{
    public class TechSpaceStack : Stack
    {
        internal TechSpaceStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            // The code that defines your stack goes here

            var vpc = new Vpc(this, "TechSpaceVpc", new VpcProps
            {
                IpAddresses = IpAddresses.Cidr("10.0.0.0/16"),
                EnableDnsHostnames = true,
                EnableDnsSupport = true,
                DefaultInstanceTenancy = DefaultInstanceTenancy.DEFAULT,
            });
        }
    }
}
