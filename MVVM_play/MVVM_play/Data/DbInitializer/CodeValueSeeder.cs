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

                // Codeset 34: Medical Service
                { 34, ["Allergy and Immunology", "Anesthesiology", "Emergency", "Family Practice", "Obstetrics", "Dermatology", "Urology", "Endocrinology", "Gastroenterology", "Nephrology", "Ophthalmology", "Pathology", "Pediatrics", "Radiation Oncology", "Dentistry", "Laboratory Medicine", "Newborn"] },

                { 48, ["Active", "Combined", "Historical value - combined", "Deleted", "Draft", "Inactive", "Recall",
                      "Review", "Suspended", "Unknown"] },

                // Codeset 53: Event Class
                { 53, ["Addendum",
                        "AP",
                        "Attachment",
                        "Case",
                        "Clinical Document",
                        "Contribution",
                        "Count",
                        "Date",
                        "DOC",
                        "Document",
                        "Done",
                        "GRP",
                        "Group Document",
                        "Group Section",
                        "Helix",
                        "HLA Typing",
                        "Immunization",
                        "Interp",
                        "IO",
                        "MBO",
                        "mdoc",
                        "MED",
                        "NUM",
                        "Place Holder",
                        "Procedure",
                        "Radiology",
                        "Result - Document",
                        "Single Contributor Document",
                        "Section",
                        "Trans",
                        "TXT",
                        "? Unknown"]
                },

                // Codeset 68: Admit Mode
                { 68, ["Ground Ambulance Only", "No Ambulance", "Air Ambulance Only", "Air and Ground Ambulance"] },

                // Codeset 69: Encounter Type Class
                { 69, ["Blood donation", "Case Management", "Community Health Record", "Emergency", "Home Health", "Inbox Message", "Inpatient", "Observation", "Outpatient", "Phone Msg", "Preadmit", "Recurring", "Research", "Skilled Nursing", "Wait List"] },

                // Codeset 71: Encounter Type
                { 71, [ "Emergency",
                        "Day Surgery",
                        "Inpatient",
                        "Outpatient in a Bed",
                        "Outpatient",
                        "Recurring",
                        "Historical",
                        "Pre-Inpatient",
                        "Pre-Recurring",
                        "Pre-Day Surgery",
                        "Pre-Outreach",
                        "Home Care",
                        "Deceased",
                        "Tertiary MH",
                        "Data Storage",
                        "Outside Images",
                        "Phone Message",
                        "Virtual Health",
                        "Pre-Outpatient",
                        "Assisted Living",
                        "Provider to Provider",
                        "Outreach",
                        "Residential",
                        "Stillborn",
                        "Newborn",
                        "Referral",
                        "Specimen",
                        "ALC",
                        "Outpatient OB",
                        "Pre-Outpatient OB",
                        "Pre-Home Care",
                        "Phone Consult",
                        "Minor Surgery",
                        "Pre-Outpatient in a Bed",
                        "Pre-Minor Surgery",
                        "External Results",
                        "In-Error",
                        "Lab Recurring",
                        "Internal Results"]
                },

                // Codeset 79: Task Status 
                { 79, ["Cancelled", "Complete", "Deleted", "Delivered", "Discontinued", "Dropped", "In Error", "InProcess",
                      "OnHold", "Opened", "Overdue", "Pending", "Read", "Recalled", "Refused", "Rework", "Suspended", "Pending Validation"] },

                // Codeset 79: Confidential Level
                { 87, ["Chemical Dependency", "Routine Clinical", "Legal/Sensitive", "? Unknown"] },

                // Codeset 88: Position
                { 88, [
                        "Ambulatory - Nurse",
                        "DBA",
                        "Emergency - Nurse",
                        "Emergency - Nurse Manager",
                        "Nurse - ICU",
                        "Residential Care",
                        "RadNet - Nurse",
                        "Nurse - Wound Ostomy",
                        "OB - Ambulatory Nurse",
                        "Respiratory Therapist",
                        "Nurse",
                        "MH - Nurse",
                        "Nurse - Supervisor",
                        "Nurse - NICU",
                        "OB - Nurse",
                        "Nurse - Oncology Ambulatory",
                        "Nurse - Oncology",
                        "Rehab Assistant Basic",
                        "Perioperative - Nurse",
                        "Perioperative - Nurse Team Lead",
                        "Physician - Lab",
                        "DBC - HIM",
                        "MH - Health Care Worker",
                        "DBC - FSI (Interfaces)",
                        "DBC - Scheduling",
                        "Dietetic Student Basic",
                        "Greaseboard",
                        "HIM - Manager/Supervisor",
                        "HIM - Clerk",
                        "Infection Control Practitioner",
                        "Nurse - Rural",
                        "HIM - Document Correction",
                        "Lactation Consultant",
                        "Unit Clerk",
                        "RadNet - Clerk",
                        "MH - Nurse Supervisor",
                        "DBC - Charge Services",
                        "DBC - Registration",
                        "Cardiology Technician",
                        "Occupational Therapist Basic",
                        "Occupational Therapy Student Basic",
                        "PharmNet - Pharmacist Supervisor",
                        "Physical Therapist Basic",
                        "RadNet - Medical Imaging Technologist",
                        "RadNet - Supervisor",
                        "OB - Clerk",
                        "Recreational Therapist Basic",
                        "Music/Art Therapy Basic",
                        "Nurse Practitioner",
                        "PharmNet - Pharmacist Student",
                        "DBC - SurgiNet",
                        "Physician - Emergency",
                        "Physician - Oncologist/Hematologist",
                        "Perioperative - Anesthesia Resident",
                        "DBC - FirstNet",
                        "DBC - PowerChart",
                        "Audiologist",
                        "Child Life Specialist",
                        "DBA Lite",
                        "DBC - RadNet",
                        "RadNet - View Only",
                        "Resident",
                        "Respiratory Therapy Student",
                        "Social Worker Basic",
                        "Speech Language Pathology Student Basic",
                        "DBC - PharmNet Pharmacy Technician",
                        "PharmNet - Pharmacy Buyer",
                        "PharmNet - Pharmacy Technician",
                        "Emergency - Greaseboard",
                        "Finance Clerk - Accounts Receivable",
                        "Perioperative - Scheduler",
                        "Psychologist",
                        "Psychology Student",
                        "Perioperative - Anesthesia Assistant",
                        "HIM - Auditor",
                        "HIM - ROI",
                        "Laboratory - Assistant with Reg",
                        "Emergency - Registration Clerk",
                        "Emergency - Unit Clerk",
                        "Emergency - Health Care Assistant",
                        "Midwife",
                        "Data Quality",
                        "PharmNet - Pharmacist",
                        "Social Work Student Basic",
                        "Physician - Allergist/Immunologist",
                        "Physician - Cardiologist",
                        "PharmNet - Pharmacy Tech Supervisor",
                        "Physician - Orthopedics",
                        "Physician - Physical Medicine Rehab",
                        "Switchboard",
                        "Quality and Risk Management",
                        "Physician - Anesthesiologist Admin",
                        "External - Provider",
                        "Physician - Pediatric Hem/Onc/BMT",
                        "Physician - Pediatric General Surgeon",
                        "Physician - Psychiatrist",
                        "Physician - Residential Care",
                        "Physician - Sports Medicine",
                        "Physician - Surgeon",
                        "Physician - Transplant",
                        "Finance Clerk - Accounts Payable",
                        "Finance Supervisor - Accounts Payable",
                        "PharmNet - Pharmacy Receiver",
                        "Physician - OB/GYN",
                        "Patient Care Manager",
                        "Physician - Anesthesiologist",
                        "Midwife Student",
                        "OB - Nurse Postpartum",
                        "Perioperative - Materials Management",
                        "Perioperative - Nurse Cath Lab",
                        "Perioperative - OR Management",
                        "Registration - Forensics Clerk",
                        "Resident Care Manager",
                        "Medical Student",
                        "Nurse - Acute Pain Service",
                        "Scheduling Supervisor",
                        "Scheduling - Clerk Advanced",
                        "Speech Language Pathologist Basic",
                        "User Provisioning",
                        "Physician - Developmental Pediatrics",
                        "Physician - Plastic Surgeon",
                        "Physician - Primary Care",
                        "Physician - Rheumatologist",
                        "Physician - Urgent Care",
                        "Physician - Palliative Care",
                        "Physician - Pediatric Cardiologist",
                        "Physician - Pediatrician",
                        "Physician - Trauma Team Leader",
                        "Physician - Genetics",
                        "Physician - Nephrologist",
                        "Physician - Endocrinologist",
                        "Ethicist Basic",
                        "Physician - Otolaryngologist",
                        "Physician - PICU",
                        "Physician - Podiatrist",
                        "Physician - Respirologist",
                        "Physician - RRT",
                        "Physician - Urologist",
                        "Physician - Vascular",
                        "Physician - Colorectal Surgeon",
                        "Physician - Dermatologist",
                        "Physician - Float",
                        "Physician - General Medicine",
                        "Emergency - Nurse Practitioner",
                        "Registration - Forensics Supervisor",
                        "Perioperative - Tracking",
                        "Health Care Assistant",
                        "Rehab Assistant Student Basic",
                        "OB - Greaseboard",
                        "Patient Placement",
                        "RadNet - Radiologist",
                        "RadNet - Resident",
                        "FirstNet View Only",
                        "Genetic Counsellor",
                        "Laboratory - Technologist with Reg",
                        "PharmNet - Pharmacy Assistant",
                        "Physical Therapy Student Basic",
                        "DBC - PharmNet Pharmacist",
                        "Dietitian Basic",
                        "Registration - Clerk",
                        "Physician - Gastroenterologist",
                        "Physician - Infectious Disease",
                        "Physician - Neurosurgeon",
                        "Physician - Neurologist",
                        "Physician - Ophthalmologist",
                        "Physician - Geriatrician",
                        "Physician - Critical Care",
                        "Nurse Practitioner - Student",
                        "View Only",
                        "Physician - Rural Oncology",
                        "HIM - Coding",
                        "Physician - BMT Hematologist",
                        "Laboratory - Assistant",
                        "Laboratory - Technologist",
                        "Private MOA",
                        "Finance Clerk - Accounts Rec Cashier",
                        "Physician - Critical Care with SaMacro",
                        "Physician - Rural with SaMacro",
                        "Ambulatory - Nurse with Reg/Sched",
                        "Physical Therapist with Reg/Sched",
                        "Nurse - Oncology Ambulatory with Reg/Sch",
                        "Occupational Therapist with Reg/Sched",
                        "Speech Language Pathologist with Reg/Sch",
                        "Super Clerk",
                        "Physician - NICU",
                        "Physician - Oral Maxillofacial Surgery",
                        "Research - Lev 1/Monitor/Auditor/Inspect",
                        "MH - Nurse Emergency",
                        "Perioperative - Nurse PAC",
                        "Research - Level 2",
                        "Research - Level 3",
                        "Position Picker",
                        "Nurse - IV Therapy"
                    ]
                },

                // Codeset 89: Contributor system
                { 89, ["3M CODING AND REIMBURSEMENT", "3M Australian", "PROFIT_PRECOLL_AGENCY", "ESO OUT",
                      "Centers for Disease Control", "Cerner", "Cerner LDAP", "CIHI", "Client", "FDA", "GDDB"] },

                // Codeset 106: Activity Type
                { 106, ["Patient Care", "Patient Activity", "Asmt/Tx/Monitoring", "Diet Patient Care",
                      "Patient Education", "Intake and Output", "Surgery", "Task", "Home Care", "Critical Care"] },

                // Codeset 120: Compression Code Value
                { 120, ["No Compression", "OCF Compression"] },

                // Codeset 261: Encounter Status Codes
                { 261, ["Active", "Cancelled", "Cancelled Pending Arrival", "Discharged", "Hold", "Pending Arrival",
                      "Preadmit", "Referred", "Rejected Pending Arrival", "Transferred"] },

                // Codeset 263: Alias Pool
                { 263, ["BC PHN", "PharmaNet GPID", "Health Plan", "DEA", "Doctor Nbr", "Encounter Org", "External Id", "Insurance Code", "SSN", "UPIN", "Visit #", "NCT Number", "Default Place of Service"] },

                // Codeset 289: Default Result Type
                { 289, ["Text", "Time", "Date and Time", "Read Only", "Count", "Provider", "ORC Select",
                      "Inventory", "Bill Only", "Yes / No", "Alpha", "Freetext", "Calculation"] },

                // Codeset 302: Person Type 
                { 302, ["Contributor System",
                        "Freetext",
                        "Numeric Name",
                        "Organization",
                        "Person"
                        ]
                },

                // Codeset 321: Encounter Class
                { 321, ["Emergency", "Inpatient", "Outpatient", "Preadmit", "Historical"] },

                // Codeset 400: Source Vocabulary
                { 400, ["Patient Care", "Internal Codes", "ICD-10-CA"] },

                // Codeset 4010: Task Priority Code
                { 4010, ["NOW", "Routine", "STAT"] },

                // Codeset 6000: Catalog Type
                { 6000, ["Ambulatory POC",
                        "Ambulatory Procedures",
                        "Ambulatory Procedure Scheduling",
                        "Ambulatory Referrals",
                        "Admit/Transfer/Discharge",
                        "Audiology",
                        "Blood Bank Donor",
                        "Cardiology",
                        "Cardiovascular",
                        "Case Manager",
                        "Charges",
                        "Consults",
                        "Conversion Charges",
                        "Dialysis",
                        "Nutrition Services",
                        "Durable Medical Equipment",
                        "Evaluation and Management",
                        "ENT",
                        "Environmental Services",
                        "Gastroenterology",
                        "Laboratory",
                        "Home Care Plans/Pathways/Protocols",
                        "Home Care",
                        "Infection Control",
                        "Materials Management",
                        "NeuroDiagnostics",
                        "Patient Care",
                        "Occupational Therapy",
                        "Ophthalmology",
                        "Orthopedics",
                        "Pastoral Care",
                        "Person Management",
                        "Pharmacy",
                        "Physical Therapy",
                        "Physician Charges",
                        "Point of Care Testing",
                        "Procedures",
                        "Pulmonary Medicine",
                        "Radiology",
                        "Recreational Therapy",
                        "Referral",
                        "Respiratory Therapy",
                        "Community/Speciality Pharmacy",
                        "Discern Rule Order",
                        "Scheduling",
                        "Sleep Disorders",
                        "Social Work",
                        "Speech Therapy",
                        "Supplies",
                        "Surgery",
                        "Urology",
                        "Volunteer Services",
                        "Women's Services"]
                },

                // Codeset 6003: Order Action Type
                { 6003, [
                        "Activate",
                        "Add Alias",
                        "Cancel",
                        "Cancel/Discontinue",
                        "Cancel and Reorder",
                        "Clear Future Actions",
                        "Collection",
                        "Complete",
                        "Void",
                        "Demog Change",
                        "Discontinue",
                        "Discharge Order",
                        "Future Discontinue",
                        "History Order",
                        "Modify",
                        "Order",
                        "Refill",
                        "Renew",
                        "Reschedule",
                        "Restore",
                        "Resume",
                        "Resume/Renew",
                        "Review",
                        "Status Change",
                        "Activate Student Order",
                        "Suspend",
                        "Transfer/Cancel",
                        "Undo"
                    ]
                },

                // Codeset 6004: Order Status
                { 6004, [
                    "Canceled",
                    "Completed",
                    "Voided",
                    "Discontinued",
                    "Future",
                    "Incomplete",
                    "InProcess",
                    "On Hold, Med Student",
                    "Ordered",
                    "Pending Complete",
                    "Pending Review",
                    "Suspended",
                    "Transfer/Canceled",
                    "Unscheduled",
                    "Voided With Results"
                    ]
                },

                // Codeset 6006: Communication Type
                { 6006, [ "No Cosignature Required",
                        "Cosignature Required",
                        "Discern Expert",
                        "Paper/Fax",
                        "Proposed",
                        "Phone",
                        "Verbal",
                        "Electronic"
                    ]
                },

                // Codeset 6011: Mnemonic Type
                { 6011, [ "Ancillary",
                        "Brand Name",
                        "Direct Care Provider",
                        "C - Dispensable Drug Names",
                        "Generic Name",
                        "Y - Generic Products",
                        "M - Generic Miscellaneous Products",
                        "E - IV Fluids and Nicknames",
                        "Outreach",
                        "PathLink",
                        "Primary",
                        "Rx Mnemonic",
                        "Surgery Med",
                        "Z - Trade Products",
                        "N - Trade Miscellaneous Products"
                    ]
                },

                // Codeset 6014: Reschedule Reason
                { 6014, [ "Charted on Incorrect Patient",
                        "Equipment/Supplies Unavailable",
                        "Not appropriate at this time",
                        "Patient Out on Pass",
                        "Patient Unavailable",
                        "Parent/Guardian Refused",
                        "Task Duplication",
                        "Charted Prior to Order Placed",
                        "Change in Patient Status",
                        "Order Cancelled by Provider"
                    ]
                },

                // Codeset 6024: Message Subject
                { 6024, [
                        "Call Back",
                        "Complaint",
                        "Medical Problem",
                        "Medication Reaction",
                        "Medication Renewal",
                        "Personal",
                        "Results Inquiry",
                        "Scheduling Question"
                    ]
                },

                // Codeset 6025: Task Class
                { 6025, ["Adhoc", "Continuous", "Non Scheduled", "PRN", "Scheduled"] },

                // Codeset 6026 Task Type
                { 6026, [ "Respiratory Care",
                    "Respiratory Interventions",
                    "SLP Evaluations",
                    "Respiratory Medications",
                    "SLP Outpatient Communication",
                    "Music Therapy",
                    "Palliative Care",
                    "OT/SLP Tasks",
                    "Respiratory Nursing",
                    "Cardiac Home Nursing",
                    "OT/PT Tasks",
                    "Respiratory Therapy",
                    "Print to PDF",
                    "Assessment",
                    "General Assessments",
                    "Basic Care",
                    "Ambulatory Care",
                    "Social Services Consults",
                    "Nutrition Services Consults",
                    "Continuous Asmt/Tx/Monitoring",
                    "Asmt/Tx/Monitoring",
                    "Critical Care",
                    "Admit/Discharge/Transfer",
                    "Nutrition Support",
                    "Nursing Tasks",
                    "Ambulatory POC",
                    "Unit Clerk Task",
                    "Cardiac Nurse Consults",
                    "Nursing System Task",
                    "Periop/Inpatient Nursing Tasks",
                    "Clinical Pharmacy",
                    "Laboratory",
                    "Medication",
                    "Medication Reconciliation",
                    "Notification",
                    "Nurse Collect",
                    "Sunquest Nurse Collect",
                    "Order Notifications",
                    "Patient Care",
                    "Patient Education",
                    "POC Asmt/Tx/Monitoring",
                    "Emergency Care",
                    "Pharmacy Verify",
                    "Long Term Care",
                    "PRN Response",
                    "Transcription",
                    "Transfusion"

                    ]
                },

                // Codeset 6027 Task Activity
                { 6027, ["Abnormal Result",
                        "Collect Specimen",
                        "Chart IO Dialog",
                        "Chart Results",
                        "Chart Variance",
                        "Complete Order",
                        "Complete Personal",
                        "Dr. Cosign",
                        "Provider Letter Draft",
                        "IPASS Action",
                        "Medication History",
                        "New Result",
                        "Nurse Collect",
                        "Nurse Review",
                        "Order Plan",
                        "Perform Result",
                        "Letter",
                        "Review Result",
                        "Saved Document",
                        "Sign Result",
                        "View Only"]
                },

                // Codeset 6029: Task Activity Class
                { 6029, [
                        "Anticipated Document",
                        "Block Signature",
                        "Paper Based Document",
                        "PowerNote"
                    ]
                },

                // Codeset 6034: Task Subtype Code
                { 6034, [
                    "Appointment Request Cancel",
                    "Appointment Request",
                    "Appointment Request Reschedule",
                    "Care Coordination Referral",
                    "Community Outreach",
                    "Complex Care Management Referral",
                    "Disease Management Referral",
                    "Enrollment Outreach",
                    "Initial Assessment",
                    "Patient Follow-up",
                    "Payer Outreach",
                    "Pharmacy Follow-up",
                    "Pharmacy Outreach",
                    "Provider Follow-up",
                    "Provider Outreach",
                    "Wellness Referral",
                    "General Message",
                    "Match",
                    "Non-match",
                    "Patient Information",
                    "Medication Refill",
                    "Prescription Renewal",
                    "Suspect Match"
                    ]
                },

                // Codeset 14024: Task Status Reason Code
                { 14024, [
                            "Task Charted with Form",
                            "Task Charted as Done",
                            "Task Charted as Not Done",
                            "Analysis - Chart not Available",
                            "Analysis - For Review",
                            "Analysis - For Training Review",
                            "Scan Reconciliation - Misc Hold",
                            "Analysis - Review Completed",
                            "Analysis - Training Review Complete",
                            "Analysis - See Note",
                            "Analysis - Rework"
                        ]
                },

                // Codeset 14219: Blood Bank Donor Procedure
                { 14219,
                        [
                            "Autologus Donation",
                            "Direct Donation",
                            "Apheresis Donation",
                            "Phlebotomy",
                            "Recruitment",
                            "Reinstatement"
                        ]
                },

                // Codeset 14281: Department Status
                { 14281, [
                        "Canceled",
                        "Completed",
                        "Arrived",
                        "Procedure Completed",
                        "ED Review",
                        "Procedure In Process",
                        "Scheduled",
                        "Signed",
                        "Unsigned",
                        "Verified",
                        "Deleted",
                        "Discontinued",
                        "Initiated",
                        "Collected",
                        "Lab Activity Deleted",
                        "Dispatched",
                        "Final",
                        "Received",
                        "Result, Partial",
                        "See Administer Order",
                        "Result, Preliminary",
                        "Lab Results Deleted",
                        "Scheduled",
                        "Stain",
                        "Susceptibility",
                        "On Hold",
                        "Ordered",
                        "Partial Fill",
                        "Pending Collection",
                        "Exam Completed",
                        "Exam Ordered",
                        "Exam Removed",
                        "Exam Replaced",
                        "Exam Started",
                        "Refill",
                        "Historical",
                        "Rx History Incomplete",
                        "On File",
                        "On Hold",
                        "Transfer Out"
                    ]
                },

                // Codeset 14766: Relationship Types
                { 14766, [
                        "Parent",
                        "Guardian",
                        "Spouse",
                        "Sibling",
                        "Friend",
                        "Grandparent",
                        "Other Relative",
                        "Self",
                        "Police",
                        "Co-worker",
                        "Child"
                    ]
                },

                // Codeset 14767: Accommodation Reasons
                { 14767, ["Security", "Medically Necessary", "Patient Request", "Psychiatric Concerns",
                      "Senior Administration Request", "To Be Moved When Bed Available",
                    "Equipment in Room", "Infection Control", "Private Only"] },

                // Codeset 16389: DCP Clinical Category
                { 16389, [
                        "Activity",
                        "Allergies",
                        "Admit/Transfer/Discharge",
                        "Consults/Referrals",
                        "Diagnosis",
                        "Diagnostic Tests",
                        "Diet/Nutrition",
                        "Continuous Infusions",
                        "Laboratory",
                        "Medications",
                        "Supplies",
                        "Patient Care",
                        "Procedures",
                        "Status",
                        "Respiratory",
                        "Allied Health",
                        "Blood Products",
                        "Communication Orders",
                        "Non Categorized"
                    ]
                },

                // Codeset 17969: Advanced Beneficiary Note (ABN) Status Code
                { 17969, [
                        "Not Required",
                        "On File",
                        "Required & Missing",
                        "On File - Self Pay",
                        "On File - Refused to Sign",
                        "On File - Refused Service",
                        "Review Required"
                    ]
                },

                // Codeset 18309: Task Activity
                { 18309, [
                        "Dialysis",
                        "Intermittent",
                        "Irrigation",
                        "IV",
                        "Med",
                        "PCA",
                        "Sliding Scale",
                        "Taper",
                        "Titrate",
                        "TPN"
                    ]
                },

                // Codeset 22589: Alternate Level of Care
                { 22589, [
                        "Home Health",
                        "Specialized/Tertiary MH & Addiction",
                        "Transitional Care Unit or Convalescent",
                        "Assisted Living or Supportive Housing",
                        "Family or Social Services",
                        "Adequate Housing",
                        "Mental Health & Addiction Community",
                        "Assessment in Progress - RC",
                        "Companion",
                        "Acute Rehabilitation Facility or Unit",
                        "Assessment in Progress - Other",
                        "Hospice",
                        "Residential Care"
                    ]
                },

                // Codeset 255090: Charting Agent
                { 255090, [
                        "apache",
                        "DocSet",
                        "PowerForm",
                        "Task Completion Service"
                    ]
                },

                // Codeset 4002164: Offset Minute Type Code
                { 4002164, [
                        "Acknowledge Results",
                        "MDI Backward Minutes",
                        "MDI Forward Minutes"
                    ]
                },

                // Codeset 4002509: Rounding Rule Code
                { 4002509, [
                        "Automatic rounding",
                        "Down Nearest hundred",
                        "Down Nearest hundredth",
                        "Down Nearest tenth",
                        "Down Nearest thousandth",
                        "Down Nearest ten",
                        "Down Nearest whole number",
                        "Manually Entered",
                        "Nearest hundred",
                        "No rounding",
                        "Nearest hundredth",
                        "Nearest tenth",
                        "Nearest thousandth",
                        "Nearest ten",
                        "Nearest whole number",
                        "Up Nearest hundred",
                        "Up Nearest hundredth",
                        "Up Nearest tenth",
                        "Up Nearest thousandth",
                        "Up Nearest ten",
                        "Up Nearest whole number"
                    ]
                },
            };

            foreach (var codeSet in codeSets)
            {
                await SeedCodeValuesAsync(codeSet.Key, codeSet.Value);
            }
        }

        //Public method to seed all required code sets
        public async Task SeedAsync2()
        {
            // Add all CodeSets except 2 and 3
            var codeSets = new Dictionary<int, (string Display, string Meaning, string Description, string Definition)[]>
            {
                // Codeset 24 - Doc Format
                { 24, new (string Display, string Meaning, string Description, string Definition)[]
                    {
                        ("C", "CHILD", "Child", "Child Document"),
                        ("Link", "LINK", "Linked Result", "Linked Result"),
                        ("O", "ORPHAN", "Orphan", "Orphaned Document"),
                        ("R", "ROOT", "Root", "Root Document"),
                        ("? Unknown", "UNKNOWN", "Undefined Code", "Undefined Code")
                    }
                }
            };

            foreach (var codeSet in codeSets)
            {
                await SeedCodeValuesAsync2(codeSet.Key, codeSet.Value);
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

        private async Task SeedCodeValuesAsync2(int codeSet, (string Display, string Meaning, string Description, string Definition)[] codeValues)
        {
            if (await _dbContext.CodeValue.AnyAsync(cv => cv.CodeSet == codeSet))
            {
                _logger.Information($"Code values for CodeSet {codeSet} were previously seeded!");
                return;
            }

            _logger.Information($"Seeding CodeSet {codeSet} started...");

            var cvEntities = codeValues
                .Select(cv => new CodeValue
                {
                    CodeSet = codeSet,
                    Display = cv.Display,
                    DisplayKey = ConvertToKey(cv.Display),
                    Definition = cv.Definition,
                    Description = cv.Description,
                    Meaning = cv.Meaning  // Assuming `Meaning` is a field in `CodeValue`
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
