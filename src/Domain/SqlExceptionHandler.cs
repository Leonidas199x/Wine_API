using FluentValidation.Results;
using System.Data.SqlClient;

namespace Domain
{
    public static class SqlExceptionHandler
    {
        public static ValidationResult HandleException(SqlException ex, string entity)
        {
            var exceptionNumber = ex.Number;
            ValidationFailure validationFailure;
            ValidationResult validationResult;

            if(exceptionNumber == 547)
            {
                var column = GetColumnFromError(ex.Message);
                validationFailure = new ValidationFailure(column, $"{entity} is being used, cannot be deleted");
                validationResult = new ValidationResult();
                validationResult.Errors.Add(validationFailure);

                return validationResult;
            }

            validationFailure = new ValidationFailure(string.Empty, "Something went wrong");
            validationResult = new ValidationResult();
            validationResult.Errors.Add(validationFailure);

            return validationResult;
        }

        private static string GetColumnFromError(string message)
        {
            var columnPosition = message.LastIndexOf("column");
            var firstIndexOfInvertedComma = message.IndexOf("'", columnPosition);
            var lastIndexOfInvertedComma = message.IndexOf("'", firstIndexOfInvertedComma + 1);

            return message[firstIndexOfInvertedComma..lastIndexOfInvertedComma];
        }
    }
}
