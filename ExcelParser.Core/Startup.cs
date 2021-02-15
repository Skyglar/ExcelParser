using ExcelParser.Common.ResponseBuilder;
using ExcelParser.Common.ResponseBuilder.Contracts;
using ExcelParser.Common.Validation.Contracts;
using ExcelParser.Core.Services;
using ExcelParser.Core.Services.Contracts;
using ExcelParser.Domain.Repository;
using ExcelParser.Domain.Repository.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;


namespace ExcelParser.Common.Validation
{
    public class Startup
    {
        private readonly string _connectionString;

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _connectionString = Configuration.GetConnectionString("SpreadsheetDb");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<SpreadsheetDbContext>(options =>
            {
                options.UseSqlServer(_connectionString).EnableSensitiveDataLogging();
            });

            services.AddScoped<ISpreadsheetRepository, SpreadsheetRepository>();
            services.AddScoped<IExcelWorkerService, ExcelWorkerService>();
            services.AddScoped<IExcelValidator, ExcelValidator>();
            services.AddScoped<IResponseFactory, ResponseFactory>();
            services.AddScoped<IExcelComparerService, ExcelComparerService>();

            services.AddControllers();
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
