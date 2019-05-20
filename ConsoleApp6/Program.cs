using System;
using System.Windows;
using System.Windows.Controls;



namespace WpfAppAllCode
{
    class Program:Application
    {
        [STAThread]
        static void Main(string[] args)
        {
            
            Program app=new Program();
            app.Startup+=AppStartUp;
            app.Exit+=AppExit;
            app.Run();


        }


        static void AppExit(object sender,ExitEventArgs e)
        {

            MessageBox.Show("App Exit");

        }
        static void AppStartUp(object sender, StartupEventArgs e)
        {
            //Window mainWindow=new Window();
            //mainWindow.Title="My First WPF App in the World!";
            //mainWindow.Height=200;
            //mainWindow.Width=300;
            //mainWindow.WindowStartupLocation=WindowStartupLocation.CenterScreen;
            //mainWindow.Show();
            Application.Current.Properties["GodMode"]=false;
            //MainWindow wnd =new MainWindow("My better WPF App",500,700);  
            foreach(string arg in e.Args)
            {
                if(arg.ToLower()=="/godmode")
                {
                    Application.Current.Properties["GodMode"]=true;
                    break;
                }

            }
            MainWindow wnd=new MainWindow("My better WPF App",500,200);
            wnd.Show();

        }
        class MainWindow:Window
        {
            private Button btnExitApp = new Button();
            

            public MainWindow(string WindowTitle, int height, int width)
            {
                btnExitApp.Click += new RoutedEventHandler(btnExitApp_Clicked);
                btnExitApp.Content = "Exit from Application";
                btnExitApp.Width = 200;
                btnExitApp.Height = 75;
                this.Title=WindowTitle;
                this.WindowStartupLocation=WindowStartupLocation.CenterScreen;
                this.Height=height;
                this.Width=width;               
                this.AddChild(btnExitApp);
                this.Show();
            }
            private void btnExitApp_Clicked(object sender, RoutedEventArgs e)
            {
                if((bool)Application.Current.Properties["GodMode"])
                    MessageBox.Show("Cheater!");

               this.Close();
            }
           


        }
    }

}
