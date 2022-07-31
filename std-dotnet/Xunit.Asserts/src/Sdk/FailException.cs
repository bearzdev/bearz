/*
Copyright (c) .NET Foundation and Contributors
All Rights Reserved

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
namespace Xunit.Sdk
{
#pragma warning disable S3925, RCS1194

    public class FailException : XunitException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailException" /> class.
        /// </summary>
        /// <param name="message">The user's failure message.</param>
        public FailException(string message)
            : base($"Assert.Fail(): {message}")
        {
        }
    }
}