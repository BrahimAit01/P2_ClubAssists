using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubAssist.Model
{
    internal class ActivitiesModel
    {
        public int ActivityId { get; set; } required
        public string Title { get; set; } required
        public string Description { get; set; } required
        public string Location { get; set; } required
        public DateTime StartTime { get; set; } required
        public DateTime EndTime { get; set; } required
        public int NeededVolunteers { get; set; } required
        public int CurrentVolunteers { get; set; } 
        public int CreatedBy { get; set; }
    } 
}
