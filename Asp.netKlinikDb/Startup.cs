﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Asp.netKlinikDb.DAL;
using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Helper;
using Asp.netKlinikDb.Models;
using EmailService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace Asp.netKlinikDb
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
           services.AddMvc(options =>
           options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(options => {
               options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
               options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
               options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
               options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

           });
            var EmailConfig = Configuration
                .GetSection("EmailConfirguration")
                .Get<EmailConfirguration>();
                services.AddSingleton(EmailConfig);
                services.AddScoped<IEmailSender, EmailSender>();


                services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
           

            
            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<AppDbContext>();

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            }
            );
            services.AddSwaggerGen(c =>
            {
               
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Dental Clinic API",
                    Version = "v1",
                    Description = "Description for the API goes here.",
                });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                {
                    Description = "JWT Authorization header \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { } }
                });
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            services.AddTransient<IBarang, BarangDAL>();
            services.AddTransient<IUser, UserDAL>();
            services.AddTransient<IUserRole, UserRoleDAL>();
            services.AddTransient<IKatBarang, KatBarangDAL>();
            services.AddTransient<ITenant, TenantDAL>();
            services.AddTransient<IPengguna, PenggunaDAL>();
            services.AddTransient<ITenantPengguna, TenantPenggunaDAL>();
            services.AddTransient<IBeli, BeliDAL>();
            services.AddTransient<IJenisTindakan, JenisTindakanDAL>();
            services.AddTransient<IKatJenis, KatJenisDAL>();
            services.AddTransient<IDetailBeli, DetailBeliDAL>();
            services.AddTransient<IDetailPasien, DetailPasienDAL>();
            services.AddTransient<IDetailPegawai, DetailPegawaiDAL>();
            services.AddTransient<IProsentase, ProsentaseDAL>();
            services.AddTransient<ITransaksi, TransaksiDAL>();
            services.AddTransient<ITindakan, TindakanDAL>();
            services.AddTransient<IPenggajian, PenggajianDAL>();
            services.AddTransient<IJual, JualDAL>();    
            services.AddTransient<IposisiGigi, posisiGigiDAL>();
            services.AddTransient<IpilihGIgi, pilihGIgiDAL>();
            services.AddTransient<IDetailPenggajian, DetailPenggajianDAL>();
           
            services.AddCors();
            services.AddCors();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(1);
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
            app.UseDeveloperExceptionPage();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseStaticFiles();   
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dental Klinik API V1");

            });

        }
    }
}
