using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Responses
{
    public class DrugFrequencyResponse
    {

        public DrugTypeEnum DrugType { get; set; }
        public DrugFreqEnum Frequency { get; set; }
    }
}
