using System;
namespace Business.Configuration.Cache
{
    public class RedisEndpointInfo
    {
       
            public string EndPoint { get; set; }
            public int Port { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
        
    }
}
