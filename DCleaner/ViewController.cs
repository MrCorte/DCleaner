using System;
using System.IO;
using AppKit;
using Foundation;

namespace DCleaner
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
            Label.StringValue = "Press The Button for start DCleaner";
        }

        partial void ClickedButton(NSObject sender)
        {
            string dir = "/Users/andrea/Downloads/";
            DateTime oggi = DateTime.Today;
            foreach (string f in Directory.GetFiles(dir))
            {
                DateTime ultimoAccesso = File.GetLastAccessTime(f);
                TimeSpan delta = oggi - ultimoAccesso;
                if (delta > TimeSpan.FromDays(7))
                {
                    //Console.WriteLine(delta.Days + dir);
                    File.Delete(f);
                }
            }
            Label.StringValue = "DCleaner have finish";
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
