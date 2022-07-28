// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.Sql;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SqlApplication
{
    public static class Program
    {
        public static async Task Main()
        {
            IHostBuilder hostBuilder = new HostBuilder()
                .UseEnvironment("Development")
                .ConfigureWebJobs(webJobsBuilder => webJobsBuilder.AddSql())
                .ConfigureLogging(loggingBuilder => loggingBuilder.SetMinimumLevel(LogLevel.Debug).AddConsole())
                .UseConsoleLifetime();

            using IHost host = hostBuilder.Build();
            await host.RunAsync();
        }
    }
}