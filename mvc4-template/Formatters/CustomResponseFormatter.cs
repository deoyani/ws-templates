﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using mvc4_template.Models;
using System.IO;
using System.Net.Http;

namespace mvc4_template.Formatters
{
    public class CustomResponseFormatter : BufferedMediaTypeFormatter
    {
        public CustomResponseFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/xml"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
        }

        public override bool CanWriteType(System.Type type)
        {
            if (type == typeof(CustomResponse))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override void WriteToStream(Type type, object o, Stream stream, HttpContent content)
        {
            if (content.Headers.ContentType.Equals(new MediaTypeHeaderValue("application/xml")))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write("<Value>" + ((CustomResponse)o).Value + "</Value>");
                }
            }
            else if (content.Headers.ContentType.Equals(new MediaTypeHeaderValue("application/json")))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write("{\"Value\":\"" + ((CustomResponse)o).Value + "\"}");
                }
            }
            else if (content.Headers.ContentType.Equals(new MediaTypeHeaderValue("text/plain")))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write("Value: " + ((CustomResponse)o).Value);
                }
            }

            stream.Close();
        }

    }
}