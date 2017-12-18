﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Menopaws.Data;
using Xamarin.Forms;


namespace Menopaws
{
	public class MainPageViewModel : INotifyPropertyChanged
	{
		public INavigation Navigation { get; set; }
	    private IMenopausalDataStore _dataStore;


        public ICommand CrisisCommand { get; private set; }
		public ICommand HotFlushCommand { get; private set; }
		public Command ChangeMoodCommand { get; private set; }


		public MainPageViewModel(INavigation navigation, IMenopausalDataStore dataStore)
		{
		    _dataStore = dataStore;
		    this.Navigation = navigation;
			CrisisCommand = new Command(NavigateSendTextPage);
			HotFlushCommand = new Command(NavigateLogHotFlush);
			ChangeMoodCommand = new Command(NavigateLogNotMyself);
		}

		void NavigateSendTextPage() => Navigation.PushAsync(new InputTextPage());

		void NavigateLogHotFlush()
		{
			Navigation.PushAsync(new SchedulePage("Hot Flush"));
			ListItemSelected = _dataStore.GetAllMenopausalEvents();
		}

		void NavigateLogNotMyself()
		{
			Navigation.PushAsync(new SchedulePage("Not feeling myself"));
			ListItemSelected = _dataStore.GetAllMenopausalEvents();
		}

		public object ListItemSelected
		{
			get;
			private set;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged([CallerMemberName] string name = null) =>
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}
}
