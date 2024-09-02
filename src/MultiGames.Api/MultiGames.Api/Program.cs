using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MultiGames.Bootstrap;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
   
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "MultiGamesApi",
        Description = "Uma API Web ASP.NET Core para gerir itens MultiGames",
        TermsOfService = new Uri("https://www.taskplangerenciamento.com"),
        Contact = new OpenApiContact
        {
            Name = "Contato",
            Url = new Uri("https://br.linkedin.com/in/andredobbss?trk=profile-badge")
        },
        License = new OpenApiLicense
        {
            Name = "Licença",
            Url = new Uri("https://www.taskplangerenciamento.com/wp-content/uploads/2021/05/1-Institucional__TaskPlan_Construcao_REV01.pdf")
        }
    });


    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Baearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Header de autorização JWT usando o esquema Bearer, \r\n\r\nInforme 'Bearer' [espaço] e o seu Token, \r\n\r\nExemplo: \'Bearer 123456abcdefg\'",
    });


    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
          new OpenApiSecurityScheme
          {
             Reference = new OpenApiReference
             {
                  Type = ReferenceType.SecurityScheme,
                  Id = "Bearer"
             }
          },
           new string[] {}
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});





//configura contairner--------------------------------------------------------------------------------


string connection = builder.Configuration.GetConnectionString("MultiGamesConnection");

string connectionIdentity = builder.Configuration.GetConnectionString("MultiGamesConnectionIdentity");

DependencesInjections.Dependens(builder.Services, connection, connectionIdentity);
//----------------------------------------------------------------------------------------------------


// configura JWT Bearer Token

builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme).
    AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidAudience = builder.Configuration["TokenConfiguration:Audience"],
        ValidIssuer = builder.Configuration["TokenConfiguration:Issuer"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    });
//------------------------------------------------------------------------------------------------------------------


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapControllers();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
