using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using WaCo.MyTasks.Core;
using WaCo.MyTasks.DataAccess;
using WaCo.MyTasks.Models;
using WaCo.MyTasks.Services.Interfaces;

namespace WaCo.MyTasks.ToDo.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private readonly ITaskEntryService _taskService;
        private readonly ITaskEntryRepository _taskEntryRepo;

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

        public ViewAViewModel(ITaskEntryService taskService, ITaskEntryRepository taskEntryRepo)
        {
            _taskService = taskService;
            _taskEntryRepo = taskEntryRepo;

            UpdateCmd.ObservesProperty(() => SelectedTaskEntry);
            DeleteCmd.ObservesProperty(() => SelectedTaskEntry);
        }

        private DelegateCommand _addCmd;
        public DelegateCommand AddCmd => _addCmd ??= new DelegateCommand(ExecuteAddCmd);

        async void ExecuteAddCmd()
        {
            var dt = DateTime.Now;
            var t = new TaskEntry("Test " + dt.TimeOfDay, "Description " + dt.ToLongDateString(), TaskPriority.Medium, dt, dt.AddDays(2));

            _taskEntryRepo.Add(t);
            await _taskEntryRepo.SaveAsync();
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
            _taskEntryRepo.SaveAsync();
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
            _taskEntryRepo.Remove(SelectedTaskEntry);
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
            var values = _taskService.GetOpenEntries().ToList();
            TaskEntryList.AddRange(values);
        }
    }
}
