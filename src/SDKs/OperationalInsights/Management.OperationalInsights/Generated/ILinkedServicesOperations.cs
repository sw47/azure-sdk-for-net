// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.OperationalInsights
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// LinkedServicesOperations operations.
    /// </summary>
    public partial interface ILinkedServicesOperations
    {
        /// <summary>
        /// Create or update a linked service.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group to get. The name is case
        /// insensitive.
        /// </param>
        /// <param name='workspaceName'>
        /// Name of the Log Analytics Workspace that will contain the
        /// linkedServices resource
        /// </param>
        /// <param name='linkedServiceName'>
        /// Name of the linkedServices resource
        /// </param>
        /// <param name='parameters'>
        /// The parameters required to create or update a linked service.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<LinkedService>> CreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string workspaceName, string linkedServiceName, LinkedService parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes a linked service instance.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group to get. The name is case
        /// insensitive.
        /// </param>
        /// <param name='workspaceName'>
        /// Name of the Log Analytics Workspace that contains the
        /// linkedServices resource
        /// </param>
        /// <param name='linkedServiceName'>
        /// Name of the linked service.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string workspaceName, string linkedServiceName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a linked service instance.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group to get. The name is case
        /// insensitive.
        /// </param>
        /// <param name='workspaceName'>
        /// Name of the Log Analytics Workspace that contains the
        /// linkedServices resource
        /// </param>
        /// <param name='linkedServiceName'>
        /// Name of the linked service.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<LinkedService>> GetWithHttpMessagesAsync(string resourceGroupName, string workspaceName, string linkedServiceName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets the linked services instances in a workspace.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group to get. The name is case
        /// insensitive.
        /// </param>
        /// <param name='workspaceName'>
        /// Name of the Log Analytics Workspace that contains the linked
        /// services.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IEnumerable<LinkedService>>> ListByWorkspaceWithHttpMessagesAsync(string resourceGroupName, string workspaceName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
