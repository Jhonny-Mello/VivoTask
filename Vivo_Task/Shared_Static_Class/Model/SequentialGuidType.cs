using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using Vivo_Task.Shared_Static_Class.DB_Context_Vivo_MAIS;
using Vivo_Task.Shared_Static_Class.Data;

namespace Vivo_Task.Shared_Static_Class.FundamentalModels
{
    public partial class SequentialGuidGenerator : ValueGenerator<Guid>
    {
        private long _sequence; // Initialize the sequence counter

        public override bool GeneratesTemporaryValues => false;

        public override Guid Next(EntityEntry entry)
        {
            if (_sequence == 0)
            {
                // Query the existing records to find the maximum index
                var maxIndex = entry.Context.Set<DEMANDA_RELACAO_CHAMADO>().Count();
                _sequence = maxIndex + 1;
            }
            else
            {
                // Increment the sequence for each new record
                _sequence++;
            }

            // Convert the sequence to bytes (always 2 bytes)
            byte[] sequenceBytes = BitConverter.GetBytes((ushort)_sequence);

            // Create a new GUID with the sequence in the first 4 bytes
            byte[] guidBytes = new byte[16];
            Buffer.BlockCopy(sequenceBytes, 0, guidBytes, 0, 2);

            // Generate the remaining 12 bytes using a random GUID
            Guid randomGuid = Guid.NewGuid();
            byte[] randomBytes = randomGuid.ToByteArray();
            Buffer.BlockCopy(randomBytes, 0, guidBytes, 2, 12);

            return new Guid(guidBytes);
        }
    }

}