using Microsoft.Extensions.DependencyInjection;
using TeamManagementApp.Interfaces;
using TeamManagementApp.Repository;
using TeamManagementApp.Service;

namespace TeamManagementApp
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITeamMemberService, TeamMemberService>();
            services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
            services.AddScoped<IInterestService, InterestService>();
            services.AddScoped<IInterestRepository, InterestRepository>();
            services.AddScoped<ITeamInfoService, TeamInfoService>();
            services.AddScoped<ITeamInfoRepository, TeamInfoRepository>();
            services.AddScoped<IMarkService, MarkService>();
            services.AddScoped<IMarkRepository, MarkRepository>();

            return services;
        }
    }
}
