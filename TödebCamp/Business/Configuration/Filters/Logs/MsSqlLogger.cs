using System;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace Business.Configuration.Filters.Logs
{
    public class MsSqlLogger
    {

            public ILogger LoggerManager;

            public MsSqlLogger(IConfiguration configuration)
            {
                var sinkOpt = new MSSqlServerSinkOptions()
                {
                    TableName = "Logs",
                    AutoCreateSqlTable = true

                };

                var columnOpts = new ColumnOptions();
                columnOpts.Store.Remove(StandardColumn.Message);
                columnOpts.Store.Remove(StandardColumn.Properties);

                // Builder tasarım deseni

                var seriLogConf = new LoggerConfiguration().WriteTo.MSSqlServer(
                    connectionString: configuration.GetConnectionString("Mscomm"),
                    sinkOptions: sinkOpt,
                    columnOptions: columnOpts);

                LoggerManager = seriLogConf.CreateLogger();

            }
        
    }
}
