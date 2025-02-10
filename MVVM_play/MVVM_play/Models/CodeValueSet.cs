using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVM_play.Models
{
    [Index(nameof(CodeSet), IsUnique = true)]
    public class CodeValueSet : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CodeSet { get; set; }
        public bool ActiveInd { get; set; } = true;
        public bool AddAccessInd { get; set; } = true;
        public bool AliasDupInd { get; set; } = false;
        public bool CacheInd { get; set; } = false;
        public bool MeaningDupInd { get; set; } = false;
        public bool ChangeAccessInd { get; set; } = true;
        public int? CodeSetHits { get; set; }
        public int CodeValueCnt { get; set; } = 0;
        public string? Contributor { get; set; }
        public string? Definition { get; set; }
        public bool DefinitionDupInd { get; set; } = false;
        public bool DelAccessInd { get; set; } = false;
        public string? Description { get; set; }
        public string Display { get; set; } = "";
        public bool DisplayDupInd { get; set; } = false;
        public string? DisplayKey { get; set; }
        public bool DisplayKeyDupInd { get; set; } = false;
        public int DomainCodeSet { get; set; } = 0;
        public bool DomainQualifierInd { get; set; } = false;
        public bool ExtensionInd { get; set; } = true;
        public bool InqAccessInd { get; set; } = true;
        public long InstId { get; set; } = 0;
        public string? OwnerModule { get; set; }
        public string? TableName { get; set; }


        public override string ToString()
        {
            return $"<CodeSet(CodeSet={CodeSet}, Display={Display})>";
        }
    }
}
