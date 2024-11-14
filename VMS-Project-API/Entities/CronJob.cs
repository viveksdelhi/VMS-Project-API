using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS_Project_API.AppCode;
using VMS_Project_API.Service;

namespace VMS_Project_API.Entities
{
    public class CronJob
    {
        private Timer timer;

        public void Start()
        {
            timer = new Timer(async _ => await ExecuteTask(), null, TimeSpan.Zero, TimeSpan.FromMinutes(10));
        }

        private async Task ExecuteTask()
        {
            // Create WhatsAppModel object with necessary data
            var wModel = new WhatsAppModel
            {
                SendTo = "6201941071", // Receiver's phone number
                Message = "Auto-generated message from cron job", // Message content
                Method = "SendMessage",
                AuthSchema = "plain",
                Version = "1.1",
                MessageType = "DATA_TEXT"
            };

            // Call the WhatsAppService.SendMessage method
            var response = await WhatsAppService.SendMessage(wModel);
            Console.WriteLine($"CronJob executed. Response: {response}");
        }

        public void Stop()
        {
            timer?.Change(Timeout.Infinite, 0);
        }
    }

    //public CronJob()
    //{        // Create a timer that runs the CheckSchedule method every second
    //    timer = new Timer(CheckSchedule, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

    //}

    //private void CheckSchedule(object state)
    //{
    //    DateTime now = DateTime.Now;

    //    //if(now.Second.ToString().Contains("0"))
    //    //{
    //    //    Console.WriteLine("Task executed every 10 seconds: " + now);
    //    //}

    //    if (now.Second == 0)
    //    {

    //        //string apiUrl = GlobalModel.BaseURL.Trim('/') + "/default/api/update-api-users"; // Replace with your API URL
    //        //string response = new HttpClient().GetStringAsync(apiUrl).Result;

    //    }

    //}



}

