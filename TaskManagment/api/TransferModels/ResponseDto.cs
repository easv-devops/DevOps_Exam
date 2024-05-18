using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.TransferModels
{
    public class ResponseDto
    {
        public required string MessageToClient { get; set; }

        public Object? ResponseData { get; set; }
    }
}