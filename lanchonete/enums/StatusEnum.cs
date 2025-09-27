using System.Text.Json.Serialization;

namespace lanchonete.enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StatusEnum
{
    CRIADO,
    EM_PREPARO,
    ENTREGUE, 
    CANCELADO
}