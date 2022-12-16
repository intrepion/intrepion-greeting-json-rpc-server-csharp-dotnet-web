public class JsonRpcRequest
{
    public string? Id { get; set; }
    public string? Jsonrpc { get; set; }
    public string? Method { get; set; }
    public JsonRpcParams? Params { get; set; }
}
