﻿using Luck.EntityFrameworkCore.DbContexts;
using Luck.Framework.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Luck.EntityFrameworkCore.DbContextDrivenProvides
{
    public class MySqlDbContextDrivenProvider : IDbContextDrivenProvider
    {
        public DataBaseType Type => DataBaseType.MySql;

        public DbContextOptionsBuilder Builder<TDbContext>(DbContextOptionsBuilder builder,string connnectionString) where TDbContext : ILuckDbContext
        {

            builder.UseMySql(connnectionString, new MySqlServerVersion(new Version()), opt => opt.MigrationsAssembly(typeof(TDbContext).Assembly.GetName().Name)).EnableSensitiveDataLogging().UseSnakeCaseNamingConvention();
            return builder;
        }
    }
}
