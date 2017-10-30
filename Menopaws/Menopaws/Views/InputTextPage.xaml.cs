﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Menopaws.Texting;

namespace Menopaws
{
	public partial class InputTextPage : ContentPage
	{
		private ITexting textingService { get; set; }
		public InputTextPage()
		{
			InitializeComponent();

		}

		void OnSendClicked(object sender, EventArgs args)
		{
			if (phoneNumber.Text != null)
			{
				DisplayAlert("Alert", "Success", message.Text, "OK");
				Navigation.PopAsync(true);
			}
			else
			{
				DisplayAlert("Alert", "Please enter a phone number", "OK");
			}

		}
	}
}
