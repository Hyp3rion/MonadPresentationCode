namespace Monads.Domain
{
    public class PostCode
    {
        readonly string _postcode;

        public PostCode(string postcode)
        {
            _postcode = postcode;
        }

        public override string ToString()
        {
            return _postcode;
        }
    }
}