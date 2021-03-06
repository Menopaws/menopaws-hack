﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menopaws.Models;
using Menopaws.Data;
using Syncfusion.SfSchedule.XForms;

namespace Menopaws.Data
{
	public class MenopausalDataStore : IMenopausalDataStore
	{
		List<MenopausalEvent> allEvents = new List<MenopausalEvent>();

		public void AddEvent(MenopausalEvent menopausalEvent)
		{
			allEvents.Add(menopausalEvent);
		}

		public List<MenopausalEvent> GetAllMenopausalEvents()
		{
			return allEvents;
		}

		public ScheduleAppointmentCollection CreateAppointmentCollection()
		{
			return new ScheduleAppointmentCollection();
		}
	}
}
