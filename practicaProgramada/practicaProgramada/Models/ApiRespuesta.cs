namespace PracticaProgramada.Web.Models
{
    public class ApiRespuesta<T>
    {
        [JsonPropertyName("esError")]
        public bool EsError { get; set; }

        [JsonPropertyName("mensaje")]
        public string Mensaje { get; set; } = string.Empty;

        [JsonPropertyName("data")]
        public T Resultado { get; set; } = default!;
    }
}
