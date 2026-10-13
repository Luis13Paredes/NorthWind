internal static class Startup
{
    public static WebApplication CreateWebApplication(
        this WebApplicationBuilder builder)
    {
        // Configurar APIExplorer para descubrir y exponer
        // los metadatos de los endpoints de la aplicación.
        builder.Services.AddEndpointsApiExplorer();

        // Agregar el generador que construye los objetos de
        // documentación de Swagger con la funcionalidad del APIExplorer,
        // habilitando el soporte de autenticación Bearer.
        builder.Services.AddSwaggerGenBearer();

        // Registrar los servicios de la aplicación
        builder.Services.AddNorthWindSalesServices(
            dbObtions =>
                builder.Configuration.GetSection(DBOptions.SectionKey)
                .Bind(dbObtions),
            smtpOptions =>
                builder.Configuration.GetSection(SmtpOptions.SectionKey)
                .Bind(smtpOptions),
            membershipDBOptions =>
                builder.Configuration.GetSection(MembershipDBOptions.SectionKey)
                .Bind(membershipDBOptions),
            jwtOptions =>
                builder.Configuration
                .GetSection(JwtOptions.SectionKey)
                .Bind(jwtOptions));

        // Agregar el servicio CORS para clientes que se ejecutan
        // en el navegador Web (como Blazor WebAssembly).
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(config =>
            {
                config.AllowAnyMethod();
                config.AllowAnyHeader();
                config.AllowAnyOrigin();
            });
        });

        // Registrar el proveedor de autenticación JWT Bearer.
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                // Establecer la configuración del Token.
                builder.Configuration.GetSection(JwtOptions.SectionKey)
                    .Bind(options.TokenValidationParameters);

                // Establecer la llave para validación de la firma.
                string SecurityKey = builder.Configuration
                    .GetSection(JwtOptions.SectionKey)[nameof(JwtOptions.SecurityKey)]!;

                byte[] SecurityKeyBytes = Encoding.UTF8.GetBytes(SecurityKey);

                options.TokenValidationParameters.IssuerSigningKey =
                    new SymmetricSecurityKey(SecurityKeyBytes);
            });

        builder.Services.AddAuthorization();

        return builder.Build();
    }

    public static WebApplication ConfigureWebApplication(
        this WebApplication app)
    {
        app.UseExceptionHandler(builder => { });

        app.UseAuthentication();
        app.UseAuthorization();

        // Habilitar el middleware para servir el documento
        // JSON generado y la interfaz UI de Swagger en el
        // ambiente de desarrollo.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // Registrar los endpoints de la aplicación
        app.MapNorthWindSalesEndpoints();

        // Agregar el Middleware CORS
        app.UseCors();

        return app;
    }
}
