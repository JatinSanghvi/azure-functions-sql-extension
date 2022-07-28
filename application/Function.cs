// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Sql;
using Microsoft.Extensions.Logging;

namespace SqlApplication
{
    public static class SqlApplication
    {
        private static int insertCount, updateCount, deleteCount;
        private static readonly Random random = new(DateTime.Now.Millisecond);

        public static async Task Run(
            [SqlTrigger("[dbo].[Employees]", ConnectionStringSetting = "SqlConnectionString")]
            IReadOnlyList<SqlChange<Employee>> changes,
            ILogger logger)
        {
            await Task.Delay(random.Next(200));

            foreach (SqlChange<Employee> change in changes)
            {
                switch (change.Operation)
                {
                    case SqlChangeOperation.Delete: deleteCount += 1; break;
                    case SqlChangeOperation.Insert: insertCount += 1; break;
                    case SqlChangeOperation.Update: updateCount += 1; break;
                    default: break;
                }
            }

            logger.LogInformation($"Inserts: {insertCount}, Updates: {updateCount}, Deletes: {deleteCount}.");
        }
    }
}