using System;
using System.ComponentModel.DataAnnotations.Schema;
using QuickCode.Demomusti.Common;

namespace QuickCode.Demomusti.TrainingModule.Domain;

public class BaseSoftDeletable : ISoftDeletable
{
    [Column("IsDeleted")]
    public bool IsDeleted { get; set; }
    
    [Column("DeletedOnUtc")]
    public DateTime? DeletedOnUtc { get; set; }
}