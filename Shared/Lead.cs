namespace BlazorApp.Client.Models
{
    public class Lead
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string CompanyName { get; set; }
        public string CompanySize { get; set; }
        public string Request { get; set; }

        public override string ToString()
        {
            return $"<dl><dt>Name:</dt><dd> {FirstName} {LastName}</dd>" +
                    $"<dt>Email:</dt> <dd>{EmailAddress}</dd>" +
                    $"<dt>Company:</dt> <dd>{CompanyName}</dd>" +
                    $"<dt>Size:</dt> <dd>{CompanySize}</dd>" +
                    $"<dt>Request:</dt><dd>{Request}</dd>";
        }
    }
}
