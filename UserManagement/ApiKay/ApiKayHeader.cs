using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;


namespace UserManagement.ApiKay
{
    public class ApiKayHeader : IOperationFilter
    {
        public void Apply(
            OpenApiOperation operation,
            OperationFilterContext context)
        {
            operation.Parameters ??= new List<IOpenApiParameter>();
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "ApiKey",
                In = ParameterLocation.Header,
                Required = true
            });
        }
    }
}
