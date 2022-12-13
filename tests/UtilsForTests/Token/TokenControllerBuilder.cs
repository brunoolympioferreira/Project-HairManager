using HairManager.Application.Utils.Token;

namespace UtilsForTests.Token;
public class TokenControllerBuilder
{
    public static TokenController Instancia()
    {
        return new TokenController(1000, "TTNTUjUjQkpeSXJVJnE4IzU1RUVlSHdRSWxna2hkOXZSJjgzWDIkR2ZoQ3pUZWI0THM=");
    }
}
