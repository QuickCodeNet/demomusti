using System.ComponentModel.DataAnnotations.Schema;

namespace QuickCode.Demomusti.Common;

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
    DateTime? DeletedOnUtc { get; set; }
}