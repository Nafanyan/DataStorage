namespace Application.Results
{
    public class ResultT<T>
    {
        public bool IsSuccess => Errors.Count == 0;

        public List<Error> Errors { get; init; }

        public T Value { get; init; }

        private ResultT( T value )
        {
            Value = value;
        }

        private ResultT( List<Error> errors )
        {
            Errors = errors;
        }

        public static ResultT<T> Success( T value )
        {
            return new ResultT<T>( value );
        }

        public static ResultT<T> Error( List<Error> errors )
        {
            return new ResultT<T>( errors );
        }
    }
}

