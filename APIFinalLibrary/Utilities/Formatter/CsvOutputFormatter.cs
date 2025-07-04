﻿using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace APIFinalLibrary.Utilities.Formatter
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        protected override bool CanWriteType(Type? type)
        {
            if (typeof(BookDto).IsAssignableFrom(type) || typeof(IEnumerable<BookDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }
        public static void FormatCsv(StringBuilder buffer, BookDto book)
        {
            buffer.AppendLine($"{book.ID},{book.Title},{book.Price}");
        }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<BookDto> books)
            {
                foreach (var book in books)
                {
                    FormatCsv(buffer, book);
                }
            }
            else if (context.Object is BookDto book)
            {
                FormatCsv(buffer, book);
            }
            await response.WriteAsync(buffer.ToString(), selectedEncoding);
        }
    }
}
