using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using EventMakerWin10.Converter;
using EventMakerWin10.Model;
using EventMakerWin10.ViewModel;

namespace EventMakerWin10.Handler
{
    public class EventHandler
    {
        public EventViewModel EventViewModel { get; set; }

        public EventHandler()
        {
            
        }
        public EventHandler(EventViewModel eventViewModel)
        {
            EventViewModel = eventViewModel;
        }

        public void CreateEvent()
        {
            //var newEvent = new Event(EventViewModel.Id, EventViewModel.Name, EventViewModel.Place, DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(EventViewModel.Date, EventViewModel.Time), EventViewModel.Description);
            //EventViewModel.EventCatalogSingleton.Add(newEvent);
            if (EventViewModel.Name == null)
            {
                throw new ArgumentNullException(EventViewModel.Name);
            }
            EventViewModel.EventCatalogSingletone.Add(EventViewModel.Id, EventViewModel.Name, EventViewModel.Place, DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(EventViewModel.Date, EventViewModel.Time), EventViewModel.Description);
        }

        public void SetSelectedEvent(Event ev)
        {
            EventViewModel.SelectedEvent = ev;
            EventViewModel.EventCatalogSingletone.SelectedEvent = ev;
        }

        public async void DeleteEvent()
        {
            if (EventViewModel.SelectedEvent.Name != null)
               // if (EventViewModel.EventCatalogSingletone.SelectedEvent.Name != null)
                {

                // Create the message dialog and set its content
                var messageDialog = new MessageDialog("Are you sure you want to Delete the Event: " + EventViewModel.SelectedEvent.Name + " ?");

            // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
            messageDialog.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(this.CommandInvokedHandler)));
            messageDialog.Commands.Add(new UICommand("No", null));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog
            await messageDialog.ShowAsync();
            }


        }

        private void CommandInvokedHandler(IUICommand command)
        {
             EventViewModel.EventCatalogSingletone.Remove(EventViewModel.SelectedEvent);
           // EventViewModel.EventCatalogSingletone.Remove(EventViewModel.EventCatalogSingletone.SelectedEvent);

        }

    }
}
