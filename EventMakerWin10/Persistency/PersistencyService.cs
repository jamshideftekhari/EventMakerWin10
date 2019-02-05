using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using EventMakerWin10.Model;
using Newtonsoft.Json;

namespace EventMakerWin10.Persistency
{
    class PersistencyService
    {
        private static string eventFileName = "EventsAsJson.dat";


        public static async void SaveEventsAsJsonAsync(ObservableCollection<Event> events)
        {
            string eventsJsonString = JsonConvert.SerializeObject(events);
            SerializeEventsFileAsync(eventsJsonString, eventFileName);
        }

        public static async Task<List<Event>> LoadEventsFromJsonAsync()
        {
            string eventsJsonString = await DeSerializeEventsFileAsync(eventFileName);
            if (eventsJsonString != null)
                return (List<Event>)JsonConvert.DeserializeObject(eventsJsonString, typeof(List<Event>));
            return null;
        }

        public static async Task<List<Event>> LoadEventsFromJsonAsyncDB()
        {
            string EventWebApi = "http://localhost:58124/api/events";

            using (HttpClient client = new HttpClient())
            {
                string eventsJsonString = await client.GetStringAsync(EventWebApi);
                if (eventsJsonString != null)
                    return (List<Event>)JsonConvert.DeserializeObject(eventsJsonString, typeof(List<Event>));
                return null;
            }

           // string eventsJsonString = await DeSerializeEventsFileAsync(eventFileName);
            //if (eventsJsonString != null)
            //    return (List<Event>)JsonConvert.DeserializeObject(eventsJsonString, typeof(List<Event>));
            //return null;
        }

        public static async void SerializeEventsFileAsync(string eventsString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, eventsString);
        }

        public static async Task<string> DeSerializeEventsFileAsync(String fileName)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return await FileIO.ReadTextAsync(localFile);
            }
            catch (FileNotFoundException ex)
            {

                MessageDialogHelper.Show("File of Events not found! - Loading for the first time?", "File not found!");
                return null;
            }
        }

        private class MessageDialogHelper
        {
            public static async void Show(string content, string title)
            {
                MessageDialog messageDialog = new MessageDialog(content, title);
                await messageDialog.ShowAsync();
            }
        }


    }
}
