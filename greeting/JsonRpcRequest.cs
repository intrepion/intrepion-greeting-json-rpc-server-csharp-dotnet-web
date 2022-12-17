public class JsonRpcRequest
{
    public required string Id { get; set; }
    public required string Jsonrpc { get; set; }
    public required string Method { get; set; }
    public required JsonRpcParams Params { get; set; }
}
