using EmprestimoLivrosNovo.API.Models;
using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace EmprestimoLivrosNovo.API.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, PaginationHeader header)
        {
            var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            response.Headers.Add("Pagination", JsonSerializer.Serialize(header, jsonOptions));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
