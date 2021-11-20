namespace RenCapGrpc.Shared
{
    using Grpc.Core;
    public class Descriptors
    {
        public static Method<CustomRequest, CustomResponse> Method =
                new Method<CustomRequest, CustomResponse>(
                    type: MethodType.Unary,
                    serviceName: "CustomService",
                    name: "CustomMethod",
                    requestMarshaller: Marshallers.Create(
                        serializer: Serializer<CustomRequest>.ToBytes,
                        deserializer: Serializer<CustomRequest>.FromBytes),
                    responseMarshaller: Marshallers.Create(
                        serializer: Serializer<CustomResponse>.ToBytes,
                        deserializer: Serializer<CustomResponse>.FromBytes));
    }
}