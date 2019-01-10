using System;

namespace Abacus.Data.ReferenceData
{
    public class ReferenceDataNotFoundException<T> : Exception
    {
        public ReferenceDataNotFoundException(IReferenceDataId<T> id)
            : base(GenerateMessageForId(id))
        {
        }

        private static string GenerateMessageForId(IReferenceDataId<T> id)
        {
            return "Could not find reference data with id '" + id + "'.";
        }
    }
}
