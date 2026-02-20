namespace QuickCode.Demomusti.Gateway.Messaging;

public record MessageEnvelope<T>(T Message, string CorrelationId) where T : IMessage;
