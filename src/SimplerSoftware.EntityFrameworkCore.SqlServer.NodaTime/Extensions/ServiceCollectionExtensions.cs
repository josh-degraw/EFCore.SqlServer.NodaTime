﻿using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.SqlServer.Query.ExpressionTranslators;
using Microsoft.EntityFrameworkCore.SqlServer.Storage;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNodaTime(this IServiceCollection serviceCollection)
        {
            new EntityFrameworkRelationalServicesBuilder(serviceCollection)
                .TryAddProviderSpecificServices(
                    x =>
                    {
                        // Instant
                        x.TryAddSingletonEnumerable<IMethodCallTranslatorPlugin, InstantMethodCallTranslatorPlugin>();
                        x.TryAddSingletonEnumerable<IRelationalTypeMappingSourcePlugin, InstantTypeMappingSourcePlugin>();

                        // LocalDate
                        x.TryAddSingletonEnumerable<IMethodCallTranslatorPlugin, LocalDateMethodCallTranslatorPlugin>();
                        x.TryAddSingletonEnumerable<IRelationalTypeMappingSourcePlugin, LocalDateTypeMappingSourcePlugin>();
                    });

            return serviceCollection;
        }
    }
}