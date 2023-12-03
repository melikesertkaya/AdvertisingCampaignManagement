using AdvertisingCampaignManagement.Context;
using AdvertisingCampaignManagement.Services;
using Microsoft.OpenApi.Models;

namespace AdvertisingCampaignManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Bu method, hizmetlerin yapılandırılması için kullanılır.
        public void ConfigureServices(IServiceCollection services)
        {
            // MongoDB bağlantı ayarlarını yapılandırma
            services.Configure<MongoDbSettings>(
                Configuration.GetSection(nameof(MongoDbSettings)));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Advertising Campaign Manager API", Version = "v1" });
            });
            services.AddSingleton<MongoDbContext>();
            services.AddScoped<ICampaignService, CampaignService>();
            services.AddScoped<ICampaignAnalyticsService, CampaignAnalyticsService>();

            services.AddControllers();
        }

        // Bu method, HTTP istekleri ve yanıtları işlemek için kullanılır.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Advertising Campaign Manager API V1");
                // c.RoutePrefix = string.Empty; // Bu satırı kaldırın veya yorum satırına alın
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
