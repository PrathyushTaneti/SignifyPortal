using Microsoft.AspNetCore.Mvc.Filters;

namespace server.CustomFilters
{
    public class MySampleAsyncActionFilterAttribute : Attribute, IAsyncActionFilter, IOrderedFilter
    {
        private readonly string name;
        public int Order { get; }


        public MySampleAsyncActionFilterAttribute(string name, int order)
        {
            this.name = name;
            this.Order = order;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await Console.Out.WriteLineAsync($"Before Execution - { this.name }");
            await next();
            await Console.Out.WriteLineAsync($"After Execution - { this.name }");
        }
    }
}
