﻿using LibLogSample;

using Serilog;

namespace CSharpFundamental.LibLog
{
    internal class ConsumerLibLog
    {
        public void BeginToLogTheLibraryEvent()
        {
            var log = new LoggerConfiguration()
                .WriteTo.ColoredConsole(
                    outputTemplate: "{Timestamp:yyyy:MM:dd:HH:mm} [{Level}] ({Name:l}) {Message}{NewLine}{Exception}")
                .CreateLogger();
            Log.Logger = log;

            var commonLibLog = new CommonLibLog();
        }
    }
}
