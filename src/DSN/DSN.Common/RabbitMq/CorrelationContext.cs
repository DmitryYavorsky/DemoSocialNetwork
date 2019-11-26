using System;
using System.Collections.Generic;
using System.Text;

namespace DSN.Common.RabbitMq
{
    public class CorrelationContext: ICorrelationContext
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public Guid ResourceId { get; }
        public string TraceId { get; }
        public string SpanContext { get; }
        public string ConnectionId { get; }
        public string Name { get; }
        public string Origin { get; }
        public string Resource { get; }
        public string Culture { get; }
        public DateTime CreatedAt { get; }
        public int Retries { get; }

        public CorrelationContext()
        {
            
        }

        private CorrelationContext(Guid id)
        {
            Id = id;
        }

        private CorrelationContext(Guid id, Guid userId, Guid resourceId, string traceId, string spanContext,
            string connectionId, string executionId, string name, string origin,
            string culture, string resource, int retries)
        {
            Id = id;
            UserId = userId;
            ResourceId = resourceId;
            TraceId = traceId;
            SpanContext = spanContext;
            ConnectionId = connectionId;
            Name = string.IsNullOrWhiteSpace(name) ? string.Empty : GetName(name);
            Origin = string.IsNullOrWhiteSpace(origin) ? string.Empty :
                origin.StartsWith("/") ? origin.Remove(0, 1) : origin;
            Culture = culture;
            Resource = resource;
            Retries = retries;
            CreatedAt = DateTime.UtcNow;
        }

        private static string GetName(string name)
            => name.Underscore().ToLowerInvariant();
    }
}
