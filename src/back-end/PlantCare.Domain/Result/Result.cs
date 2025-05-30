namespace PlantCare.Domain.Result;

public class Result
{
    private readonly List<string> _errors;
    public bool IsSuccess { get; }
    public IReadOnlyList<string> Errors => _errors;
    public bool IsFailure => !IsSuccess;

    protected Result(bool isSuccess, List<string>? errors, string? error = null)
    {
        if (isSuccess && (errors is not null || error is not null) || !isSuccess && (errors is null && error is null))
        {
            throw new ArgumentException("Must be success without errors or have errors without success");
        }

        if (error is not null && errors is not null)
        {
            throw new ArgumentException("Must provide a list of errors or a single error");
        }
        
        IsSuccess = isSuccess;
        _errors = errors ?? (error is not null ? new List<string> { error } : new List<string>());
    }   
    
    public void AddError(string notification) =>  _errors.Add(notification);
    public bool HasErrors => _errors.Any();
    
    public static Result Success() => new Result(true, null);
    public static Result Failure(List<string> errors) => new Result(false, errors);
    public static Result Failure(string error) => new Result(false, null, error);

}

public class Result<T> : Result
{
    private readonly T? _value;

    public T? Value 
    {
        get
        {
            if (IsFailure)
            {
                throw new InvalidOperationException("Can't get value when result is failure");
            }
            return _value;
        }
    }
    
    private Result(bool isSuccess, List<string>? errors, T? value, string? error = null) : base(isSuccess, errors, error)  
    {
        _value = value;  
    }
    
    public static Result<T> Success(T value) => new Result<T>(true, null, value);
    public new static Result<T> Failure(List<string> errors) => new Result<T>(false, errors, default);
    public new static Result<T> Failure(string error) => new Result<T>(false, null, default, error);
}