public class JsonRpcResponse
{
    public required string Id { get; set; }
    public required string Jsonrpc { get; set; }
    public required JsonRpcResult Result { get; set; }
}
