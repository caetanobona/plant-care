using System.Diagnostics;

namespace PlantCare.Domain.Result;

public class Result<T>
{
    private T? Data { get;  }
    private bool IsSuccess { get; }
    private Notification.Notification Errors { get; }

    private Result(bool isSuccess, T? data, Notification.Notification? notification)
    {
        if (isSuccess && notification != null || !isSuccess && notification == null)
        {
            throw new ArgumentException("Must be success without errors or have errors without success");
        }
        
        Data = data;
        IsSuccess = isSuccess;
        Errors = notification ?? Notification.Notification.None;
    }   
    
    public static Result<T> Success(T data) => new Result<T>(true, data, Notification.Notification.None);
    public static Result<T> Failure(Notification.Notification notifications) => new Result<T>(false, default, notifications);
}