namespace asp07
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Đăng ký các dịch vụ liên quan đến Razor, Razor Page
            // services.AddRazorPages();
            //Để thay đổi trang chỉ mặc định là Pages thành địa chỉ khác ta dùng lệnh như sau:
            services.AddRazorPages().AddRazorPagesOptions(options => {
                options.RootDirectory = "/Pages";
                //Truy cập vào trang First Page với một URL mới mà ta tự đặt
                options.Conventions.AddPageRoute("/FirstPage", "/trang-dau-tien.html");
                options.Conventions.AddPageRoute("/SecondPage", "/test2");
            });
            //Để thiết lập đường dẫn URL thành chữ thường hết thì chúng ta sẽ cấu hình nhuư sau:
            services.Configure<RouteOptions>(routeOptions => {
                  routeOptions.LowercaseUrls = true;
            });

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
                // FirstPage.cshtml, and set up URL= /FirstPage.  /SecondPage  /ThirdPage
                //Thì lúc này endpoint middleware sẽ tạo ra các địa chỉ các điểm endpoint truy cập đến tên thư mục 
                //Dichvu/Dichvu1
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
    -@page "url"
    -Để xuất ra 1 giá trị của biến ở file .cshtml thì ta dùng @tenbien, hoặc @biểuthức, hoặc gọi một phương thức nào đó của C# (@phươngthuwcs)
    - Trong file cshtml chúng ta có thể nhúng file c# vào bằng cách:
    @{
        //Vietcode C#
        Nếu chúng ta mở thẻ <HTML></HTML> thì có nghĩa là chúng ta đang nhúng code html vào C#
        Thì như vậy mặc định thì con endpoint Routing được tạo theo endpoint của địa chỉ mặc định là tên của các file Razor
    }
    chúng ta sử dụng cấu hình đó để viết lại địa chỉ URL truy cập đến Razor Page thì chúng ta gọi là:
    Rewrite URL 

    để hỗ trợ phát sinh ra trang html thì nó dùng:
    Tag Helper -> cú pháp để phát sinh HTML
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers dùng để nạp các trang helper vào razor page
*/