using MVVM_play.Models;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MVVM_play.Data.DbInitializer;

public static partial class InitCodeValueSet
{

    public static async Task SeedAsync()
    {
        var dbContext = App.GetService<DatabaseContext>();
        //using var logger = App.GetService<LoggingService>();

        // Instead of checking Any() on the entire table (_dbContext.CodeValueSet.Any()),
        // check for a specific key to improve performance
        //if (_dbContext.CodeValueSet.Any())  return;
        if (dbContext.CodeValueSet.Any(cs => cs.CodeSet == 2)) return;

        //logger.Information("Seeding CodeValueSet...");

        var suCodesets = new (int, string)[]
        {
            (2, "Admit Source"),
            (3, "Admit Type"),
            (8, "Data Status"),
            (10, "Accommodation"),
            (16, "Courtesy Code"),
            (19, "Discharge Disposition"),
            (23, "Doc_Format"),
            (24, "Event Relationship"),
            (34, "Medical Service"),
            (48, "Active Status"),
            (53, "Event_Class"),
            (54, "Units of Measure"),
            (68, "Admit Mode"),
            (69, "Encounter Type Class"),
            (71, "Encounter Type"),
            (72, "Event Code"),
            (79, "Task Status"),
            (87, "Confidential Level"),
            (88, "Position"),
            (89, "Contributor System"),
            (93, "Event Sets"),
            (106, "Activity Type"),
            (120, "Compression Code Value"),
            (200, "Order Catalog"),
            (220, "Location"),
            (261, "Encounter Status"),
            (263, "Alias Pool Code"),
            (289, "Result Type"),
            (302, "Person Type"),
            (321, "Encounter Class"),
            (400, "Source Vocabulary"),
            (4003, "Frequency"),
            (4010, "Task Priority"),
            (6000, "Catalog Type"),
            (6003, "Order Action Type"),
            (6004, "Order Status"),
            (6006, "Communication Type"),
            (6011, "Mnemonic Type"),
            (6014, "Reschedule Reason"),
            (6024, "Message Subject"),
            (6025, "Task Class"),
            (6026, "Task Type"),
            (6027, "Task Activity"),
            (6029, "Task Activity Class"),
            (6034, "Task Subtypes"),
            (14003, "Discrete Data Assay"),
            (14024, "Task Status Reason Code"),
            (14219, "Blood Bank Donor Procedure"),
            (14281, "Department Status"),
            (14766, "Accompanied By Code"),
            (14767, "Accommodation Reason"),
            (16389, "DCP Clinical Category"),
            (17969, "ABN Status"),
            (18309, "Med Order Type"),
            (22589, "Alternate Level of Care"),
            (255090, "Charting Agent"),
            (4002164, "Offset Minute Type Code"),
            (4002509, "Rounding Rule Code")
        };

        var cvEntities = suCodesets.Select(cs => new CodeValueSet
        {
            CodeSet = cs.Item1,
            Display = cs.Item2,
            DisplayKey = MyRegex().Replace(cs.Item2, "").ToUpper(),
            Definition = cs.Item2,
            Description = cs.Item2
        }).ToList();

        dbContext.CodeValueSet.AddRange(cvEntities);
        await dbContext.SaveChangesAsync();

        //logger.Information("Seeding CodeValueSet completed!");

    }

    [GeneratedRegex("[^0-9a-zA-Z]+")]
    private static partial Regex MyRegex();
}
