using System;

namespace PrototypeMapEditor.CustomControls.ListBox
{
	public enum DropOperation
	{
		Reorder,
		MoveToHere,
		CopyToHere,
		MoveFromHere,
		CopyFromHere
	}

	public class DroppedEventArgs : EventArgs
	{
		public DropOperation Operation { get; set; }
		public IDragDropSource Source { get; set; }
		public IDragDropSource Target { get; set; }
		public object[] DroppedItems { get; set; }
	}
}