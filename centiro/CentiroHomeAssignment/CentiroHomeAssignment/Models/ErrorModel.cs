using System;
namespace CentiroHomeAssignment.Models
{
	public class ErrorModel
	{
		public string ErrorCode { get; set; }
        public string ErrorMassage { get; set; }
        public ErrorModel(string NewErrorCode, string NewErrorMassage)
		{
			ErrorCode = NewErrorCode;
			ErrorMassage = NewErrorMassage;
		}
	}
}

