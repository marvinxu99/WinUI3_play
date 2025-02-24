using Microsoft.EntityFrameworkCore;
using MVVM_play.Models;
using MVVM_play.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MVVM_play.Data.DbInitializer
{
    class CodeValueSeeder
    {
        private readonly DatabaseContext _dbContext;
        private readonly LoggingService _logger;

        public CodeValueSeeder()
        {
            _dbContext = App.GetService<DatabaseContext>();
            _logger = App.GetService<LoggingService>();
        }

        //Public method to seed all required code sets
        public async Task SeedAsync()
        {

            // Add all CodeSets except 2 and 3
            var codeSets = new Dictionary<int, string[]>
            {
                // Code set 2 - Admit Sources
                { 2, [
                        "Clinic",
                        "Newborn",
                        "Day Procedure",
                        "Stillborn",
                        "Direct",
                        "Emergency"
                    ]
                },

                // Codeset 3 - Admit Type
                { 3, [
                        "Elective",
                        "Newborn",
                        "Urgent/Emergent",
                        "Stillborn",
                        "Deceased Donor"
                    ]

                },

                // Codeset 8: Data Status
                { 8, ["Active",
                    "Modified",
                    "Anticipated",
                    "Auth (Verified)",
                    "Canceled",
                    "Transcribed (corrected)",
                    "Dictated",
                    "In Error",
                    "In Lab",
                    "In Progress",
                    "Not Done",
                    "REJECTED",
                    "Started",
                    "Superseded",
                    "Transcribed",
                    "Unauth",
                    "? Unknown"]
                },

                // Codeset 10: Accommodation Code Value
                { 10, ["Private", "Semi Private", "Ward", "1Semi2Private", "1Private2Semi", "Ask Patient", "Not Applicable"] },

                /*Codeset 16: Courtesy Code 
                    It indicate whether the patient will be extended certain special courtesies such as express discharge, bypassing a stop at the cashiers window upon leaving when finanical arrangements are agreed upon in advance.
                */
                { 16, ["Yes"] },

                // Codeset 19: Discharge Disposition
                { 19, ["Admitted to an Inpatient Unit", "Left Against Medical Advice", "Transferred to Acute/Rehab/Tertiary MH",
                      "Deceased", "Transferred to Outpatient Clinic", "Discharged Home without Support Services",
                      "Discharged Home with Support Services", "Stillbirth", "Registered, Triaged, Not Assessed (LWBS)",
                      "Admitted to Critical Care or an OR", "System Discharge", "Transferred to Other"] },

                // Codeset 23: Doc Format
                { 23, ["ACR-NEMA", "AH", "AS", "AUDIO BASIC", "AUDIO MPEG", "CP", "DDIF", "DIO", "GIF", "HTML", "JPEG",
                      "LONG_BLOB", "LONG_TEXT", "MSWORD", "NONE", "PACS FOLD ID", "Paper", "PDF", "PNG", "PTIFF",
                      "RTF", "RVS", "TIFF", "? Unknown", "url", "VIDEO MPEG", "VOICE", "WINBMP", "WINEMF", "XHTML", "XML"] },


                { 24, ["C", "Link", "O", "R", "? Unknown"] },

                { 34, ["Allergy and Immunology", "Anesthesiology", "Emergency", "Family Practice", "Obstetrics", "Dermatology", "Urology", "Endocrinology", "Gastroenterology", "Nephrology", "Ophthalmology", "Pathology", "Pediatrics", "Radiation Oncology", "Dentistry", "Laboratory Medicine", "Newborn"] },

                { 48, ["Active", "Combined", "Historical value - combined", "Deleted", "Draft", "Inactive", "Recall",
                      "Review", "Suspended", "Unknown"] },

                { 53, ["Addendum", "AP", "Attachment", "Case", "Clinical Document", "Contribution", "Count", "Date", "DOC", "Document", "Done", "GRP", "Group Document", "Group Section", "Helix", "HLA Typing", "Immunization"] },

                { 68, ["Ground Ambulance Only", "No Ambulance", "Air Ambulance Only", "Air and Ground Ambulance"] },

                { 69, ["Blood donation", "Case Management", "Community Health Record", "Emergency", "Home Health", "Inbox Message",
                      "Inpatient", "Observation", "Outpatient", "Phone Msg", "Preadmit", "Recurring", "Research", "Skilled Nursing", "Wait List"] },

                { 71, ["Emergency", "Day Surgery", "Inpatient", "Outpatient in a Bed", "Outpatient", "Recurring", "Historical",
                      "Pre-Inpatient", "Pre-Recurring", "Pre-Day Surgery", "Home Care", "Deceased", "Tertiary MH", "Virtual Health"] },

                { 79, ["Cancelled", "Complete", "Deleted", "Delivered", "Discontinued", "Dropped", "In Error", "InProcess",
                      "OnHold", "Opened", "Overdue", "Pending", "Read", "Recalled", "Refused", "Rework", "Suspended"] },

                { 87, ["Chemical Dependency", "Routine Clinical", "Legal/Sensitive", "? Unknown"] },

                { 88, ["Ambulatory - Nurse", "DBA", "Emergency - Nurse", "Emergency - Nurse Manager", "Nurse - ICU",
                      "Residential Care", "RadNet - Nurse", "OB - Ambulatory Nurse", "Respiratory Therapist"] },

                { 89, ["3M CODING AND REIMBURSEMENT", "3M Australian", "PROFIT_PRECOLL_AGENCY", "ESO OUT",
                      "Centers for Disease Control", "Cerner", "Cerner LDAP", "CIHI", "Client", "FDA", "GDDB"] },

                { 106, ["Patient Care", "Patient Activity", "Asmt/Tx/Monitoring", "Diet Patient Care",
                      "Patient Education", "Intake and Output", "Surgery", "Task", "Home Care", "Critical Care"] },

                { 120, ["No Compression", "OCF Compression"] },

                { 261, ["Active", "Cancelled", "Cancelled Pending Arrival", "Discharged", "Hold", "Pending Arrival",
                      "Preadmit", "Referred", "Rejected Pending Arrival", "Transferred"] },

                { 263, ["BC PHN", "PharmaNet GPID", "Health Plan", "DEA", "Doctor Nbr", "Encounter Org", "External Id", "Insurance Code", "SSN", "UPIN", "Visit #", "NCT Number", "Default Place of Service"] },

                { 289, ["Text", "Time", "Date and Time", "Read Only", "Count", "Provider", "ORC Select",
                      "Inventory", "Bill Only", "Yes / No", "Alpha", "Freetext", "Calculation"] },

                { 321, ["Emergency", "Inpatient", "Outpatient", "Preadmit", "Historical"] },

                { 400, ["Patient Care", "Internal Codes", "ICD-10-CA"] },

                { 4010, ["NOW", "Routine", "STAT"] },

                { 6000, ["Ambulatory POC", "Ambulatory Procedures", "Ambulatory Referrals", "Admit/Transfer/Discharge",
                      "Audiology", "Blood Bank Donor", "Cardiology", "Case Manager", "Consults", "Dialysis", "Pharmacy"] },

                { 6025, ["Adhoc", "Continuous", "Non Scheduled", "PRN", "Scheduled"] },

                { 6027, ["Abnormal Result", "Collect Specimen", "Chart IO Dialog", "Chart Results",
                      "Chart Variance", "Complete Order", "Complete Personal", "Dr. Cosign", "Medication History"] },

                { 14767, ["Security", "Medically Necessary", "Patient Request", "Psychiatric Concerns",
                      "Senior Administration Request", "To Be Moved When Bed Available", "Equipment in Room"] },
            };

            foreach (var codeSet in codeSets)
            {
                await SeedCodeValuesAsync(codeSet.Key, codeSet.Value);
            }

        }

        // Generic method to handle multiple CodeSets efficiently
        private async Task SeedCodeValuesAsync(int codeSet, string[] codeValues)
        {
            if (await _dbContext.CodeValue.AnyAsync(cv => cv.CodeSet == codeSet))
            {
                _logger.Information($"Code values for CodeSet {codeSet} were previously seeded!");
                return;
            }

            _logger.Information($"Seeding CodeSet {codeSet} started...");

            var cvEntities = codeValues
                .Select(cv_display => new CodeValue
                {
                    CodeSet = codeSet,
                    Display = cv_display,
                    DisplayKey = ConvertToKey(cv_display),
                    Definition = cv_display,
                    Description = cv_display
                })
                .ToList();

            await _dbContext.CodeValue.AddRangeAsync(cvEntities);
            await _dbContext.SaveChangesAsync();

            _logger.Information($"Seeding CodeSet {codeSet} completed!");
        }

        private string ConvertToKey(string input)
        {
            return string.IsNullOrWhiteSpace(input) ? string.Empty : Regex.Replace(input, "[^0-9a-zA-Z]+", "").ToUpper();
        }
    }
}
