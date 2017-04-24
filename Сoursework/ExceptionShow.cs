using System;

namespace Сoursework
{
    class ExceptionShow : ApplicationException
    {
        public ExceptionShow() { }
        public ExceptionShow(string message) : base(message) { }
        public ExceptionShow(string message, Exception ex) : base(message) { }
    }
}
