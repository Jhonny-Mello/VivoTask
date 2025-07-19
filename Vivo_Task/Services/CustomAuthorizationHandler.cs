using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Vivo_Task.Models;
using System.Threading.Tasks;

namespace Vivo_Task.Services
{
    public class CustomRequirement : IAuthorizationRequirement
    {
        // Pode ser usado para passar informações adicionais ao AuthorizationHandler, se necessário.
    }
    public class CustomRequirementHandler : AuthorizationHandler<CustomRequirement>
    {
        private UserBasicDetail _userService;

        public CustomRequirementHandler(UserBasicDetail userService)
        {
            _userService = userService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomRequirement requirement)
        {
            // Aqui você pode acessar o contexto do usuário, como context.User, para fazer a verificação.
            // Vamos supor que você tenha o UserService registrado no DI e deseja verificar se o usuário é Suporte.
            try
            {
                if (_userService.IsSuporte())
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }
            }catch { }

            return Task.CompletedTask;
        }
    }

}