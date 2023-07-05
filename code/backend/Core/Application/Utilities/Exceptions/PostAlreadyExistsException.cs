namespace Application.Utilities.Exceptions;

public class PostAlreadyExistsException : Exception {
    public PostAlreadyExistsException() : base() {
    }

    public PostAlreadyExistsException(string? message) : base(message) {
    }

    public PostAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException) {
    }
}
