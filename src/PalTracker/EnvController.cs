using Microsoft.AspNetCore.Mvc;


namespace PalTracker
{
    [Route("/Env")]
    public class EnvController : ControllerBase
    {
        CloudFoundryInfo cloudinfo;
        public EnvController( CloudFoundryInfo _cloudinfo)
        {
            cloudinfo = _cloudinfo;
        }
        
        [HttpGet]
        public CloudFoundryInfo Get()
        {
            return cloudinfo;
        }
    }
}