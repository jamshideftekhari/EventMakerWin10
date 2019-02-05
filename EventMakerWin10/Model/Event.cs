using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMakerWin10.Model
{
    public class Event
    {
  //      [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Place is required")]
        public string Place { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Date and time is required")]
        public DateTime DateTime { get; set; }
        public string TemplateColor { get; set; }
        public Event()
        { }

        public Event(int id, string name, string place, DateTime dateTime, string description)
        {
            Id = id;
            Name = name;
            Place = place;
            DateTime = dateTime;
            Description = description;
            TemplateColor = "Red";
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, Place: {2}, DateTime: {3}, Description: {4}", Id, Name, Place, DateTime, Description);
        }

    }
}
