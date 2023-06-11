namespace server.Utility.ApiResponse
{
    public interface IResponse
    {
        ReturnResponse returnResponse(int statusCode, Object objectR);
    }

}
