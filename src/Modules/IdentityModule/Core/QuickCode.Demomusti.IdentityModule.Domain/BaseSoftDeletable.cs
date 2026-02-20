using System;
using System.ComponentModel.DataAnnotations.Schema;
using QuickCode.Demomusti.Common;

namespace QuickCode.Demomusti.IdentityModule.Domain;

public class BaseSoftDeletable : ISoftDeletable
{
    [Column("IsDeleted")]
    public bool IsDeleted { get; set; }
    
    [Column("DeletedOnUtc")]
    public DateTime? DeletedOnUtc { get; set; }
}