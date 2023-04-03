using Microsoft.AspNetCore.Mvc.RazorPages;

public class FirstPageModel : PageModel
{
     public string title{set; get;} = "Day la Trang Razor cua Phan Minh Tien";
      //Nếu muốn thì chúng ta có thể mở ra nhiều khối function
 

    //OnGet, OnGetAbc, OnGetXyz,..
    //OnPost(), OnPostAbc(),...
    //Những phương thức như trên gọi là Handler
    public void OnGet(){
        //Phương thưc OnGet được gọi khi truy vấn đến trang địa chỉ mặc định với phương thức GET
        Console.WriteLine("Truy van GET");
        ViewData["mydata"] = "Xuanthulap.net 2023";
    }
    //GET, Url?handler=Xyz
    public void OnGetXyz(){
        Console.WriteLine("Truy van OnGetXyz");
        ViewData["mydata"] = "Xuanthulap.net 2023 XYZ";
    }
    public string welcome(string name){
        return $"Chao mung {name} den voi Website";
    } 
}