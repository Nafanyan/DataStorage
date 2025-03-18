namespace Application.Results
{
    public class Result
    {
        public bool IsSuccess => Errors.Count == 0;

        public List<Error> Errors { get; init; }

        public Result()
        { }

        private Result( List<Error> errors )
        {
            Errors = errors;
        }

        public static Result Success()
        {
            return new Result();
        }

        public static Result Error( List<Error> errors )
        {
            return new Result( errors );
        }
    }
}

