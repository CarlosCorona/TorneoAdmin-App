using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using TorneosAdmin.Web.Models;

namespace TorneosAdmin.Web.Autorizacion
{
    public class UsuariosAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Usuarios>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
                                                       OperationAuthorizationRequirement requirement, 
                                                       Usuarios resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            // Administrators can do anything.
            if (context.User.IsInRole("Administrador"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
