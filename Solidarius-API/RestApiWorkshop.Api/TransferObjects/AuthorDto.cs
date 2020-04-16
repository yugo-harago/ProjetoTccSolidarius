namespace RestApiWorkshop.Api.TransferObjects
{
    /// <summary>
    /// Entidade Autor. Representa um autor de blogs.
    /// </summary>
    public class AuthorDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Nome todo do autor
        /// </summary>
        public string Name { get; set; }
    }
}