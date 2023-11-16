using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shared;

public class ResponseAPI<T>
{
    public HttpStatusCode statusCode {  get; set; }
    
    public bool IsSuccess { get; set; } //para indicar si la operacion del CRUD es correcto 

    public T? Value { get; set; } //devolver lista, id, etc

    public string? Message { get; set; }
}
