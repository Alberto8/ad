using Gtk;
using System;
using System.Data;

namespace Serpis.Ad
{
	[System.ComponentModel.ToolboxItem(true)]
	public abstract partial class MyWidget : Gtk.Bin, IEntityListView
	{
		protected IDbConnection dbConnection;
		public MyWidget (IDbConnection dbConnection) 
		{
			this.dbConnection = dbConnection;
			this.Build ();
			Visible = true;
			
			TreeView.AppendColumn("id", new CellRendererText(), "text", 0);
			TreeView.AppendColumn("nombre", new CellRendererText(), "text", 1);
			
			ListStore listStore = new ListStore(typeof(int), typeof(string));
			listStore.AppendValues(1, "Elemento 1");
			listStore.AppendValues(2, "Elemento 2");
			
			TreeView.Model = listStore;
			
			treeView.Selection.Changed += delegate {
				//SelectedChanged(this, EventArgs.Empty);
			};
		
			Gtk.Action deleteAction = new Gtk.Action("deleteAction", null, null, Stock.Delete);
			ActionGroup.Add(deleteAction);
		}
		
		public TreeView TreeView {
			get {return treeView;}
		}
		
		public ActionGroup actionGroup {
			get {return actionGroup;}
		}
		
		#region IEntityListView implementation
		public abstract void New ();

		public abstract void Edit ();

		public abstract void Delete ();

		public abstract void Refresh ();

		public bool HasSelected {
			get {
				return treeView.Selection.CountSelectedRows() > 0;
			}
		}
		
		public event EventHandler SelectedChanged;
		#endregion

	}
}

