using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.Geometry
{
    class Exeption
    {
    }

    [Serializable()]
    public class FalseArgumentExeption : System.Exception
    {
        public FalseArgumentExeption() : base() { }
        public FalseArgumentExeption(string message) : base(message) { }
        public FalseArgumentExeption(string message, System.Exception inner) : base(message, inner) { }


        protected FalseArgumentExeption(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
    public class NoFormExeption : System.Exception
    {
        public NoFormExeption() : base() { }
        public NoFormExeption(string message) : base(message) { }
        public NoFormExeption(string message, System.Exception inner) : base(message, inner) { }


        protected NoFormExeption(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
    public class NoCommandExeption : System.Exception
    {
        public NoCommandExeption() : base() { }
        public NoCommandExeption(string message) : base(message) { }
        public NoCommandExeption(string message, System.Exception inner) : base(message, inner) { }


        protected NoCommandExeption(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
    public class NoValidPointCountExeption : System.Exception
    {
        public NoValidPointCountExeption() : base() { }
        public NoValidPointCountExeption(string message) : base(message) { }
        public NoValidPointCountExeption(string message, System.Exception inner) : base(message, inner) { }


        protected NoValidPointCountExeption(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
    public class NotExistingDirectoryException : System.Exception
    {
        public NotExistingDirectoryException() : base() { }
        public NotExistingDirectoryException(string message) : base(message) { }
        public NotExistingDirectoryException(string message, System.Exception inner) : base(message, inner) { }


        protected NotExistingDirectoryException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
}
