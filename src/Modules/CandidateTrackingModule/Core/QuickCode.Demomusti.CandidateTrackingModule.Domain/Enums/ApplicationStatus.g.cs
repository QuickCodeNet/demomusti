using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.Demomusti.CandidateTrackingModule.Domain.Enums;

public enum ApplicationStatus{
	[Description("Application has been received")]
	Received,
	[Description("Application is under review")]
	Reviewing,
	[Description("Candidate has been shortlisted")]
	Shortlisted,
	[Description("Candidate has been rejected")]
	Rejected,
	[Description("Candidate is scheduled for interview")]
	Interview,
	[Description("Offer has been extended")]
	Offered,
	[Description("Candidate has been hired")]
	Hired
}
