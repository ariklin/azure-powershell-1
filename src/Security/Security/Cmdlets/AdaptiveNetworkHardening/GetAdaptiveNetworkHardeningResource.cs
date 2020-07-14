﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ------------------------------------

using System.Management.Automation;
using Commands.Security;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.SecurityCenter.Models.AdaptiveNetworkHardening;

namespace Microsoft.Azure.Commands.Security.Cmdlets.AdaptiveNetworkHardening
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecurityAdaptiveNetworkHardeningResource", DefaultParameterSetName = ParameterSetNames.ResourceGroupLevelResource), OutputType(typeof(PSSecurityAdaptiveNetworkHardening))]
    public class GetAdaptiveNetworkHardeningResource : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.AdaptiveNetworkHardeningResourceName)]
        [ValidateNotNullOrEmpty]
        public string AdaptiveNetworkHardeningResourceName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceName)]
        [ValidateNotNullOrEmpty]
        public string ResourceName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceNamespace)]
        [ValidateNotNullOrEmpty]
        public string ResourceNamespace { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceType)]
        [ValidateNotNullOrEmpty]
        public string ResourceType { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ResourceGroupLevelResource, Mandatory = true, HelpMessage = ParameterHelpMessages.SubscriptionId)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        public override void ExecuteCmdlet()
        {
            SecurityCenterClient.SubscriptionId = SubscriptionId;
            var adaptiveNetworkHardening = SecurityCenterClient.AdaptiveNetworkHardening
                .GetWithHttpMessagesAsync(ResourceGroupName, ResourceNamespace, ResourceType, ResourceName, AdaptiveNetworkHardeningResourceName)
                .GetAwaiter()
                .GetResult()
                .Body;

            WriteObject(adaptiveNetworkHardening.ConvertToPSType(), enumerateCollection: true);
        }
    }
}
