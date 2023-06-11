using AutoMapper.Configuration.Conventions;

namespace server.Utility.ApiResponse
{
    public class ReturnResponse 
    {
    
            public int StatusCode { get; set; }

            public Object response { get; set; }

        public ReturnResponse(int statusCode, Object response)
        {
            this.StatusCode = statusCode;
            this.response = response;
        }
    }
}
