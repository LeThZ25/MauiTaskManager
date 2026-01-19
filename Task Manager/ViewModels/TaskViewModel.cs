using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Task_Manager.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Task_Manager.ViewModels
{
	public partial class TasksViewModel : ObservableObject
	{
		[ObservableProperty]
		private string newTaskTitle;

		public ObservableCollection<TaskItem> Tasks { get; } = new();

		[ObservableProperty]
		private TaskItem selectedTask;

		public int TotalCount => Tasks.Count;
		public int CompletedCount => Tasks.Count(t => t.IsCompleted);

		public TasksViewModel()
		{
			Tasks.CollectionChanged += (s, e) =>
			{
				OnPropertyChanged(nameof(TotalCount));
				OnPropertyChanged(nameof(CompletedCount));
			};
		}

		[RelayCommand]
		private void AddTask()
		{
			if (string.IsNullOrWhiteSpace(NewTaskTitle)) return;
			var newTask = new TaskItem { Title = NewTaskTitle, IsCompleted = false };
			newTask.PropertyChanged += Task_PropertyChanged;
			Tasks.Add(newTask);
			NewTaskTitle = string.Empty;
		}

		private void Task_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(TaskItem.IsCompleted))
			{
				OnPropertyChanged(nameof(CompletedCount));
			}
		}
	}
}