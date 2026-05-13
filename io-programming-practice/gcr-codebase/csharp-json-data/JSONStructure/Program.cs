using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

class Program
{
    static void Main()
    {
        string schemaJson = @"{
          'type': 'object',
          'properties': {
            'name': { 'type': 'string' },
            'age': { 'type': 'integer' },
            'email': { 'type': 'string' }
          },
          'required': [ 'name', 'age', 'email' ]
        }";

        string jsonData = @"{
          'name': 'Devansh',
          'age': 21,
          'email': 'devansh@example.com'
        }";

        // Load schema
        JSchema schema = JSchema.Parse(schemaJson);

        // Parse JSON
        JObject jsonObject = JObject.Parse(jsonData);

        // Validate
        IList<ValidationError> errors;
        bool isValid = jsonObject.IsValid(schema, out errors);

        Console.WriteLine("Is JSON valid? " + isValid);

        if (!isValid)
        {
            foreach (ValidationError error in errors)
            {
                Console.WriteLine("Error: " + error.Message);
            }
        }
    }
}