public class DataResult<T> {
	public required T Model { get; set; }
	public required int StatusCode { get; set; }
	public required string Message { get; set; }
}
