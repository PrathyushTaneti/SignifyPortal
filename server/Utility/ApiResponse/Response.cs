namespace server.Utility.ApiResponse
{
    public class Response : IResponse
    {
        public ReturnResponse returnResponse(int statusCode, Object objectR)
        {
            return new ReturnResponse(statusCode, objectR);
        }
    }
}
