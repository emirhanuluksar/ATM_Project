namespace Application.Utilities.Exceptions;

public class CategoryAlreadyExistsException : Exception {
    public CategoryAlreadyExistsException() : base() {
    }

    public CategoryAlreadyExistsException(string? message) : base(message) {
    }

    public CategoryAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException) {
    }
}
