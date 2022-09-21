using business.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Services
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
            .AddJsonOptions(options =>
              {
                  options.JsonSerializerOptions.IgnoreNullValues = true;
              });

            // injection
            services.AddScoped<ITasksHandler, TasksHandler>();


            services.AddCors();
            services.AddControllers();
            services.AddRouting();
            services.AddHttpClient();

            //cấu hình kết nối db
            services.AddDbContext<MyProjectDBContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("Server"));
            });

            
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddHttpContextAccessor();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // mở khoá http
            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
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