using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplication1
{
    public class Startup
    {
        private static float balance = 10000.0f;
        public void Configure(IApplicationBuilder app)
        {
            
            app.Map("/balance", Balance);
            app.Map("/withdraw", Withdraw);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("1. Check balance \n2. Withdraw");
            });
        }

        private static void Withdraw(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                balance = balance - 100;
                await context.Response.WriteAsync($"The balance after withdrawal is {balance}$");
            });
        }
        private static void Balance(IApplicationBuilder app)
        {

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync($"Balance: {balance}$");
            });
        }
    }
}
