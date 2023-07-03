namespace Application.Utilities.Exceptions;

public class ProductAlreadyExistsException : Exception {
    public ProductAlreadyExistsException() : base() {
    }

    public ProductAlreadyExistsException(string? message) : base(message) {
    }

    public ProductAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException) {
    }
}
