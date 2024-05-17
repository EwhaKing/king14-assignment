using System;

class Hello
{
    public delegate string HelloDelegate(string name);
    
    public static string introduce(string name){
        return ("My name is "+name);
    }
    
    public void OnButtonClick(object sender, EventArgs e){
        Console.WriteLine("Welcome, guest!\n");
    }
}

class Button{
    public event EventHandler Click;
    
    public void ClickButton(){
        Console.WriteLine("New guest arrived.\n");
        
        OnClick();//클릭 시
    }
    
    protected virtual void OnClick(){
        Click?.Invoke(this,EventArgs.Empty);
    }
}

class Greeting
{
    static void Main(string[] args)
    {
        Button btn=new Button();
        Hello hi=new Hello();
        
        btn.Click+=hi.OnButtonClick;
        
        Hello.HelloDelegate helloDelegate = Hello.introduce;
        
        btn.ClickButton();
        
        Console.WriteLine(helloDelegate("Tomato"));
    }
}
