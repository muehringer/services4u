using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Cors;
using System.Web.Cors;
using Microsoft.Owin.Security.OAuth;
using Swashbuckle.Application;
using Base.Services.Security;
using SimpleInjector.Integration.WebApi;
using SimpleInjector;
using Base.IoC.App_Start;
using Base.Application.Adapters.ObjectMappers;

namespace Base.Services
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            //Configuração Swagger
            config.EnableSwagger(c => {
                c.SingleApiVersion("v1", "Base.Services");

            })
            .EnableSwaggerUi();
            
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //usado para liberar o CORS para todos os dominios 
            app.UseCors(CorsOptions.AllowAll);
            //ou usar o metodo abaixo para configuracoes especificas para cada dominio
            //se optar pela primeira opcao de liberar tudo, basta descomentar a primeira linha e apagar o metodo ConfigureCors
            //ConfigureCors(app);
            AtivandoAccessTokens(app);

            //Configuracao do SimpleInjector para injecao de dependencia
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new SimpleInjector.Lifestyles.AsyncScopedLifestyle();

            InitializeContainer(container);
            container.RegisterWebApiControllers(config);
            container.Verify();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            //Inicializacao do AutoMapper
            AutoMapperConfig.RegisterMappings();

            app.UseWebApi(config);
        }

        private void ConfigureCors(IAppBuilder app)
        {
            var politica = new CorsPolicy();

            politica.AllowAnyHeader = true;
            politica.Origins.Add("http://localhost:40874");
            politica.Origins.Add("http://localhost:40880");
            politica.Methods.Add("GET");
            politica.Methods.Add("POST");

            var corsOptions = new CorsOptions
            {
                PolicyProvider = new CorsPolicyProvider
                {
                    PolicyResolver = context => Task.FromResult(politica)
                }
            };

            app.UseCors(corsOptions);
        }

        private void AtivandoAccessTokens(IAppBuilder app)
        {
            //configurando fornecimento de tokens
            var opcoesConfiguracaoToken = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true, //ambiente de produção deve ser false
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                Provider = new ProviderTokensAcesso()
            };

            app.UseOAuthAuthorizationServer(opcoesConfiguracaoToken);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        public static void InitializeContainer(Container container)
        {
            BootStrapper.Register(container);
        }
    }
}
