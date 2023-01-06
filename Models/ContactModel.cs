using System;
using System.Collections.Generic;

namespace SampleCollection1.Models;

public partial class ContactModel
{
    public string CommonId { get; set; } = null!;

    public string ContactType { get; set; } = null!;

    public string ContactValue { get; set; } = null!;

    public string Comments { get; set; } = null!;

    public string MemberId { get; set; } = null!;

    public virtual MemberModel Member { get; set; } = null!;
}
