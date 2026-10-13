# NorthWind Sales — Guía de instalación para el equipo

Este repositorio contiene **dos soluciones .NET separadas** que trabajan juntas:

- `NorthWind/` — la solución principal (Web API + Blazor WebAssembly + Clean Architecture).
- `NorthWind.Membership/` — framework de membresía (registro/login/JWT) empaquetado como paquetes NuGet locales que consume la solución principal.
- `NorthWind.Packages/` — carpeta que actúa como "feed" NuGet local. Aquí se depositan los `.nupkg` generados desde `NorthWind.Membership` (y algunos proyectos de `NorthWind`) para que la solución principal los consuma como si vinieran de nuget.org.

**Las tres carpetas deben quedar como hermanas**, exactamente así:

```
TuCarpeta\
├── NorthWind\
├── NorthWind.Membership\
└── NorthWind.Packages\
```

Si copian/comparten el proyecto, copien las tres carpetas juntas, manteniendo esa estructura relativa. Los archivos `nuget.config` de cada solución ya apuntan a `..\NorthWind.Packages` (ruta relativa), así que funciona sin importar en qué disco o carpeta raíz lo coloquen, siempre que las tres sigan siendo hermanas.

No hay repositorio Git todavía — si van a colaborar como equipo, lo más práctico es crear uno (GitHub/GitLab) con las tres carpetas en la raíz, en vez de pasarse el ZIP manualmente. (`NorthWind.Packages` se puede incluir en el repo tal cual, son solo ~8 paquetes ya compilados, o puede regenerarse — ver más abajo).

## 1. Requisitos de software (cada integrante)

1. **.NET 10 SDK** — https://dotnet.microsoft.com/download/dotnet/10.0
   Verifica con: `dotnet --version` (debe mostrar 10.x)
