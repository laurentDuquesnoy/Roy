using System;

namespace JSONUtils
{
    namespace Data
    {
        /// <summary>
        /// Generic Class voor conversie resultaat van het type TResultObject
        /// </summary>
        /// <typeparam name="TResultObject"></typeparam>
        public class ConverterResult<TResultObject>
        {
            public ConverterStatus Status { get; set; }
            public Exception Error { get; set; }
            public TResultObject ReturnValue { get; set; }
        }
    }
}
