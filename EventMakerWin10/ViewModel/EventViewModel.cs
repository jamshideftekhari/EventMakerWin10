using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EventMakerWin10.Annotations;
using EventMakerWin10.Common;
using EventMakerWin10.Model;
using EventMakerWin10.Handler;

namespace EventMakerWin10.ViewModel
{
   public class EventViewModel : INotifyPropertyChanged
    {

        private int _id;
        private string _name;
        private string _description;
        private string _place;
        private DateTimeOffset _date;
        private TimeSpan _time;
        private Event _selectedEvent;
        private string _errorMessage;
        private string _textBoxVisibility = "Collapsed";
        private string _textBoxBoarderColor = "Gray";
        private string _descBoxBoarderColor = "Gray";
        private string _nameLabel = "Name";
        private string _descriptionLabel = "Name";
        private object _numberOfEvent;

        public object NumberOfEvent {
            get { return _numberOfEvent; }
            set
            {
               // NumberOfEvent = EventCatalogSingletone.Events.Count;
                _numberOfEvent = value;
                OnPropertyChanged();
            }
        }

        public string DescriptionLabel
        {
            get { return _descriptionLabel; }
            set
            {
                _descriptionLabel = value;
                OnPropertyChanged();
            }
        }


        public string DescBoxBoarderColor
        {
            get { return _descBoxBoarderColor; }
            set
            {
                _descBoxBoarderColor = value;
                OnPropertyChanged();
            }
        }

        public string NameLabel
        {
            get { return _nameLabel; }
            set
            {
                _nameLabel = value;
                OnPropertyChanged();
            }
        }
        public string TextBoxBoarderColor
        {
            get { return _textBoxBoarderColor; }
            set
            {
                _textBoxBoarderColor = value;
                OnPropertyChanged();
            }
        }
        public string TextBoxVisibility
        {
            get { return _textBoxVisibility; }
            set
            {
                _textBoxVisibility = value;
                OnPropertyChanged();
            }
        }
        public string ErrorMessage
            {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public Event SelectedEvent
        {
            get { return _selectedEvent; }
            set
            {
                _selectedEvent = value;
                OnPropertyChanged();
            }
        }

        public EventCatalogSingletone EventCatalogSingletone { get; set; }
        public Handler.EventHandler EventHandler { get; set; }

        private ICommand _createEventCommand;

        public ICommand CreateEventCommand
        {
            get
            {
                if (_createEventCommand == null)
                    // _createEventCommand = new RelayCommand(EventHandler.CreateEvent);
                    _createEventCommand = new RelayCommand(CreateEventToList);
                return _createEventCommand;
            }
            set
            {
                _createEventCommand = value;
               
            }
        }

        public void CreateEventToList()
        {

            if (_name == null)
            {
                NameLabel = "Name: (Name is required)";
                TextBoxBoarderColor = "Red";
            }
            else if (_description == null)
            {
                DescriptionLabel = "Description: (Description is required)";
                DescBoxBoarderColor = "Red";
            }
            else
            {
                EventHandler.CreateEvent();
            }

        }

        private ICommand _selectEventCommand;
        public ICommand SelectEventCommand
        {
            get { return _selectEventCommand ?? (_selectEventCommand = new RelayArgCommand<Event>(ev => EventHandler.SetSelectedEvent(ev))); }
            set
            {
                _selectEventCommand = value;

            }
        }

        private ICommand _deleteEventCommand;

        public ICommand DeleteEventCommand
        {
            get
            {
                return _deleteEventCommand ?? (_deleteEventCommand = new RelayCommand(EventHandler.DeleteEvent));
                
            }
            set { _deleteEventCommand = value; }
        }

        public EventViewModel()
        {
            EventHandler = new Handler.EventHandler(this);
            EventCatalogSingletone = EventCatalogSingletone.Instance;
            DateTime dt = System.DateTime.Now;
           NumberOfEvent = EventCatalogSingletone.EventNumber;
            SelectedEvent = new Event();
           

            _date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());
            _time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);

        
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }
        [Required(ErrorMessage = "Name is required")]
        public string Name
        {
            get
            {

                return _name;
            }
            set
            {
                _name = value;
                NameLabel = "Name:";
                TextBoxBoarderColor = "Gray";
                OnPropertyChanged();
            }
        }

        public string Place
        {
            get { return _place; }
            set { _place = value; OnPropertyChanged(); }
        }


        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(); }
        }

        public DateTimeOffset Date
        {
            get { return _date; }
            set { _date = value; }
        }


        public TimeSpan Time
        {
            get { return _time; }
            set { _time = value; }
        }

        //private ICommand _selectedEvent;
        //public ICommand SelectedEvent
        //{
        //    get { return _selectedEvent; }
        //    set
        //    {
        //        _selectedEvent = value;
        //      //  EventCatalogSingletone.KeepSelectedEvent(_selectedEvent);
        //        OnPropertyChanged();
        //    }
        //}
        public EventViewModel ReturnEventViewModelRef()
        {
            return this;
        }
       


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
