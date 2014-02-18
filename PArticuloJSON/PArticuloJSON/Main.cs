using System;
using System.Xml;
using Gtk;


namespace PArticuloJSON
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
			
			XmlTextWriter xmlTextWriter = new XmlTextWriter(Console.Out);    
    		xmlTextWriter.WriteStartElement("prefix", "Element1", "namespace"); 
    		xmlTextWriter.WriteStartAttribute("prefix", "Attr1", "namespace1"); 
    		xmlTextWriter.WriteString("value1"); 
    		xmlTextWriter.Close();   
			
		}
	}
}
