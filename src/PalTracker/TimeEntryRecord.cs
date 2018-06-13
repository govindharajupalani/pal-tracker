using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PalTracker
{
    [Table("time_entries")]
    public class TimeEntryRecord
    {
        [Column("id")]
        public long? Id { set; get; }

        [Column("project_id")]
        public long ProjectId { set; get; }

        [Column("user_id")]
        public long UserId { set; get; }

        [Column("date")]
  
        public DateTime Date { get; set; }

        [Column("hours")]
        public int Hours { get; set; }

        public TimeEntryRecord( )
        {
                
        }


    }

}