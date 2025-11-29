namespace PracticaProgramada.BLL.Dtos
{
    public class CustomResponse<T>
    {
        public bool Ok { get; set; }
        public string Mensaje { get; set; }
        public T Datos { get; set; }

        public static CustomResponse<T> Success(T datos, string mensaje = "")
        {
            return new CustomResponse<T>
            {
                Ok = true,
                Datos = datos,
                Mensaje = mensaje
            };
        }

        public static CustomResponse<T> Fail(string mensaje)
        {
            return new CustomResponse<T>
            {
                Ok = false,
                Mensaje = mensaje
            };
        }
    }
}
