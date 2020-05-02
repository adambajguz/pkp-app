namespace TrainsOnline.Desktop.Application.Exceptions
{
    using System;
    using TrainsOnline.Desktop.Application.Extensions;
    using TrainsOnline.Desktop.Domain.DTO;

    public class RemoteDataException : Exception
    {
        public RemoteDataException(string message) : base(message)
        {

        }

        public ExceptionResponse GetResponse()
        {
            return Message.ToObject<ExceptionResponse>();
        }
    }
}
