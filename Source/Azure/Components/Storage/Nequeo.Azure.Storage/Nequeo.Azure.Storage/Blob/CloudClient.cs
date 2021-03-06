﻿/*  Company :       Nequeo Pty Ltd, http://www.nequeo.com.au/
 *  Copyright :     Copyright © Nequeo Pty Ltd 2015 http://www.nequeo.com.au/
 * 
 *  File :          
 *  Purpose :       
 * 
 */

#region Nequeo Pty Ltd License
/*
    Permission is hereby granted, free of charge, to any person
    obtaining a copy of this software and associated documentation
    files (the "Software"), to deal in the Software without
    restriction, including without limitation the rights to use,
    copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the
    Software is furnished to do so, subject to the following
    conditions:

    The above copyright notice and this permission notice shall be
    included in all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
    OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
    NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
    HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
    WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
    FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
    OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Nequeo.Azure.Storage.Blob
{
    /// <summary>
    /// Cloud client provider.
    /// </summary>
    public class CloudClient
    {
        /// <summary>
        /// Cloud client provider
        /// </summary>
        /// <param name="storageAccount">The cloud storage account.</param>
        public CloudClient(CloudAccount storageAccount)
        {
            _cloudBlobClient = storageAccount.CloudStorageAccount.CreateCloudBlobClient();
        }

        private CloudBlobClient _cloudBlobClient = null;

        /// <summary>
        /// Gets the cloud blob client.
        /// </summary>
        public CloudBlobClient CloudBlobClient
        {
            get { return _cloudBlobClient; }
        }

        /// <summary>
        /// Get the cloud blob.
        /// </summary>
        /// <param name="containerName">The name of the blob.</param>
        /// <returns>The cloud blob.</returns>
        public CloudBlobContainer GetCloudBlobContainer(string containerName)
        {
            return _cloudBlobClient.GetContainerReference(containerName);
        }

        /// <summary>
        /// Get the cloud blob.
        /// </summary>
        /// <returns>The cloud blob.</returns>
        public CloudBlobContainer GetRootCloudBlobContainer()
        {
            return _cloudBlobClient.GetRootContainerReference();
        }

        /// <summary>
        /// Get all the cloud blob.
        /// </summary>
        /// <param name="prefix">A string containing the blob name prefix.</param>
        /// <returns>The list of cloud blob.</returns>
        public IEnumerable<IListBlobItem> GetBlobs(string prefix)
        {
            return _cloudBlobClient.ListBlobs(prefix);
        }

        /// <summary>
        /// Get all the cloud blob.
        /// </summary>
        /// <param name="cloudBlobContainer">A cloud blob container.</param>
        /// <returns>The list of cloud blob.</returns>
        public IEnumerable<IListBlobItem> GetBlobs(CloudBlobContainer cloudBlobContainer)
        {
            return cloudBlobContainer.ListBlobs();
        }
    }
}
