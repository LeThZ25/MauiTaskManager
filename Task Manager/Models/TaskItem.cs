using CommunityToolkit.Mvvm.ComponentModel;

namespace Task_Manager.Models
{
	public partial class TaskItem : ObservableObject
	{
		[ObservableProperty]
		private string title;

		[ObservableProperty]
		private bool isCompleted;
	}
}