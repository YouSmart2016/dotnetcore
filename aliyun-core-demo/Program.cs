﻿using System;
using System.IO;
using System.Reflection;
using System.Xml;

using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Iot.Model.V20180120;

using NLog;
using NLog.Config;
using NLog.Targets;


namespace Aliyun.Core.Demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var accessKey = Environment.GetEnvironmentVariable("ACCESS_KEY_ID") ?? "AccessKeyId";
            var accessKeySecret = Environment.GetEnvironmentVariable("ACCESS_KEY_SECRET") ?? "AccessKeySecret";

            //DefaultProfile.AddEndpoint ("cn-hangzhou", "cn-hangzhou", "industry_brain", "industrial-brain.cn-hangzhou.aliyuncs.com");
            //IClientProfile profile = DefaultProfile.GetProfile("cn-shanghai", accessKey, accessKeySecret);
            //DefaultAcsClient client = new DefaultAcsClient(profile);

            var client = InitVodClient(accessKey, accessKeySecret);

            #region commend code

            // var request = new SubmitJobsRequest();
            // request.Input="{\"Bucket\":\"sgfa-sdf\",\"Location\":\"oss-cn-hangzhou\",\"Object\":\"test.flv\"}";
            // request.OutputBucket = "bucket-output-template";
            // request.OutputLocation="oss-cn-hangzhou";
            // request.PipelineId = "testpinpsfsd";
            // request.Outputs = "[{\"OutputObject\":\"test-output.flv\",\"TemplateId\":\"testtempalte\",\"UserData\":\"testid-001\"}]";

            //AddImageRequest request = new AddImageRequest();
            //request.InstanceName = "testinstance";
            //request.ProductId = "test";
            //request.PicName = "test";
            //byte[] img = System.IO.File.ReadAllBytes("D:/test.jpg");
            //string pic = Convert.ToBase64String(img);
            //request.PicContent = pic;

            // var items = new List<dynamic> ();

            // dynamic obj = new ExpandoObject ();

            // obj.key = "LightAdjustLevel";
            // obj.value = 1;
            // items.Add (obj);

            // request.ProductKey = "a1LsCUpgf5n";
            // request.DeviceName = "yinxi-test";

            // var jsonItem = JsonConvert.SerializeObject("items");
            // Console.WriteLine(jsonItem);

            // jsonItem = "{LightAdjustLevel:1}";
            // request.Items = jsonItem;

            //var request = new QueryDevicePropertyStatusRequest();
            //request.ProductKey = "a1xplY8eBQT";
            //request.DeviceName = "SzAfkec0rv0RgfdnicbK";

            //var request = new SetDevicePropertyRequest();
            //request.ProductKey = "a1xplY8eBQT";
            //request.DeviceName = "SzAfkec0rv0RgfdnicbK";

            //request.Items = "{\"AlarmText\":\"E7BB93E69D9FE5BE85E69CBAE4B8AD20202020202020202020202020202020202020202020202020202020202030303830202020202020202020202020202020207C4F50454E2054484520444F4F52205448454E20434C4F5345207C\"}";
            // var request = new CreateUploadVideoRequest();
            // request.FileName = "03552d1d9235583a5e20ce3b677ea176.mp4";
            // request.Title = null;

            #endregion

            //            var request = new FindSimilarFacesRequest();

            //            var request = new DescribeAccessPointsRequest();
            //            var filter = new DescribeAccessPointsRequest.Filter();
            //            filter.Key = "RegionId";
            //            filter.Values = new List<string> { "cn-hangzhou" };
            //
            //            var filterList = new List<DescribeAccessPointsRequest.Filter> { filter };
            //
            //            request.Filters = filterList;


            //            CommonRequest request = new CommonRequest();
            //            request.Method = MethodType.POST;
            //            request.Domain = "metrics.cn-hangzhou.aliyuncs.com";
            //            request.Version = "2019-01-01";
            //            request.Action = "DescribeMetricLast";
            //
            //            request.AddQueryParameters("MetricName", "CPUUtilization");
            //            request.AddQueryParameters("Namespace", "acs_ecs_dashboard");

            // request.AddQueryParameters("PhoneNumbers","xx");
            // request.AddQueryParameters("SignName","李刚");
            // request.AddQueryParameters("TemplateCode","xx");
            // request.AddQueryParameters("TemplateParam","{\"code\":\"3433\"}");

            //            var request = new QueryMetricDataRequest();

            //var request = new GetPlayInfoRequest();
            //request.VideoId = "your video id";

            //var log = new LoggerConfiguration()
            //    .Enrich.WithExceptionDetails()
            //    .WriteTo.ColoredConsole(
            //        outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss}] [{Level}] {Message}{NewLine}{Exception}")
            //    .CreateLogger();
            //Log.Logger = log;

            //log.Information("From Client Test.");


            //XmlDocument log4netConfig = new XmlDocument();
            //log4netConfig.Load(File.OpenRead("log4net.config"));

            //var repo = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(),
            //    typeof(log4net.Repository.Hierarchy.Hierarchy));
            //XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
            //ILog log = LogManager.GetLogger(typeof(Program));
            //log.Error("Cleint Error.");


            //var config = new LoggingConfiguration();

            //// Targets where to log to: File and Console
            //var logfile = new FileTarget("logfile") { FileName = "file.txt" };
            //var logconsole = new ConsoleTarget("logconsole");

            //// Rules for mapping loggers to targets            
            //config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            //config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);  

            //// Apply config           
            //LogManager.Configuration = config;
            //var Logger = LogManager.GetCurrentClassLogger();
            //Logger.Info("Test this is from client logger.");

            //DefaultAcsClient.EnableLogger();

            var request = new QueryDeviceGroupListRequest();

            try
            {
                var response = client.GetAcsResponse(request);

                Console.WriteLine(System.Text.Encoding.Default.GetString(response.HttpResponse.Content));
            }
            catch (ServerException e)
            {
                Console.WriteLine(e);
            }
            catch (ClientException e)
            {
                Console.WriteLine(e);
            }
        }

        public static DefaultAcsClient InitVodClient(string accessKeyId, string accessKeySecret)
        {
            var regionId = "cn-shanghai";
            IClientProfile profile = DefaultProfile.GetProfile(regionId, accessKeyId, accessKeySecret);
            return new DefaultAcsClient(profile);
        }
    }
}
