using Microsoft.AspNetCore.SignalR;

namespace RealTimeTasks.Web
{
    public class TaskHub : Hub
    {
        public void Task()
        {
            Console.WriteLine("In Hub!");
        }

        //public void NewUser()
        //{
        //    Clients.Caller.SendAsync("allstatus", )
        //}
    }
}
