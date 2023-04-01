namespace asp07
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Đăng ký các dịch vụ liên quan đến Razor, Razor Page
            services.AddRazorPages();

        }

        // IHostingEnvironment  env cho phép truy cập các biến môi trường, thư mục nguồn, thư mục file.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages(); // khi chúng ta thiết lập maprazorpage, thì nó tìm trên toàn bộ cái mã nguồn những trang razor page cshtml, và nó sử dụng những trang này như là một endpoint.
                // FirstPage.cshtml, and set up URL= /FirstPage.
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
/*
    Razor page(.cshtml) = html + C#
    Engine Razor ->compile ->Response
*/