using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DragonQuestNine.Models;
using DragonQuestNine.Services.Accolades;
using DragonQuestNine.Repositories.Accolades;
using DragonQuestNine.Persistance.Contexts;
using DragonQuestNine.Repositories.UnitOfWork;

namespace DragonQuestNine
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var connectionString = Configuration["connectionStrings:dragonQuestDbString"];
            services.AddDbContext<DragonQuestDbContext>(c => c.UseSqlServer(connectionString));

            services.AddScoped<IAccoladeRepository, AccoladeRepository>();
            services.AddScoped<IAccoladeService, AccoladeService>();
            services.AddScoped<IAccoladeCategoryRepository, AccoladeCategoryRepository>();
            services.AddScoped<IAccoladeCategoryService, AccoladeCategoryService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
