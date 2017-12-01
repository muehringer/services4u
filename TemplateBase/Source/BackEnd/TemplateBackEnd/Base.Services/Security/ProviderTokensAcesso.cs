using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Base.Services.Security
{
    public class ProviderTokensAcesso : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext contextAuthentication)
        {
            contextAuthentication.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext contextAuthentication)
        {
            var usuario = BaseUsuariosTeste.Usuarios().FirstOrDefault(x => x.Nome == contextAuthentication.UserName && x.Senha == contextAuthentication.Password);

            //cancelando a emissao do token se o usuario nao for encontrado
            if (usuario == null)
            {
                contextAuthentication.SetError("invalid_grant", "Usuário não encontrado ou senha incorreta");

                return;
            }

            //emitindo token com informacoes extras se o usuario existe
            var identidadeUsuario = new ClaimsIdentity(contextAuthentication.Options.AuthenticationType);

            contextAuthentication.Validated(identidadeUsuario);
        }
    }
}