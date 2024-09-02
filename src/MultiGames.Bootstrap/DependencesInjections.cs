using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MultiGames.Application.Authentication.Repository;
using MultiGames.Application.Authorization.Repository;
using MultiGames.Application.IUofW;
using MultiGames.Application.Mappings;
using MultiGames.Domain.Entities;
using MultiGames.Domain.Validations;
using MultiGames.Infra.Authentication.Repository;
using MultiGames.Infra.Authorization.Repository;
using MultiGames.Infra.DataBase.Context;
using MultiGames.Infra.UofW;

namespace MultiGames.Bootstrap;

public static class DependencesInjections
{
    public static void Dependens(IServiceCollection services, 
                                 string connection, 
                                 string connectionIdentity)
    {
        //configura DbContext-----------------------------------------------------------

        services.AddDbContext<MultiGamesContext>(options =>
         options.UseSqlServer(connection, b =>
               b.MigrationsAssembly("MultiGames.Infra")));
        //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        //-------------------------------------------------------------------------------


        //configura IdentityDbContext----------------------------------------------------

        services.AddDbContext<MultiGamesIdentity>(options =>
         options.UseSqlServer(connectionIdentity, b =>
               b.MigrationsAssembly("MultiGames.Infra")));
                //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        services.AddIdentityCore<IdentityUser>(options =>
         options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<MultiGamesIdentity>();
                
        services.Configure<IdentityOptions>(options =>
        {
            // Default Password settings.
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;
        });
     
        services.Configure<PasswordHasherOptions>(option =>
        {
            option.IterationCount = 12000;
        });
        //--------------------------------------------------------------------------------


        //configura Automaper-------------------------------------------------------------

        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });
        IMapper mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);
        //--------------------------------------------------------------------------------


        services.AddScoped<IValidator<BrotherDomain>, BrotherDomainValidator>();
        services.AddScoped<IValidator<AddressDomain>, AddressDomainValidator>();
        services.AddScoped<IValidator<GameDomain>, GameDomainValidator>();
        services.AddScoped<IAuthorizationRepository, AuthorizationRepository>();
        services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
