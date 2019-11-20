using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Localization;

namespace ScaleHQ.AspNetCore.LHQ
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class DependencyInjectionExtensions
    {
        public static void AddTypedStringsLocalizer<TStringLocalizer, TTypedStrings>(this IServiceCollection services)
            where TStringLocalizer : class, IStringLocalizer
            where TTypedStrings : class
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            services.AddOptions();

            services.TryAddSingleton<IStringLocalizerFactory, StringLocalizerFactory>();
            services.TryAddSingleton<IStringLocalizer, TStringLocalizer>();
            services.TryAddSingleton<TTypedStrings>();
        }

        public static IMvcBuilder AddMvcTypedStringsLocalizer(this IMvcBuilder mvcBuilder)
        {
#if NETSTANDARD2_0
            mvcBuilder.Services.Configure<MvcOptions>(options => { options.ModelMetadataDetailsProviders.Add(new DisplayNameDetailsProvider()); });

            mvcBuilder.AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, localizerFactory) => localizerFactory.Create(type);
                });
#endif
            return mvcBuilder;
        }

        public static IApplicationBuilder UseTypedStringsLocalizer<TStringLocalizer, TTypedStrings>(this IApplicationBuilder app)
            where TStringLocalizer : class, IStringLocalizer
            where TTypedStrings : class
        {
            string methodName = typeof(DependencyInjectionExtensions).FullName + "." + nameof(AddTypedStringsLocalizer);

            var stringLocalizer = app.ApplicationServices.GetService<IStringLocalizer>();
            if (stringLocalizer == null)
            {
                throw new InvalidOperationException(
                    $"Service '{typeof(IStringLocalizer)}' was not registered, call method {methodName} in begin of Startup.ConfigureServices()!");
            }

            var stringLocalizerFactory = app.ApplicationServices.GetService<IStringLocalizerFactory>();
            if (stringLocalizerFactory == null)
            {
                throw new InvalidOperationException(
                    $"Service '{typeof(IStringLocalizerFactory)}' was not registered, call method {methodName} in begin of Startup.ConfigureServices()!");
            }

#if NETSTANDARD2_0
            DisplayNameDetailsProvider.SetStringLocalizer(stringLocalizer);
#endif

            // initialize type string object!
            app.ApplicationServices.GetService<TTypedStrings>();

            return app;
        }
    }
}
