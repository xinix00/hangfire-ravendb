﻿using Hangfire.Raven.Entities;
using Raven.Client.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangfire.Raven.Indexes
{
    public class Hangfire_JobQueues
        : AbstractIndexCreationTask<JobQueue>
    {
        public class Mapping
        {
            public DateTime? FetchedAt { get; set; }
            public string Queue { get; set; }
        }

        public Hangfire_JobQueues()
        {
            Map = results => from result in results
                               select new Mapping
                               {
                                   Queue = result.Queue,
                                   FetchedAt = result.FetchedAt
                               };
            this.Analyze("Queue", "WhitespaceAnalyzer");
        }
    }
}
