using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Boggle
{
    [ServiceContract]
    public interface IBoggleService
    {

        /// <summary>
        /// Creates a new.
        /// If name is null or empty after trimming responds with status code Forbidden.
        /// If the name is good will respond with new user info, and status code Created.
        /// </summary>
        /// <param name="Nickname">Desired nickname from user.</param>
        /// <returns>User token.</returns>
        [WebInvoke(Method = "POST", UriTemplate = "/users")]
        UserTokenClass CreateUser(UserInfo Nickname);


        /// <summary>
        /// This method will create a game.
        /// Depending on if the player is the first or second person to join the game a different status
        /// will be returned.
        /// </summary>
        /// <param name="Nickname"></param>
        /// <returns>Game Id of game user joined.</returns>
        [WebInvoke(Method = "POST", UriTemplate = "/games")]
        gameIDClass JoinGame(gameStart Nickname);


        [WebInvoke(Method = "PUT", UriTemplate = "/games")]
        void CancelJoin(UserInfo UserToken);

        //[WebInvoke(Method = "GET",UriTemplate = "/games/{GivenGameID}?Brief={answer}")]
        //GameStateClass getGameStatus(gameIDClass GivenGameID, string brief);

        //////////////JOE MADE THIS///////////////////////////////////////////////////////////////

        /// <summary>
        /// Sends back index.html as the response body.
        /// </summary>
        [WebGet(UriTemplate = "/api")]
        Stream API();

        /// <summary>
        /// Demo.  You can delete this.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        [WebGet(UriTemplate = "/numbers?length={n}")]
        IList<int> Numbers(string n);

        /// <summary>
        /// Demo.  You can delete this.
        /// </summary>
        [WebInvoke(Method = "POST", UriTemplate = "/first")]
        int GetFirst(IList<int> list);
    }
}
