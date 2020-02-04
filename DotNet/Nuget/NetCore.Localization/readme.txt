----------------------------------------------------------------------
---- ScaleHQ LHQ Editor Support Library for ASP.NET Core platform ----
----------------------------------------------------------------------

This Nuget package contains support for ASP.NET Core platform.

This library is required to successfully use C# classes generated from Visual Studio Extension - 'Localization HQ Editor'.
Visual Studio Extension - 'Localization HQ Editor' is required for this library to be useful.

For example how to use this library, you can:

1) Add new project 'ASP.NET Core Web Application MVC with LHQ' within 'Localization HQ Editor' group.
   Then follow instructions in readme.html within project


2) Manual update in your ASP.NET Core application files:

	File Startup.cs, method ConfigureServices(IServiceCollection services):
	- as first line of this method add this line:
	  services.AddTypedStringsLocalizer<StringsModelLocalizer, StringsModel>();

	- add following line in the services.AddMvc() call chain:
	  .AddMvcTypedStringsLocalizer()
	  
	  so AddMvc() call chain will looks like:
	    services.AddMvc()
			.AddMvcTypedStringsLocalizer()
			.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

	File Startup.cs, method Configure(IApplicationBuilder app, IHostingEnvironment env):
	- after app.UseMvc(...) call, add this line:
	  app.UseTypedStringsLocalizer<StringsModelLocalizer, StringsModel>();


For more info about Localization HQ Editor, visit official web site:
https://www.lhqeditor.com