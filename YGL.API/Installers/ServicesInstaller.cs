﻿using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace YGL.API.Installers;

public class ServicesInstaller {
    public void InstallServicesInOrder(IServiceCollection services, IConfiguration configuration) {
        var installers = new List<IInstaller>() {
            new OtherSettingsInstaller(),
            new SwaggerInstaller(),
            new DbInstaller(),
            new EmailInstaller(),
            new JwtInstaller(),

            new PasswordHasherInstaller(),

            new RedisCacheInstaller(),

            new HealthChecksInstaller(),

            new EndpointServicesInstaller(),
        };

        foreach (IInstaller installer in installers)
            installer.InstallServices(services, configuration);
    }
}