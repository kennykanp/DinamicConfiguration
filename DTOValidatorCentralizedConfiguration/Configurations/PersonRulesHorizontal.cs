namespace DTOValidatorCentralizedConfiguration.Configurations
{
    public class PersonRulesHorizontal
    {

        public Dictionary<string, Tuple<string, Dictionary<string, string>>> Name { get; set; } = new Dictionary<string, Tuple<string, Dictionary<string, string>>>
    {
        { "HasMatch", new Tuple<string, Dictionary<string, string>>(@"^[A-Z][a-z]+(?: [A-Z][a-z]+)*$", new Dictionary<string, string> { { "en-US", "Name must be PascalCase and space allowed" }, { "es-ES", "Nombre debe ser PascalCase y espacio permitido" } }) },
        { "IsRequired", new Tuple<string, Dictionary<string, string>>("true", new Dictionary<string, string> { { "en-US", "Name is required" }, { "es-ES", "Nombre es requerido" } }) },
        { "HasLength", new Tuple<string, Dictionary<string, string>>("2,50", new Dictionary<string, string> { { "en-US", "Name must be between 2 and 50 characters" }, { "es-ES", "Nombre debe tener entre 2 y 50 caracteres" } }) }
    };

        public Dictionary<string, Tuple<string, Dictionary<string, string>>> Age { get; set; } = new Dictionary<string, Tuple<string, Dictionary<string, string>>>
    {
        { "IsRequired", new Tuple<string, Dictionary<string, string>>("true", new Dictionary<string, string> { { "en-US", "Age is required" }, { "es-ES", "Edad es requerida" } }) },
        { "HasIntegerGreaterThan", new Tuple<string, Dictionary<string, string>>("0", new Dictionary<string, string> { { "en-US", "Age must be greater than 0" }, { "es-ES", "Edad debe ser mayor que 0" } }) }
    };

        public Dictionary<string, Tuple<string, Dictionary<string, string>>> Birthday { get; set; } = new Dictionary<string, Tuple<string, Dictionary<string, string>>>
    {
        { "IsRequired", new Tuple<string, Dictionary<string, string>>("true", new Dictionary<string, string> { { "en-US", "Birthday is required" }, { "es-ES", "Fecha de nacimiento es requerida" } }) },
        { "HasDateTimeLessThan", new Tuple<string, Dictionary<string, string>>("DateTime.Now", new Dictionary<string, string> { { "en-US", "Birthday must be in the past" }, { "es-ES", "Fecha de nacimiento debe ser en el pasado" } }) }
    };

        public Dictionary<string, Tuple<string, Dictionary<string, string>>> Email { get; set; } = new Dictionary<string, Tuple<string, Dictionary<string, string>>>
    {
        { "IsRequired", new Tuple<string, Dictionary<string, string>>("true", new Dictionary<string, string> { { "en-US", "Email is required" }, { "es-ES", "Correo electrónico es requerido" } }) },
        { "HasMatch", new Tuple<string, Dictionary<string, string>>("Email", new Dictionary<string, string> { { "en-US", "Email must be a valid email address" }, { "es-ES", "Correo electrónico debe ser una dirección de correo electrónico válida" } }) },
        { "HasLength", new Tuple<string, Dictionary<string, string>>("2,50", new Dictionary<string, string> { { "en-US", "Email must be between 2 and 50 characters" }, { "es-ES", "Correo electrónico debe tener entre 2 y 50 caracteres" } }) }
    };

        public Dictionary<string, Tuple<string, Dictionary<string, string>>> IsEmployed { get; set; } = new Dictionary<string, Tuple<string, Dictionary<string, string>>>
    {
        { "IsRequired", new Tuple<string, Dictionary<string, string>>("true", new Dictionary<string, string> { { "en-US", "IsEmployed is required" }, { "es-ES", "Está empleado es requerido" } }) }
    };

        public Dictionary<string, Tuple<string, Dictionary<string, string>>> Skills { get; set; } = new Dictionary<string, Tuple<string, Dictionary<string, string>>>
    {
        { "IsRequired", new Tuple<string, Dictionary<string, string>>("true", new Dictionary<string, string> { { "en-US", "Skills is required" }, { "es-ES", "Habilidades son requeridas" } }) },
        { "HasLength", new Tuple<string, Dictionary<string, string>>("1,", new Dictionary<string, string> { { "en-US", "Skills must have at least one element" }, { "es-ES", "Habilidades deben tener al menos un elemento" } }) }
    };

        public Dictionary<string, Tuple<string, Dictionary<string, string>>> Address { get; set; } = new Dictionary<string, Tuple<string, Dictionary<string, string>>>
    {
        { "IsRequired", new Tuple<string, Dictionary<string, string>>("true", new Dictionary<string, string> { { "en-US", "Address is required" }, { "es-ES", "Dirección es requerida" } }) }
    };

        public Dictionary<string, Tuple<string, Dictionary<string, string>>> Street { get; set; } = new Dictionary<string, Tuple<string, Dictionary<string, string>>>
    {
        { "IsRequired", new Tuple<string, Dictionary<string, string>>("true", new Dictionary<string, string> { { "en-US", "Street is required" }, { "es-ES", "Calle es requerida" } }) }
    };
    }
}
