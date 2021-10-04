namespace StockAlert
{
  public class ApiResult
  {
    public dynamic results { get; set; }
    public string by { get; set; }
    public bool valid_key { get; set; }
    public bool from_cache { get; set; }
    public double execution_time { get; set; }
  }
}