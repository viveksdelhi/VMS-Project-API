using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using VMS_Project_API.AppCode;
using VMS_Project_API.Entities;
using VMS_Project_API.Service;

namespace VMS_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhatsAppController : ControllerBase
    {
        [HttpGet("opt-in")]
        public async Task<string> WhatsappOptIn(string mobile)
        {


            WhatsAppModel wModel = new WhatsAppModel();

            wModel.SendTo = mobile; // Replace with the phone number you want to opt in
            wModel.AuthSchema = "plain";
            wModel.Channel = "WHATSAPP";
            wModel.Version = "1.1";
            wModel.Format = "json";
            wModel.Method = "OPT_IN";
            return await WhatsAppService.OptIn(wModel);

        }

        [HttpGet("send-template")]
        public async Task<string> WhatsappSendTemplate(string mobile, string? templateId = null)
        {

            if (!string.IsNullOrEmpty(templateId))
            {
                templateId = "7160232";
            }
            WhatsAppModel wModel = new WhatsAppModel();

            wModel.SendTo = mobile; // Replace with the phone number you want to opt in
            wModel.AuthSchema = "plain";

            wModel.Version = "1.1";

            wModel.Method = "SendMessage";
            wModel.Message = "this is test template message";
            return await WhatsAppService.SendTemplate(wModel);

        }

        [HttpGet("send-message")]
        public async Task<string> WhatsappSendMessage(string mobile, string message)
        {


            WhatsAppModel wModel = new WhatsAppModel();

            wModel.SendTo = mobile; // Replace with the phone number you want to opt in
            wModel.AuthSchema = "plain";

            wModel.Version = "1.1";
            wModel.MessageType = "DATA_TEXT";
            wModel.Method = "SendMessage";
            wModel.Message = message;
            return await WhatsAppService.SendMessage(wModel);

        }
    }
}
