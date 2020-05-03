namespace TrainsOnline.Infrastructure.StringSimilarityComparer
{
    using F23.StringSimilarity;
    using TrainsOnline.Application.Interfaces;

    public class StringSimilarityComparerService : IStringSimilarityComparerService
    {
        private JaroWinkler JaroWinklerComparer { get; } = new JaroWinkler();

        public StringSimilarityComparerService()
        {

        }
       
        public bool AreSimilar(string s0, string s1, double threshold = 0.75)
        {
            return JaroWinklerComparer.Similarity(s0, s1) >= threshold;
        }
    }
}
