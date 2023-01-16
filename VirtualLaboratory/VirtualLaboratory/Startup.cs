using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VirtualLaboratory.DAL;
using VirtualLaboratory.DAL.Interfaces;
using VirtualLaboratory.DAL.Repositories;
using VirtualLaboratory.Service.Implementations;
using VirtualLaboratory.Service.Interfaces;

namespace VirtualLaboratory
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

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<VirtualLaboratoryContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IConstantInLaboratoryWorkRepository, ConstantInLaboratoryWorkRepository>();
            services.AddScoped<IConstantInLaboratoryWorkService, ConstantInLaboratoryWorkService>();

            services.AddScoped<IConstantRepository, ConstantRepository>();
            services.AddScoped<IConstantService, ConstantService>();

            services.AddScoped<IEquipmentParametrRepository, EquipmentParametrRepository>();
            services.AddScoped<IEquipmentParametrService, EquipmentParametrService>();

            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IEquipmentService, EquipmentService>();

            services.AddScoped<IInstallationRepository, InstallationRepository>();
            services.AddScoped<IInstallationService, InstallationService>();

            services.AddScoped<ILaboratoryWorkRepository, LaboratoryWorkRepository>();
            services.AddScoped<ILaboratoryWorkService, LaboratoryWorkService>();

            services.AddScoped<IMistakeInReportRepository, MistakeInReportRepository>();
            services.AddScoped<IMistakeInReportService, MistakeInReportService>();

            services.AddScoped<IPhenomenonInLaboratoryWorkRepository, PhenomenonInLaboratoryWorkRepository>();
            services.AddScoped<IPhenomenonInLaboratoryWorkService, PhenomenonInLaboratoryWorkService>();

            services.AddScoped<IPhenomenonRepository, PhenomenonRepository>();
            services.AddScoped<IPhenomenonService, PhenomenonService>();

            services.AddScoped<IProcessInPhenomenonRepository, ProcessInPhenomenonRepository>();
            services.AddScoped<IProcessInPhenomenonService, ProcessInPhenomenonService>();

            services.AddScoped<IProcessRepository, ProcessRepository>();
            services.AddScoped<IProcessService, ProcessService>();

            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IReportService, ReportService>();

            services.AddScoped<ITheoreticalInformationForLaboratoryWorkRepository, TheoreticalInformationForLaboratoryWorkRepository>();
            services.AddScoped<ITheoreticalInformationForLaboratoryWorkService, TheoreticalInformationForLaboratoryWorkService>();

            services.AddScoped<ITheoreticalInformationRepository, TheoreticalInformationRepository>();
            services.AddScoped<ITheoreticalInformationService, TheoreticalInformationService>();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
