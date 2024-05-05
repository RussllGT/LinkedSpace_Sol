using System;

namespace LinkedSpace.View.Dialog
{
    public class GenericArgs<T> : EventArgs
    {
        public T Result { get; }
        public GenericArgs(T result) { Result = result; }
    }
}