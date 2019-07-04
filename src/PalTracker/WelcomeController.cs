using Microsoft.AspNetCore.Mvc;

namespace PalTracker
{
    [Route("/")]
    public class WelcomeController : ControllerBase
    {
        WelcomeMessage welcomemsg;

        public WelcomeController(WelcomeMessage welmsg_arg)
        {
            welcomemsg = welmsg_arg;
        }
        [HttpGet()]
        public string SayHello() 
        {
            /*             
            System.Diagnostics.Debug.WriteLine("#Request.Path  = " + Request.Path );
            System.Diagnostics.Debug.WriteLine("#Request.Host  = " + Request.Host);
            System.Diagnostics.Debug.WriteLine("#Request.Query  = " + Request.Query );
            */
            return welcomemsg.message;
        } 
    }
}
