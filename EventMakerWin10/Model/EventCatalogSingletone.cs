using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMakerWin10.Persistency;

namespace EventMakerWin10.Model
{
    public class EventCatalogSingletone 
    {
        private static EventCatalogSingletone _instance/* = new EventCatalogSingletone()*/;

        public static EventCatalogSingletone Instance
        {
            //get
            //{
            //    if (_instance == null)
            //        _instance = new EventCatalogSingleton();
            //    return _instance;
            //}

            get { return _instance ?? (_instance = new EventCatalogSingletone()); }

        }

        public ObservableCollection<Event> Events { get; set; }
        public Event SelectedEvent { get; set; }
        public object EventNumber { get; set; }

        private EventCatalogSingletone()
        {
            Events = new ObservableCollection<Event>();
                LoadEventsAsync();
            //    LoadEvents();
           // LoadEventsAsyncDB();
            EventNumber = Events.Count();
        }

        public async void LoadEventsAsyncDB()
        {
            var events = await PersistencyService.LoadEventsFromJsonAsyncDB();
            if (events != null)
                foreach (var ev in events)
                {
                    Events.Add(ev);
                }
           
        }

        public async void LoadEventsAsync()
        {
            var events = await PersistencyService.LoadEventsFromJsonAsync();
            if (events != null)
                foreach (var ev in events)
                {
                    Events.Add(ev);
                }
           // else
           // {
           ////     Data til testformål
           // Events.Add(new Event(1, "Pitching 2end semester Projects", "Auditorium 202", new DateTime(2014, 12, 24, 9, 0, 0), "De studerende fremlægger deres eksamensprojekt"));
           //     Events.Add(new Event(2, "Eksamen", "lokale 122", new DateTime(2015, 1, 6, 9, 0, 0), "Eksamen 1. semester"));
           // Events.Add(new Event(3, "hahaha", "lokale 122", new DateTime(2015, 1, 6, 9, 0, 0), "Eksamen 2. semester"));
           // }
        }

        public void LoadEvents()
        {
           
                //     Data til testformål
                Events.Add(new Event(1, "Pitching 2end semester Projects", "Auditorium 202", new DateTime(2014, 12, 24, 9, 0, 0), "De studerende fremlægger deres eksamensprojekt"));
                Events.Add(new Event(2, "Eksamen", "lokale 122", new DateTime(2015, 1, 6, 9, 0, 0), "Eksamen 1. semester"));
                Events.Add(new Event(3, "hahaha", "lokale 122", new DateTime(2015, 1, 6, 9, 0, 0), "Eksamen 2. semester"));
            
        }

        public void Add(Event newEvent)
        {
            Events.Add(newEvent);
            PersistencyService.SaveEventsAsJsonAsync(Events);
            EventNumber = Events.Count();
        }

        public void Add(int id, string name, string place, DateTime dateTime, string description)
        {
            Events.Add(new Event(id, name, place, dateTime, description));
            PersistencyService.SaveEventsAsJsonAsync(Events);
            EventNumber = Events.Count();
        }

        public void Remove(Event eventToBeRemoved)
        {
            Events.Remove(eventToBeRemoved);
            PersistencyService.SaveEventsAsJsonAsync(Events);
            EventNumber = Events.Count();
        }

        //public void RemoveNoParam()
        //{
        //    Events.Remove(SelectedEvent);
        //    PersistencyService.SaveEventsAsJsonAsync(Events);
        //}

        //public void KeepSelectedEvent(Event myEvent)
        //{
        //    SelectedEvent = myEvent;
        //}

    }
}
