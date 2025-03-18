namespace Application.Results
{
	public class Error
	{
		public string ErrorMsg { get; init; }

		public Error(string errorMsg)
		{
			ErrorMsg = errorMsg;
		}
	}
}

