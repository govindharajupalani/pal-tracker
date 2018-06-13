using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PalTracker
{
    public class MySqlTimeEntryRepository : ITimeEntryRepository
    {
            TimeEntryContext _timeentrycontext;
            public MySqlTimeEntryRepository(TimeEntryContext  context)
            {
                _timeentrycontext = context;
            }
            public TimeEntry Create(TimeEntry timeEntry)
            {
                var recordToCreate = timeEntry.ToRecord();
                _timeentrycontext.TimeEntryRecords.Add(recordToCreate);
                _timeentrycontext.SaveChanges();
                return Find(recordToCreate.Id.Value );

                // var recordToCreate = timeEntry.ToRecord();
                // _timeentrycontext.TimeEntryRecords.Add(recordToCreate);
                // _timeentrycontext.SaveChanges();
                // return Find(recordToCreate.Id.Value);
            }
            public TimeEntry Find(long id)
            {
              return _timeentrycontext.TimeEntryRecords.Find(id).ToEntity();           
            }
            public bool Contains(long id)
            {
                return _timeentrycontext.TimeEntryRecords.AsNoTracking().Any(t =>t.Id==id);
            }
            public IEnumerable<TimeEntry> List()
            {
                return _timeentrycontext.TimeEntryRecords.AsNoTracking().Select(t=>t.ToEntity());
            }
            public TimeEntry Update(long id, TimeEntry timeEntry)
            {     
                var updatedrecord =   timeEntry.ToRecord() ;
                updatedrecord.Id  = id;
                _timeentrycontext.Update(updatedrecord);
                _timeentrycontext.SaveChanges();
                return Find(updatedrecord.Id.Value);
            }
            public void Delete(long id)
            {
                var Recordtodelete = _timeentrycontext.TimeEntryRecords.AsNoTracking().Single(t => t.Id == id);
                _timeentrycontext.Remove(  Recordtodelete );
                _timeentrycontext.SaveChanges();
            }
    }
}


// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;

// namespace PalTracker
// {
//     public class MySqlTimeEntryRepository : ITimeEntryRepository
//     {
//         private readonly TimeEntryContext _context;

//         public MySqlTimeEntryRepository(TimeEntryContext context)
//         {
//             _context = context;
//         }

//         public TimeEntry Create(TimeEntry timeEntry)
//         {
//             var recordToCreate = timeEntry.ToRecord();
//             _context.TimeEntryRecords.Add(recordToCreate);
//             _context.SaveChanges();
//             return Find(recordToCreate.Id.Value);
//         }

//         public TimeEntry Find(long id) => FindRecord(id).ToEntity();

//         public bool Contains(long id) =>
//             _context.TimeEntryRecords.AsNoTracking().Any(t => t.Id == id);

//         public IEnumerable<TimeEntry> List() =>
//             _context.TimeEntryRecords.AsNoTracking().Select(t => t.ToEntity());

//         public TimeEntry Update(long id, TimeEntry timeEntry)
//         {
//             var recordToUpdate = timeEntry.ToRecord();
//             recordToUpdate.Id = id;
//             _context.Update(recordToUpdate);
//             _context.SaveChanges();
//             return Find(id);
//         }

//         public void Delete(long id)
//         {
//             _context.TimeEntryRecords.Remove(FindRecord(id));
//             _context.SaveChanges();
//         }

//         private TimeEntryRecord FindRecord(long id) =>
//             _context.TimeEntryRecords.AsNoTracking().Single(t => t.Id == id);
//     }
// }


