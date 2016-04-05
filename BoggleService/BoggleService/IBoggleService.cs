// Hanna Larsen & Salvatore Stone Mele
// u0741837        u0897718
// CS 3500  PS10
// 03/31/16
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
        /// <param name="Nickname">user token & time limit</param>
        /// <returns>Game Id of game user joined.</returns>
        [WebInvoke(Method = "POST", UriTemplate = "/games")]
        gameIDClass JoinGame(gameStart Nickname);

        /// <summary>
        /// This method cancels a pending game join request. 
        /// </summary>
        /// <param name="UserToken">user token</param>
        [WebInvoke(Method = "PUT", UriTemplate = "/games")]
        void CancelJoin(UserInfo UserToken);

        /// <summary>
        /// This method gets info on given current game. 
        /// </summary>
        /// <param name="GivenGameID">game id</param>
        /// <param name="answer">brief answer</param>
        /// <returns>various game information depending on the game state</returns>
        [WebInvoke(Method = "GET", UriTemplate = "/games/{GivenGameID}?Brief={answer}")]
        GameStateClass getGameStatus(string GivenGameID, string answer);

        /// <summary>
        /// This method submits a word. 
        /// </summary>
        /// <param name="wordInfo"> word & user token</param>
        /// <param name="GivenGameID">game id</param>
        /// <returns>score</returns>
        [WebInvoke(Method = "PUT", UriTemplate = "/games/{GivenGameID}")]
        ScoreResponse SubmitWord(WordSubmit wordInfo, string GivenGameID);

        //////////////JOE MADE THIS///////////////////////////////////////////////////////////////

        /// <summary>
        /// Sends back index.html as the response body.
        /// </summary>
        [WebGet(UriTemplate = "/api")]
        Stream API();

       
    }
}
