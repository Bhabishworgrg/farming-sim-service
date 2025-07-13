public class DataResult<T> {
	public T? Model { get; set; }
	public required int StatusCode { get; set; }
	public required string Message { get; set; }
}
