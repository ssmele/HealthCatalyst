﻿using System.Collections.Generic;
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
        UserInfo CreateUser(UserInfo Nickname);


        /// <summary>
        /// Creates a new game. 
        /// </summary>
        /// <param name="Nickname"></param>
        /// <returns></returns>
        [WebInvoke(Method = "POST", UriTemplate = "/games")]
        gameIDClass JoinGame(gameStart Nickname);




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
