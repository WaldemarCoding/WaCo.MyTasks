using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Prism.Commands;
using Prism.Mvvm;
using WaCo.MyTasks.Core;
using WaCo.MyTasks.Services;

namespace WaCo.MyTasks.ToDo.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private readonly ITaskService _taskService;

        private BindingList<TaskEntry> _taskEntryList = new BindingList<TaskEntry>();
        public BindingList<TaskEntry> TaskEntryList
        {
            get { return _taskEntryList; }
            set { SetProperty(ref _taskEntryList, value); }
        }

        private TaskEntry _selectedTaskEntry;
        public TaskEntry SelectedTaskEntry
        {
            get { return _selectedTaskEntry; }
            set { SetProperty(ref _selectedTaskEntry, value); }
        }

        public ViewAViewModel(ITaskService taskService)
        {
            _taskService = taskService;

            UpdateCmd.ObservesProperty(() => SelectedTaskEntry);
            DeleteCmd.ObservesProperty(() => SelectedTaskEntry);
        }

        private DelegateCommand _addCmd;
        public DelegateCommand AddCmd => _addCmd ??= new DelegateCommand(ExecuteAddCmd);

        void ExecuteAddCmd()
        {
            var dt = DateTime.Now;
            var t = new TaskEntry("Test " + dt.TimeOfDay, "Description " + dt.ToLongDateString(), TaskPriority.Medium, dt, dt.AddDays(2));

            _taskService.AddTask(t);
            ReloadCmd.Execute();
        }

        private DelegateCommand _updateCmd;
        public DelegateCommand UpdateCmd => _updateCmd ??= new DelegateCommand(ExecuteUpdateCmd, CanExecuteUpdateCmd);

        void ExecuteUpdateCmd()
        {
            var dt = DateTime.Now;
            SelectedTaskEntry.Titel = "Test " + dt.TimeOfDay;
            SelectedTaskEntry.Description = "Description " + dt.ToLongDateString();
            SelectedTaskEntry.StartDate = dt;
            _taskService.UpdateTask(SelectedTaskEntry);
            ReloadCmd.Execute();
        }

        bool CanExecuteUpdateCmd()
        {
            return SelectedTaskEntry != null;
        }

        private DelegateCommand _deleteCmd;
        public DelegateCommand DeleteCmd => _deleteCmd ??= new DelegateCommand(ExecuteDeleteCmd, CanExecuteDeleteCmd);

        void ExecuteDeleteCmd()
        {
            _taskService.DeleteTask(SelectedTaskEntry.Id);
            ReloadCmd.Execute();
        }

        bool CanExecuteDeleteCmd()
        {
            return SelectedTaskEntry != null;
        }

        private DelegateCommand _reloadCmd;
        public DelegateCommand ReloadCmd => _reloadCmd ??= new DelegateCommand(ExecuteReloadCmd);

        void ExecuteReloadCmd()
        {
            TaskEntryList.Clear();
            var values = _taskService.GetAllEntries();
            TaskEntryList.AddRange(values);
        }
    }
}
