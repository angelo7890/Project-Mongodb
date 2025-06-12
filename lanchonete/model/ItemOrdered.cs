namespace lanchonete.model;

public class ItemOrdered
{
    public string item_id { get; set; }
    public int quantity { get; set; }
    public string? observation  { get; set; }
    public List<AdditionalOrdered>? additional { get; set; }
}