using Microsoft.AspNetCore.Mvc.Filters;

namespace server.CustomFilters
{
    public class MySampleFilterAttribute : Attribute, IActionFilter, IOrderedFilter
    {
        private readonly string name;
        public int Order { get; }


        public MySampleFilterAttribute(string name, int order)
        {
            this.name = name;
            this.Order = order;
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"\nAction Ended\n - {this.name}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"\nAction Is Executing\n - {this.name}");
        }
    }
}
