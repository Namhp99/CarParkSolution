using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Models.Authentication;
using Models.DTO;
using Models.EF;
using Models.Entities;
using Models.GenericRepository;
using Models.GenericRespository;
using Models.Repository.Implement;
using Models.Repository.Interfaces;
using Models.UnitofWorks;
using Services;
using Services.ImplementService;
using Services.InterfaceService;
using Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI
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
            services.AddDbContext<CarParkDbContext>(options => options.UseSqlServer(Configuration.GetValue<string>("ConnectionStrings:CarParkDb")));
            /////
            services.AddDbContext<CarParkDbContext>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IBookingOfficeRepository, BookingOfficeRepository>();
            services.AddTransient<IParkinglotRepository, ParkinglotRepository>();
            services.AddTransient<ITripRepository, TripRepository>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IGenericRepository<Trip>, GenericRepository<Trip>>();
            services.AddTransient<IGenericRepository<Employee>, GenericRepository<Employee>>();
            services.AddTransient<IGenericRepository<BookingOffice>, GenericRepository<BookingOffice>>();
            services.AddTransient<IGenericRepository<Parkinglot>, GenericRepository<Parkinglot>>();
            services.AddTransient<IGenericRepository<Ticket>, GenericRepository<Ticket>>();
            services.AddTransient<IGenericRepository<Car>, GenericRepository<Car>>();
            //
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IParkinglotService, ParkinglotService>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<ITripService, TripService>();
            services.AddTransient<IBookingOfficeService, BookingOfficeService>();
            //

            services.AddControllers();
            services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
            services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<CarParkDbContext>()
                .AddDefaultTokenProviders();
            //
            string issuer = Configuration.GetValue<string>("JWT:ValidIssuer");
            string signingKey = Configuration.GetValue<string>("JWT:Secret");
            byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);
            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication2", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
            });
            //AutoMap
            var config = new AutoMapper.MapperConfiguration(c =>
            {
                c.AddProfile(new ApplicationProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
