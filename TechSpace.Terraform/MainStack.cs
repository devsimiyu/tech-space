using System;
using System.Collections.Generic;
using Constructs;
using HashiCorp.Cdktf;
using HashiCorp.Cdktf.Providers.Aws.InternetGateway;
using HashiCorp.Cdktf.Providers.Aws.Provider;
using HashiCorp.Cdktf.Providers.Aws.Vpc;


namespace MyCompany.MyApp
{
    class MainStack : TerraformStack
    {
        public MainStack(Construct scope, string id) : base(scope, id)
        {
            // define resources here

            var awsProfileVariable = new TerraformVariable(this, "aws_profile", new TerraformVariableConfig
            {
                Type = "string",
                Default = "default",
                Description = "Aws account profile"
            });

            new AwsProvider(this, "TechSpaceAwsProvider", new AwsProviderConfig
            {
                Region = "us-east-1",
                Profile = awsProfileVariable.StringValue,
            });

            var vpc = new Vpc(this, "TechSpaceAwsVpc", new VpcConfig
            {
                CidrBlock = "10.0.0.0/16",
                EnableDnsSupport = true,
                EnableDnsHostnames = true,
                InstanceTenancy = "default",
                Tags = new Dictionary<string, string>
                {
                    { "name", "tech-space" },
                    { "resource", "terraform-vpc" }
                }
            });

            new InternetGateway(this, "TechSpaceAwsInternetGateway", new InternetGatewayConfig
            {
                VpcId = vpc.Id,
                Tags = new Dictionary<string, string>
                {
                    { "name", "tech-space" },
                    { "resource", "terraform-internet-gateway" }
                }
            });
        }
    }
}