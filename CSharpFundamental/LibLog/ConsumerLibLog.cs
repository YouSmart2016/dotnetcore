﻿using System.Threading.Tasks;

using LibLogSample;

using Serilog;
using System;
using System.Diagnostics;
using System.Threading;

namespace CSharpFundamental.LibLog
{
    internal class ConsumerLibLog
    {
        private void BeginToLogTheLibraryEvent(object state)
        {
            var log = new LoggerConfiguration()
                .WriteTo.ColoredConsole(
                    outputTemplate: "{Timestamp:yyyy:MM:dd:HH:mm} [{Level}] {Message}{NewLine}{Exception}")
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            Log.Logger = log;

            var commonLibLog = new CommonLibLog();

            Log.Information($"This is client logger info, ID:{Thread.CurrentThread.ManagedThreadId} State:{state}");
        }

        public void OpenNewTaskToHandleThisAsync()
        {
            var currentTask = Task.Run(() => BeginToLogTheLibraryEvent(10));

            Console.WriteLine(currentTask.Status);

            MultipleThreadToLogger();
        }

        private void MultipleThreadToLogger()
        {
            int taskCount = 10;

            Task[] tasks = new Task[taskCount];

            for (int i = 0; i < taskCount; ++i)
            {
                int temp = i;
                tasks[i] = Task.Run(() => BeginToLogTheLibraryEvent(temp));
            }

            // Task.WhenAll();
            var index = Task.WaitAny(tasks);

            Console.WriteLine($"The first completed id is{tasks[index].Id}");

            // Output the tasks id and status
            for (int i = 0; i < taskCount; ++i)
            {
                Console.WriteLine(tasks[i].Id + " | " + tasks[i].Status);
            }
        }
    }
}
