using System;

namespace RenCapGrpc.Shared
{
    [Serializable]
    public class CustomRequest
    {
        public int Payload { get; set; }
    }

    [Serializable]
    public class CustomResponse
    {
        public int Payload { get; set; }
    }
}