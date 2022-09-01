using System.Text.Json.Serialization;

namespace MainProjectCORE.DTOs
{
    public class CustomResponseDto<T>
    {
        //Apilere özel bir durum.
        public T Data { get; set; }

        [JsonIgnore]

        public int StatusCode { get; set; }
        public List<String> Errors { get; set; }

        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Data = data };
        }

        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode };
        }

        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors };
        }
        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }

        //static factory method. Factory Design = Hangi sınıfı dönmek istiyorsak o sınıfın içerisinde statik methodlar
        //tanımlayarak geriye instanceler dönüyoruz. New anahtar sözcüğü yerine bu methodlarla nesne üretme işini 
        //bu sınıf içerisinde gerçekleştiriyoruz.


    }
}
