using N41_C.Exceptions;

namespace N41_C.Services;

public class RecommendationService
{

    public List<string> GetRecommendations()
    {
        try
        {
            return FilterRecommendations(QueryRecommendations());
        }
        catch (InvalidOperationException exception)
        {
            throw new RecommendationServiceException("Processing recommendations failed. Conctact support.", exception);
        }
    }

    private List<string> FilterRecommendations(List<string> recommendations)
    {
        throw new InvalidOperationException();
    }

    private List<string> QueryRecommendations()
    {
        return new List<string>();
    }
}