2. **SQL Server LocalDB** — viene incluido con Visual Studio, o se instala solo con "SQL Server Express LocalDB" (https://learn.microsoft.com/sql/database-engine/configure-windows/sql-server-express-localdb). El proyecto usa la instancia `(localdb)\mssqllocaldb`.
3. **Herramienta `dotnet-ef`** (para aplicar migraciones):
   ```
   dotnet tool install --global dotnet-ef --version 10.0.12
   ```
   (si ya la tienen instalada con otra versión: `dotnet tool update --global dotnet-ef --version 10.0.12`)
4. **No se necesita Visual Studio** — todo el proyecto se maneja por CLI (`dotnet build`, `dotnet run`, `dotnet ef`). Cualquier editor (VS Code, Rider, etc.) sirve para ver/editar el código.

## 2. Primer build

Los paquetes NuGet locales (`NorthWind.Packages\*.nupkg`) ya vienen compilados y listos — **no es necesario reconstruir `NorthWind.Membership` para empezar**. Solo hace falta compilar la solución principal:

```
cd NorthWind
dotnet restore
dotnet build
```

Debe terminar con `0 Advertencia(s), 0 Errores`.

(Opcional, solo si van a modificar algo dentro de `NorthWind.Membership`: ver la sección 5 más abajo sobre cómo regenerar los paquetes.)

## 3. Bases de datos

El proyecto usa **3 bases de datos** independientes en LocalDB, cada una con sus propias migraciones ya incluidas en el código:

| Base de datos | DbContext | Proyecto donde viven las migraciones |
|---|---|---|
| `NorthWindDB` | `NorthWindSalesContext` | `NorthWind\4. Frameworks And Drivers\Frameworks\DataContexts\NorthWind.Sales.Backend.DataContexts.EFCore` |
| `NorthWindLogsDB` | `NorthWindDomainLogsContext` | mismo proyecto, carpeta `Migrations\DomainLogs` |
| `NorthWindUsersDB` | `NorthWindMembershipContext` | `NorthWind.Membership\NorthWind.Membership.Backend.AspNetIdentity` |

`NorthWindDB` ya incluye datos semilla (clientes y productos de prueba, p. ej. cliente `ALFKI` y productos `1,3,4,5`) a través de la migración `AddProductAndCustomer`, así que no hace falta ningún script `.sql` aparte.

Ejecuta estos 3 comandos desde la carpeta `NorthWind` (la raíz de la solución principal):

```
dotnet ef database update -p "4. Frameworks And Drivers\Frameworks\DataContexts\NorthWind.Sales.Backend.DataContexts.EFCore" -s "4. Frameworks And Drivers\Frameworks\DataContexts\NorthWind.Sales.Backend.DataContexts.EFCore" -c NorthWindSalesContext

dotnet ef database update -p "4. Frameworks And Drivers\Frameworks\DataContexts\NorthWind.Sales.Backend.DataContexts.EFCore" -s "4. Frameworks And Drivers\Frameworks\DataContexts\NorthWind.Sales.Backend.DataContexts.EFCore" -c NorthWindDomainLogsContext
```

Y este, desde la carpeta `NorthWind.Membership`:

```
cd ..\NorthWind.Membership
dotnet ef database update -p NorthWind.Membership.Backend.AspNetIdentity -s NorthWind.Membership.Backend.AspNetIdentity
```

Verifica que las 3 bases existan:
```
sqlcmd -S "(localdb)\mssqllocaldb" -Q "SELECT name FROM sys.databases WHERE name LIKE 'NorthWind%'"
```
Debe listar `NorthWindDB`, `NorthWindLogsDB`, `NorthWindUsersDB`.

## 4. Configuración / secretos a revisar

Archivo: `NorthWind\4. Frameworks And Drivers\UI\NorthWind.Sales.WebApi\appsettings.json`

- **`SmtpOptions`**: trae las credenciales reales de **mi cuenta personal de Mailtrap** (sandbox de correo de pruebas). Si tu equipo usa este mismo archivo, todos los correos de prueba ("Orden especial creada") llegarán a **mi** bandeja de Mailtrap, no a algo compartido. Para que cada quien vea sus propios correos de prueba, cada integrante debería crear su propia cuenta gratuita en https://mailtrap.io y reemplazar `SmtpHost`/`SmtpHostPort`/`SmtpUserName`/`SmtpPassword` con los suyos. No es un secreto "peligroso" (es un sandbox que no envía correos reales), pero sí es personal.
- **`JwtOptions.SecurityKey`**: es un valor de ejemplo del curso (`KeyMustBeAtLeast32CharactersLong`), no un secreto real — está bien dejarlo igual para todos mientras sea solo para desarrollo/pruebas locales.

## 5. Ejecutar la aplicación

Se necesitan **dos terminales** simultáneas:

**Terminal 1 — Web API:**
```
cd NorthWind\4. Frameworks And Drivers\UI\NorthWind.Sales.WebApi
dotnet run
```
Debe quedar escuchando en `http://localhost:5103` (Swagger en `http://localhost:5103/swagger`).

**Terminal 2 — Blazor Client:**
```
cd NorthWind\4. Frameworks And Drivers\UI\NorthWind.Sales.BlazorClient
dotnet run
```
Debe quedar escuchando en `http://localhost:5249`.

Abre `http://localhost:5249` en el navegador. El cliente Blazor ya está configurado (`wwwroot/appsettings.json`) para apuntar al Web API en `http://localhost:5103`.

Para probar el flujo completo: `Crear cuenta` → `Iniciar sesión` → `Crear orden`.

## 6. Si alguien modifica código dentro de `NorthWind.Membership`

Como esos 4 proyectos se consumen como paquetes NuGet locales (no como referencia de proyecto directa), cualquier cambio ahí requiere **regenerar el paquete y limpiar la caché local de NuGet** antes de que la solución principal lo vea:

```
cd NorthWind.Membership
dotnet pack <Proyecto>\<Proyecto>.csproj -o ..\NorthWind.Packages --include-source
```

Y luego, en cada máquina que vaya a usar ese cambio, borrar la copia cacheada (NuGet no detecta que un paquete con la misma versión 1.0.0 cambió de contenido):

```
rmdir /s /q "%USERPROFILE%\.nuget\packages\<nombre-del-paquete-en-minusculas>\1.0.0"
```
(en PowerShell: `Remove-Item -Recurse -Force "$env:USERPROFILE\.nuget\packages\<nombre-del-paquete-en-minusculas>\1.0.0"`)

Luego `dotnet restore` en la solución principal.

Proyectos que generan paquetes (y su carpeta):
- `NorthWind.Membership\NorthWind.Membership.Entities`
- `NorthWind.Membership\NorthWind.Membership.Backend.Core`
- `NorthWind.Membership\NorthWind.Membership.Backend.AspNetIdentity`
- `NorthWind.Membership\NorthWind.Membership.Frontend.RazorViews`
- `NorthWind\1. Enterprise Business Rules\NorthWind.Validation.Entities`
- `NorthWind\1. Enterprise Business Rules\NorthWind.HttpDelegatingHandlers`
- `NorthWind\1. Enterprise Business Rules\NorthWind.Result.Entities`
- `NorthWind\3. Interface Adapters\Views\NorthWind.RazorComponents`
