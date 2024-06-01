namespace Application.Features.Urls.Constants
{
    public class UrlMessages
    {
        public const string InvalidExpirationDate = "Expiration date must be greater than today";
        public const string InvalidUrl = "Url must start with http";
        public const string UrlNotFound = "Url not found";
        public const string UrlExpired = "Url has expired";
        public const string UrlCannotBeNull = "Url cannot be null";
        public const string FullUrlCannotBeNull = "Full url cannot be null";
        public const string ShortUrlCannotBeNull = "Full url cannot be null";
        public const string ExpirationDateCannotBeNull = "Expiration date cannot be null";
        public const string ShortUrlTooLong = "Short url is too long";
    }
}
