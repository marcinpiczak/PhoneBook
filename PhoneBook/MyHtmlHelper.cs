using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;

namespace PhoneBook
{
    public class MyHtmlHelper : IHtmlContent
    {
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            throw new NotImplementedException();
        }
    }
}
